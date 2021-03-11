using RPG.Movement;
using System;
using UnityEngine;

namespace RPG.Control {
    public class PlayerController : MonoBehaviour
    {

        private void Update()
        {
            InteractWithCombat();
            InteractWithMoviment();
        }

        private void InteractWithCombat()
        {
            
        }

        private void InteractWithMoviment()
        {
            if (Input.GetMouseButton(0))
            {
                MoveToCursor();
            }
        }

        private void MoveToCursor()
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            bool hasHit = Physics.Raycast(ray, out hit);

            if (hasHit)
            {
                GetComponent<Movimentar>().MoveTo(hit.point);
            }
        }
    }

}