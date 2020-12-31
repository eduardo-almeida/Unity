using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RPG.Movement;
using RPG.Core;

namespace RPG.Combat {
    public class Fighter : MonoBehaviour, IAction  {
        [SerializeField] float weaponRanger = 2f; 
        [SerializeField] float timeBetWeenAttack = 1f;
        [SerializeField] float weaponDamage = 8f;

        Health target;
        float timeSinceLastAttack = 0;

        private void Update() {

            timeSinceLastAttack += Time.deltaTime;
            if(target==null) return;
            if(target.IsDead()) return;

            if(!GetIsInRange())
            {
                GetComponent<Mover>().MoveTo(target.transform.position);
            } 
            else
            {
                GetComponent<Mover>().Cancel();
                AttackBehaviour();
            }
        }

        private void AttackBehaviour(){
            if(timeSinceLastAttack > timeBetWeenAttack){
                GetComponent<Animator>().SetTrigger("attack");
                timeSinceLastAttack = 0;
            }
        }

        // Animation Event
        void Hit(){
            target.TakeDamage(weaponDamage);
        }

        private bool GetIsInRange(){
            return Vector3.Distance(transform.position, target.transform.position) < weaponRanger;
        }

        public void Attack(CombatTarget combatTarget) {
            GetComponent<ActionScheduler>().StartAction(this);
            target = combatTarget.GetComponent<Health>();
        }

        public void Cancel(){
            GetComponent<Animator>().SetTrigger("stopAttack");
            target = null;
        }       

    }
}
