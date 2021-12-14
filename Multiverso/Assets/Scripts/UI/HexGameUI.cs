using UnityEngine;
using UnityEngine.EventSystems;

public class HexGameUI : MonoBehaviour {

	public HexGrid grid;

	HexCell currentCell;

	HexUnit selectedUnit;

	UnidadeHex unidadeSelecionada;

	public void SetEditMode (bool toggle) {
		enabled = !toggle;
		grid.ShowUI(!toggle);
		grid.ClearPath();
		if (toggle) {
			Shader.EnableKeyword("HEX_MAP_EDIT_MODE");
		}
		else {
			Shader.DisableKeyword("HEX_MAP_EDIT_MODE");
		}
	}

	void Update () {
		if (!EventSystem.current.IsPointerOverGameObject()) {
			if (Input.GetMouseButtonDown(0)) {
				DoSelection();
			}
			else if (selectedUnit) {
				if (Input.GetMouseButtonDown(1)) {
					DoMove();
				}
				else {
					DoPathfinding();
				}
			} else if (unidadeSelecionada) {
				if (Input.GetMouseButtonDown(1)) {
					DoMove();
				} else {
					DoPathfinding();
				}
			}
		}
	}

	void DoSelection () {
		grid.ClearPath();
		UpdateCurrentCell();
		if (currentCell) {
			//selectedUnit = currentCell.Unit;
			unidadeSelecionada = currentCell.Unidade;
		}
	}

	void DoPathfinding () {
		if (UpdateCurrentCell()) {
			//if (currentCell && selectedUnit.IsValidDestination(currentCell)) {
			//	grid.FindPath(selectedUnit.Location, currentCell, selectedUnit);
			//} 
			//if (currentCell && unidadeSelecionada.IsValidDestination(currentCell)) {
			//	grid.FindPath(unidadeSelecionada.Location, currentCell, selectedUnit);
			//}
			if (currentCell) {
				grid.EncontreCaminho(unidadeSelecionada.Location, currentCell, unidadeSelecionada);
			} else {
				grid.ClearPath();
			}
		}
	}

	void DoMove () {
		if (grid.HasPath) {
			unidadeSelecionada.Travessia(grid.GetPath());
			//unidadeSelecionada.Location = currentCell;
			grid.ClearPath();
		}
	}

	bool UpdateCurrentCell () {
		HexCell cell =
			grid.GetCell(Camera.main.ScreenPointToRay(Input.mousePosition));
		if (cell != currentCell) {
			currentCell = cell;
			return true;
		}
		return false;
	}

}