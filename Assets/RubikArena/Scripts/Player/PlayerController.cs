using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private InputSystem control;
    private Rigidbody rb;
    private Animator animator;

    private Vector2 moveInput; //raw input receptionn� depuis la mannette
    private float speed;

    private void Awake()
    {
        control = new InputSystem();
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        speed = 1;
    }

    private void OnEnable()
    {
        //Inscription du move
        control.Player.Move.performed += ctx => moveInput = ctx.ReadValue<Vector2>();
        control.Player.Move.canceled += ctx => moveInput = Vector2.zero;

        //Enable l'inputaction
        control.Enable();
    }

    private void OnDisable()
    {
        //Enable l'inputaction
        control.Disable();
    }

    private void Update()
        {
            transform.Translate(0, 0, moveInput.x * speed * Time.deltaTime);
            Debug.Log(moveInput);

            if (Mathf.Abs(moveInput.x) >= 0.1)
            {
                animator.SetBool("Walk", true);
            }
            else
            {
                animator.SetBool("Walk", false);
            }
        }
}