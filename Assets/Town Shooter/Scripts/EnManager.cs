using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnManager : MonoBehaviour
{
    public Transform[] m_SpawnPoints;
    public GameObject m_EnemyPrefabs;


    void Start()
    {
        SpawnNewEnemy();
    }
    void OnEnable()
    {
        EnemyMovement.OnEnemyKilled += SpawnNewEnemy;
    }



    public void SpawnNewEnemy()
    {
     Instantiate(m_EnemyPrefabs, m_SpawnPoints[0].transform.position, Quaternion.identity);

    }
}