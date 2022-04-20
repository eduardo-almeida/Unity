using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;

public class LoadState : State {

    public override void Enter() {
        //NewMapMenu.instance.Open();
        //StartCoroutine(NewMapMenu.instance.CreateSmallMap2(this));
        print("Load State");
    }

    void Teste (object sender, object args) {
        Debug.Log("MOveu");
    }

    void Update() {
        //if (!EventSystem.current.IsPointerOverGameObject()) {
            if (Input.GetKeyDown(KeyCode.M)) {
                //NewMapMenu.instance.Open();
                //StartCoroutine(NewMapMenu.instance.CreateSmallMap2(this));
                print("M");
                StateMachineController.instance.ChangeTo<ChooseActionState>();
                return;
            }
            if (Input.GetKeyDown(KeyCode.L)) {
                //NewMapMenu.instance.Open();
                NewMapMenu.instance.CreateMediumMap();
                print("L");
                return;
            }
            if (Input.GetKeyDown(KeyCode.J)) {
                print("J");
                return;
            }
            if (Input.GetKeyDown(KeyCode.H)) {
                print("H");
                return;
            }
        //}
    }
}
