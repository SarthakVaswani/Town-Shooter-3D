using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovemet : MonoBehaviour
{
    private NavMeshAgent navMeshAgent;
    private Animator animator;
    private AgroMove agroMove;
    private Transform target;
    
    private void Awake()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        animator = GetComponentInChildren<Animator>(); 
        agroMove = GetComponent<AgroMove>();
        agroMove.OnAgro += AgroMove_OnAgro;
    }
    private void AgroMove_OnAgro(Transform target)
    {
        this.target = target;
    }
    private void Update()
    {
        if (target != null)
        {
            navMeshAgent.SetDestination(target.transform.position);
            float currentSpeed = navMeshAgent.velocity.magnitude;
            animator.SetFloat("Speed", currentSpeed);
        }
    }
    
}
