using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float playerSpeed;

    //[SerializeField] private float rotationSpeed;

    private Rigidbody2D rb2D;
    private Vector2 movementInput;

    //private Vector2 smoothedMovementInput;
    //private Vector2 movementInputSmoothVelocity;

    private void Awake()
    {
        rb2D = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        movePayer();
        //SetPlayerVelocity();
        //RotateInDirectionOfInput();
    }

    private void movePayer()
    {
        rb2D.MovePosition(rb2D.position + movementInput * playerSpeed * Time.fixedDeltaTime);
    }

    //private void SetPlayerVelocity()
    //{
    //    smoothedMovementInput = Vector2.SmoothDamp(
    //        smoothedMovementInput,
    //        movementInput,
    //        ref movementInputSmoothVelocity,
    //        0.1f);

    //    rb2D.velocity = smoothedMovementInput * playerSpeed;
    //}

    //private void RotateInDirectionOfInput()
    //{
    //    if(movementInput != Vector2.zero)
    //    {
    //        Quaternion targetRotation = Quaternion.LookRotation(transform.forward, smoothedMovementInput);
    //        Quaternion rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);

    //        rb2D.MoveRotation(rotation);

    //    }
    //}


    private void OnMove(InputValue inputValue)
    {
        movementInput = inputValue.Get<Vector2>();
    }

} // Class
