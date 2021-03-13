using RPG.Combat;
using RPG.Movement;
using System;
using UnityEngine;

namespace RPG.Control {
    public class PlayerController : MonoBehaviour
    {

        private void Update() {
            if (InteractWithCombat()) return;
            if (InteractWithMoviment()) return;
            print("Fazendo nada");
        }

        private bool InteractWithCombat() {
            RaycastHit[] hits = Physics.RaycastAll(GetMouseRay());
            foreach(RaycastHit hit in hits) {
                CombatTarget target = hit.transform.GetComponent<CombatTarget>();
                Teleporte teleportador = hit.transform.GetComponent<Teleporte>();
                if (teleportador != null) {
                    GetComponent<Fighter>().Teleporte(target);
                }
                if (target == null) continue;

                if (Input.GetMouseButtonDown(0)) {
                    GetComponent<Fighter>().Attack(target);
                }
                return true;
            }
            return false;
        }

        private bool InteractWithMoviment()
        {
            //Ray ray = GetMouseRay();
            RaycastHit hit;
            bool hasHit = Physics.Raycast(GetMouseRay(), out hit);

            if (hasHit) {
                if (Input.GetMouseButton(0)) {
                    GetComponent<Movimentar>().StartMovimentAction(hit.point);
                }
                return true;
            }
            return false;
        }

        private static Ray GetMouseRay() {
            return Camera.main.ScreenPointToRay(Input.mousePosition);
        }
    }

}