using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class enemyhealth : MonoBehaviour
{
    public int scoreValue = 10;
    [SerializeField]
    private int estartinghealth = 5;

    public HealthBar ehealthbar;
    private int ecurrenthealth;

    private void OnEnable()
    {
        ecurrenthealth = estartinghealth;
        ehealthbar.SetMaxHealth(estartinghealth);
    }
    public void TakeDamage(int damageAmount)
    {
        ecurrenthealth -= damageAmount;
        ehealthbar.SetHealth(ecurrenthealth);
        if (ecurrenthealth <= 0)
            die();
    }
    private void die()
    {
        gameObject.SetActive(false);
        ScoreManager.score += scoreValue;
    }
    


}
