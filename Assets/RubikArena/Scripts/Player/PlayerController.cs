using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private InputSystem control;
    private Rigidbody rb;

    private Vector2 moveInput; //raw input receptionn� depuis la mannette
    private float speed;

    private void Start()
    {
        control = new InputSystem();
        rb = GetComponent<Rigidbody>();
        speed = 1;
    }

    private void OnEnable()
    {
        //Inscription du move
        control.Player.Move.performed += ctx => moveInput = ctx.ReadValue<Vector2>();
        control.Player.Move.canceled += ctx => moveInput = Vector2.zero;

        /*//Inscription du jump
        control.Player.Jump.performed += ctx => Jump();

        //Inscription du jump
        control.Player.Dash.performed += ctx => Dash();*/

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
            transform.Translate(moveInput.x * speed * Time.deltaTime, 0, 0);
        }
}
