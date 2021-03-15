using UnityEngine;
using UnityEngine.SceneManagement;
using RPG.Movement;
using RPG.Core;

namespace RPG.Combat{
    public class Fighter : MonoBehaviour, IAction {
        [SerializeField] float weaponRange = 2f;
        Transform target;

        private void Update() {
            if (target == null) return;
            if (!GetIsRange()) {
                GetComponent<Movimentar>().MoveTo(target.position);
            }
            else {
                GetComponent<Movimentar>().Cancel();
            }
        }

        private bool GetIsRange() {
            return Vector3.Distance(transform.position, target.position) < weaponRange;
        }

        public void Attack(CombatTarget combatTarget) {
            GetComponent<ActionSchedule>().StartAction(this);
            target = combatTarget.transform;
        }

        public void Cancel() {
            target = null;
        }

        public void Teleporte(CombatTarget target) {
            //SceneManager.LoadScene("Combate");
        }
    }
}
