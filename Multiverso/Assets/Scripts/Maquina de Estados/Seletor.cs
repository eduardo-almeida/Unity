using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seletor : MonoBehaviour {
    public static Seletor instance;
    public Vector3Int position;

    private void Awake() {
        instance = this;
    }
}
