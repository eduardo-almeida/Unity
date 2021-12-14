using UnityEngine;
using System.IO;
using System.Collections.Generic;
using System.Collections;

public class UnidadeHex : MonoBehaviour
{
	public static UnidadeHex unidadePrefab;
	List<HexCell> caminhotravessia;
	const float velocidadeTravessia = 4f;
	const float rotationSpeed = 180f;

	public HexCell Location {
		get {
			return location;
		}
		set {
			if (location) {
				location.Unidade = null;
			}
			location = value;
			value.Unidade = this;
			transform.localPosition = value.Position;
		}
	}

	HexCell location;

	public float Orientation {
		get {
			return orientation;
		}
		set {
			orientation = value;
			transform.localRotation = Quaternion.Euler(0f, value, 0f);
		}
	}

	float orientation;

	public void ValidateLocation() {
		transform.localPosition = location.Position;
	}

	public void Die() {
		location.Unidade = null;
		Destroy(gameObject);
	}

	public void Save(BinaryWriter writer) {
		location.coordinates.Save(writer);
		writer.Write(orientation);
	}

	public static void Load(BinaryReader reader, HexGrid grid) {
		HexCoordinates coordinates = HexCoordinates.Load(reader);
		float orientation = reader.ReadSingle();
		grid.AdicionarUnidade(
			Instantiate(unidadePrefab), grid.GetCell(coordinates), orientation
		);
	}

	public bool IsValidDestination(HexCell cell) {
		return !cell.IsUnderwater && !cell.Unidade;
	}

	public int Velocidade {
		get {
			return 24;
		}
	}

	public int GetMoveCost(
		HexCell fromCell, HexCell toCell, HexDirection direction) {
		if (!IsValidDestination(toCell)) {
			return -1;
		}
		HexEdgeType edgeType = fromCell.GetEdgeType(toCell);
		if (edgeType == HexEdgeType.Cliff) {
			return -1;
		}
		int moveCost;
		if (fromCell.HasRoadThroughEdge(direction)) {
			moveCost = 1;
		} else if (fromCell.Walled != toCell.Walled) {
			return -1;
		} else {
			moveCost = edgeType == HexEdgeType.Flat ? 5 : 10;
			moveCost +=
				toCell.UrbanLevel + toCell.FarmLevel + toCell.PlantLevel;
		}
		return moveCost;
	}

	public void Travessia(List<HexCell> path) {
		Location = path[path.Count - 1];
		caminhotravessia = path;
		StopAllCoroutines();
		StartCoroutine(Caminhotravessia());
	}

	IEnumerator Caminhotravessia() {
		Vector3 a, b, c = caminhotravessia[0].Position;
		transform.localPosition = c;
		yield return LookAt(caminhotravessia[1].Position);

		float t = Time.deltaTime * velocidadeTravessia;

		for (int i = 1; i < caminhotravessia.Count; i++) {
			a = c;
			b = caminhotravessia[i - 1].Position;
			c = (b + caminhotravessia[i].Position) * 0.5f;
			for (; t < 1f; t += Time.deltaTime * velocidadeTravessia) {
				transform.localPosition = Bezier.GetPoint(a, b, c, t);
				Vector3 d = Bezier.GetDerivative(a, b, c, t);
				d.y = 0f;
				transform.localRotation = Quaternion.LookRotation(d);
				yield return null;
			}
			t -= 1f;
		}

		a = c;
		b = caminhotravessia[caminhotravessia.Count - 1].Position;
		c = b;
		for (; t < 1f; t += Time.deltaTime * velocidadeTravessia) {
			transform.localPosition = Bezier.GetPoint(a, b, c, t);
			Vector3 d = Bezier.GetDerivative(a, b, c, t);
			d.y = 0f;
			transform.localRotation = Quaternion.LookRotation(d);
			yield return null;
		}

		transform.localPosition = location.Position;
		orientation = transform.localRotation.eulerAngles.y;

		ListPool<HexCell>.Add(caminhotravessia);
		caminhotravessia = null;
	}

	void OnEnable() {
		if (location) {
			transform.localPosition = location.Position;
		}
	}

	public static Vector3 GetDerivative(Vector3 a, Vector3 b, Vector3 c, float t) {
		return 2f * ((1f - t) * (b - a) + t * (c - b));
	}

	IEnumerator LookAt(Vector3 point) {
		point.y = transform.localPosition.y;
		Quaternion fromRotation = transform.localRotation;
		Quaternion toRotation =
			Quaternion.LookRotation(point - transform.localPosition);

		float angle = Quaternion.Angle(fromRotation, toRotation);

		if (angle > 0f) {
			float speed = rotationSpeed / angle;

			for (float t = Time.deltaTime * speed; t < 1f; t += Time.deltaTime * speed) {
				transform.localRotation =
					Quaternion.Slerp(fromRotation, toRotation, t);
				yield return null;
			}
		}

		transform.LookAt(point);
		orientation = transform.localRotation.eulerAngles.y;
	}
}
