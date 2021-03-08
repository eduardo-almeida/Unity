using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Movimentar : MonoBehaviour
{
    [SerializeField] Transform target;
    void Update() {
        UpdateAnimator();
    }

    private void UpdateAnimator() {
        Vector3 velocity = GetComponent<NavMeshAgent>().velocity;
        Vector3 localVelocity = transform.InverseTransformDirection(velocity);
        float speed = localVelocity.z;
        GetComponent<Animator>().SetFloat("ForwardSpeed", speed);
    }    

    public void MoveTo(Vector3 destination) {
        GetComponent<NavMeshAgent>().destination = destination;
    }
}
