using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AgroMove : MonoBehaviour
{
    public event Action<Transform> OnAgro = delegate { };
    private void OnTriggerEnter(Collider other)
    {
        var player = other.GetComponent<PlayerMovement>();
        if(player!=null)
        {
            OnAgro(player.transform);
            Debug.Log("Aggrod");
        }
    }
}
