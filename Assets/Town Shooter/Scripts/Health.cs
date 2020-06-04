using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField]
    private int startingHealth = 5;

    public HealthBar healthbar;
    private int currentHealth;

    private void OnEnable()
    {
        currentHealth = startingHealth;
        healthbar.SetMaxHealth(startingHealth);
    }
    public void TakeDamage(int damageAmount)
    {
        currentHealth -= damageAmount;
        healthbar.SetHealth(currentHealth);
        if(currentHealth<=0)
            die();
    }
    private void die()
    {
        gameObject.SetActive(false);

    }
    }
