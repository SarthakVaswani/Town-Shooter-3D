using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private CharacterController characterController;
    private Animator animator;

    [SerializeField]
    private float formoveSpeed = 7.5f;
    [SerializeField]
    private float backmoveSpeed = 3;
    [SerializeField]
    private float turnSpeed= 150;

    private void Awake()
    {
        characterController = GetComponent<CharacterController>();
        animator = GetComponentInChildren<Animator>();
    }

    private void Update()
    {
        var horizontal = Input.GetAxis("Mouse X");
        var vertical = Input.GetAxis("Vertical");

        var movement = new Vector3(horizontal, 0, vertical);

        animator.SetFloat("Speed", vertical);
        transform.Rotate(Vector3.up, horizontal * turnSpeed * Time.deltaTime);

        if (vertical != 0)
        {
            float moveSpeedToUse = (vertical > 0) ? formoveSpeed : backmoveSpeed;
            characterController.SimpleMove(transform.forward*moveSpeedToUse*vertical);
        }

    }
}
