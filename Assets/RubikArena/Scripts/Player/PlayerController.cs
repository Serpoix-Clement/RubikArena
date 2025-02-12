using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private InputSystem control;
    private Rigidbody rb;
    private Animator animator;
    private bool isGrounded;
    public LayerMask groundLayer;
    private float groundCheckDistance = 0.2f;

    private Vector2 moveInput; //raw input receptionn� depuis la mannette
    public float speed;
    public float jumpForce;

    private void Awake()
    {
        control = new InputSystem();
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        //Inscription du move
        control.Player.Move.performed += ctx => moveInput = ctx.ReadValue<Vector2>();
        control.Player.Move.canceled += ctx => moveInput = Vector2.zero;

        //Inscription du jump
        control.Player.Jump.performed += ctx => Jump();

        //Enable l'inputaction
        control.Enable();
    }

    private void Jump()
    {
        if (isGrounded)
        {
            rb.AddForce(new Vector3(0, 1, 0) * jumpForce, ForceMode.Impulse);
            animator.SetBool("Jump", true);
        }
    }

    private void OnDisable()
    {
        //Enable l'inputaction
        control.Disable();
    }

    private void Update()
    {
        CheckGrounded();

        transform.Translate(0, 0, moveInput.x * speed * Time.deltaTime);

        if (Mathf.Abs(moveInput.x) >= 0.1)
        {
            animator.SetBool("Walk", true);
        }
        else
        {
            animator.SetBool("Walk", false);
        }
    }

     public void CheckGrounded()
        {
            if (Physics.Raycast(new Vector3(transform.position.x, transform.position.y - 0.4f, transform.position.z), Vector3.down, groundCheckDistance, groundLayer))
            {
                // Oui, je suis sur le sol
                isGrounded = true;
                Debug.DrawRay(new Vector3(transform.position.x, transform.position.y - 0.4f, transform.position.z), Vector3.down * groundCheckDistance, Color.green);
                animator.SetBool("Jump", false);
            }
            else
            {
                Debug.Log("air");
                // Non, je suis dans les airs
                isGrounded = false;
                Debug.DrawRay(new Vector3(transform.position.x, transform.position.y - 0.4f, transform.position.z), Vector3.down * groundCheckDistance, Color.red);
                animator.SetBool("Jump", true);
            }
        }

}