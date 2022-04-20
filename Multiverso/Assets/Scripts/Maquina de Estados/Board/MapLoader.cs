using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapLoader : MonoBehaviour {
    public Unit prefab;
    //Job
    //Objetos do mapa
    //localização das unidades
    public static MapLoader instance;

    void Awake() {
        instance = this;
    }   

    public void CriaUnidades() {
        GameObject holder = new GameObject("Units Holder");
    }
}
