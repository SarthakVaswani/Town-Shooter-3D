using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFire : MonoBehaviour
{

    [SerializeField]
    private ParticleSystem muzzleParticle;

    [SerializeField]
    private AudioSource gunFireSource;

    [SerializeField]
    private float attackRefreshRate=1.5f;

    private AgroMove agroMove;
    private Health healthTarget;
    private float attackTimer;

    private void Awake()
    {
        agroMove = GetComponent<AgroMove>();
        agroMove.OnAgro += AgroMove_OnAgro;
    }

    private void AgroMove_OnAgro(Transform target)
    {
        Health health = target.GetComponent<Health>();
        if(health!=null)
        {
            healthTarget = health;
        }
    }

    void Update()
    {
      if(healthTarget!=null)
        {
            attackTimer += Time.deltaTime;
            if(CanAttack())
            {
                
                Attack();
                
            }
        }
    }

    private void Attack()
    {

        muzzleParticle.Play();
        gunFireSource.Play();
        attackTimer = 0;
        healthTarget.TakeDamage(1);

    }

    private bool CanAttack()
    {

        return attackTimer >= attackRefreshRate;
    }
}
