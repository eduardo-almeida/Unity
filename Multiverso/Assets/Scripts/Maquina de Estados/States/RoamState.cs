using System.Collections;
using System.Collections.Generic;

using UnityEngine.EventSystems;
using UnityEngine;

public class RoamState : State {
    public override void Enter() {
        base.Enter();
        inputs.OnMove += OnMove;
        inputs.OnFire += OnFire;
    }

    public override void Exit() {
        base.Exit();
        inputs.OnMove -= OnMove;
        inputs.OnFire -= OnFire;
    }

    void OnMove(object sender, object args) {
        Vector3Int input = (Vector3Int)args;
        Debug.Log("Moveu: " + input);
    }
    void OnFire(object sender, object args) {
        int buttom = (int)args;
        if (buttom == 1) {

        } else if (buttom == 2) {
            machine.ChangeTo<ChooseActionState>();
        }
    }

    void Update() {
        if (!EventSystem.current.IsPointerOverGameObject()) {
            if (Input.GetKeyDown(KeyCode.T)) {
                //NewMapMenu.instance.Open();
                //StartCoroutine(NewMapMenu.instance.CreateSmallMap2(this));
                print("T");
                return;
            }
            if (Input.GetKeyDown(KeyCode.Y)) {
                print("Y");
                return;
            }
            if (Input.GetKeyDown(KeyCode.G)) {
                print("G");
                machine.ChangeTo<LoadState>();
                return;
            }
        }
    }
}
