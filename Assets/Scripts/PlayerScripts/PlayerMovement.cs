using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float playerSpeed;


    private Rigidbody2D rb2D;
    private Vector2 movementInput;

    private Animator animator;


    private void Awake()
    {
        rb2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        movePayer();

    }

    private void movePayer()
    {
        rb2D.MovePosition(rb2D.position + movementInput * playerSpeed * Time.fixedDeltaTime);
    }




    private void OnMove(InputValue inputValue)
    {
        movementInput = inputValue.Get<Vector2>();

        if(movementInput.x != 0 || movementInput.y != 0)
        {
            

            animator.SetFloat("X", movementInput.x);
            animator.SetFloat("Y", movementInput.y);

            animator.SetBool("IsWalking", true);
        }
        else {
            animator.SetBool("IsWalking", false);
        }


    }

} // Class
