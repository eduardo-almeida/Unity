﻿using System.Collections;
using UnityEngine;

public class NewMapMenu : MonoBehaviour {

	public HexGrid hexGrid;

	public HexMapGenerator mapGenerator;

	bool generateMaps = true;

	bool wrapping = true;

	public static NewMapMenu instance;

	void Awake() {
		instance = this;
	}

	public void ToggleMapGeneration (bool toggle) {
		generateMaps = toggle;
	}

	public void ToggleWrapping (bool toggle) {
		wrapping = toggle;
	}

	public void Open () {
		gameObject.SetActive(true);
		HexMapCamera.Locked = true;
	}

	public void Close () {
		gameObject.SetActive(false);
		HexMapCamera.Locked = false;
	}

	public void CreateSmallMap () {
		CreateMap(20, 15);
	}
	public IEnumerator CreateSmallMap2(LoadState loadState) {
		yield return StartCoroutine(CreateMap2(20, 15));
		//loadState.porcentagem = 75;
		//yield return null;
	}

	public void CreateMediumMap () {
		CreateMap(40, 30);
	}

	public void CreateLargeMap () {
		CreateMap(80, 60);
		//CreateMap(180, 160);
	}

	void CreateMap (int x, int z) {
		if (generateMaps) {
			mapGenerator.GenerateMap(x, z, wrapping);
		}
		else {
			hexGrid.CreateMap(x, z, wrapping);
		}
		HexMapCamera.ValidatePosition();
		Close();
	}

	public IEnumerator CreateMap2(int x, int z) {
		if (generateMaps) {
			mapGenerator.GenerateMap(x, z, wrapping);
			yield return null;
		} else {
			hexGrid.CreateMap(x, z, wrapping);
			yield return null;
		}
		HexMapCamera.ValidatePosition();
		Close();
	}
}