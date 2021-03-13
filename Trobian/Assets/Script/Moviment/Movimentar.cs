using RPG.Combat;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace RPG.Movement{
    public class Movimentar : MonoBehaviour {
        [SerializeField] Transform target;
        NavMeshAgent navMeshAgent;

        private void Start() {
            navMeshAgent = GetComponent<NavMeshAgent>();
        }

        void Update() {
            UpdateAnimator();
        }

        public void StartMovimentAction(Vector3 destination) {
            GetComponent<Fighter>().Cancel();
            MoveTo(destination);
        }

        public void MoveTo(Vector3 destination) {
            navMeshAgent.destination = destination;
            navMeshAgent.isStopped = false;
        }

        public void Parar() {
            navMeshAgent.isStopped = true;
        }

        private void UpdateAnimator() {
            Vector3 velocity = navMeshAgent.velocity;
            Vector3 localVelocity = transform.InverseTransformDirection(velocity);
            float speed = localVelocity.z;
            GetComponent<Animator>().SetFloat("ForwardSpeed", speed);
        }



    }
}
