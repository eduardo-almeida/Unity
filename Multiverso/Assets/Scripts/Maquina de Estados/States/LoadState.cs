using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;

public class LoadState : State {

    public override void Enter() {
        print("Load State");
    }

    void Update() {
        if (!EventSystem.current.IsPointerOverGameObject()) {
            if (Input.GetKeyDown(KeyCode.M)) {
                NewMapMenu.instance.CreateSmallMap();
            }
            if (Input.GetKeyDown(KeyCode.K)) {
                NewMapMenu.instance.CreateMediumMap();
            }
        }
    }
}
