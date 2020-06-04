using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;
using static EnemyMovement;

public class EnemyMovement : MonoBehaviour
{
    public int scoreValue = 10;

    //enemyHealth
    [SerializeField]
    private int estartingHealth = 5;
    public HealthBar ehealthbar;
    private int ecurrenthealth;

    //EnemyMovememt
    private NavMeshAgent navMeshAgent;
    private Animator animator;
    private AgroMove agroMove;
    private Transform target;

    //enemyRespawnTrigger
    public delegate void EnemyKilled();
    public static event EnemyKilled OnEnemyKilled;


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

    public void OnEnable()
    {
        ecurrenthealth = estartingHealth;
        ehealthbar.SetMaxHealth(estartingHealth);
    }
    public void TakeDamage(int damageAmount)
    {
        ecurrenthealth -= damageAmount;
        ehealthbar.SetHealth(ecurrenthealth);
        if (ecurrenthealth <= 0)
            die();
    }
    public void die()
    {
        if (ecurrenthealth <= 0)
        {
            gameObject.SetActive(false);
        }
        if (OnEnemyKilled != null)
        {
            OnEnemyKilled();
        }

        ScoreManager.score += scoreValue;
    }
}
