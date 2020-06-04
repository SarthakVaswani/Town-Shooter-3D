using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class camera : MonoBehaviour
{
    [SerializeField]
    private float senstivity = 1f;

    private CinemachineComposer composer;
   

    private void Start()
    {
        composer = GetComponent<CinemachineVirtualCamera>().GetCinemachineComponent<CinemachineComposer>();
        }

    
    private void Update()
    {
        float vertical = Input.GetAxis("Mouse Y") * senstivity;
        composer.m_TrackedObjectOffset.y += vertical;
        composer.m_TrackedObjectOffset.y = Mathf.Clamp(composer.m_TrackedObjectOffset.y, -5, 5); 
    }
}
