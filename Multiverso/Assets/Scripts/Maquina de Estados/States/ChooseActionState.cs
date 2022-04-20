using System.Collections;
using System.Collections.Generic;

using UnityEngine.EventSystems;
using UnityEngine;

public class ChooseActionState : State {
    int index;
    public override void Enter() {
        base.Enter();
        index = 0;
        ChangeSelector();
        inputs.OnMove += OnMove;
        inputs.OnFire += OnFire;
        machine.chooseActionPanel.MoveTo("Show");
    }

    public override void Exit() {
        base.Exit();
        inputs.OnMove -= OnMove;
        inputs.OnFire -= OnFire;
        machine.chooseActionPanel.MoveTo("Hide");
    }

    void OnMove(object sender, object args) {
        Vector3Int button = (Vector3Int)args;
        /*
        if (button == Vector3Int.left) {
            index--;
            ChangeSelector();
        } else if (button == Vector3Int.right) {
            index++;
            ChangeSelector();
        }*/
    }

    void OnFire(object sender, object args) {
        int buttom = (int)args;
        if (buttom == 1) {
            ActionButtons();
        } else if (buttom == 2) {
            machine.ChangeTo<RoamState>();
        }
    }

    void ChangeSelector() {
        if (index == -1) {
            index = machine.chooseActionBottons.Count - 1;
        } else if (index == machine.chooseActionBottons.Count) {
            index = 0;
        }
        machine.chooseActionSelector.transform.localPosition =
            machine.chooseActionBottons[index].transform.localPosition;
    }

    void ActionButtons() {
        Debug.Log("Esqueda botão");
    }
    void Update() {
        if (!EventSystem.current.IsPointerOverGameObject()) {
            if (Input.GetKeyDown("1")) {
                index = 0;
                ChangeSelector();
                return;
            }
        }
        if (!EventSystem.current.IsPointerOverGameObject()) {
            if (Input.GetKeyDown("2")) {
                index = 1;
                ChangeSelector();
                return;
            }
        }
        if (!EventSystem.current.IsPointerOverGameObject()) {
            if (Input.GetKeyDown("3")) {
                index = 2;
                ChangeSelector();
                return;
            }
        }
        if (!EventSystem.current.IsPointerOverGameObject()) {
            if (Input.GetKeyDown("4")) {
                index = 3;
                ChangeSelector();
                return;
            }
        }
    }
}
