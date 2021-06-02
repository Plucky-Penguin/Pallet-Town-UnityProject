using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public CharacterController2D controller;
    public Animator animator;
    public float runSpeed = 40f;
    float horizontalMove = 0f; // This allows you to use values in different functions
    bool jump = false;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;    // Will give a value of -1 (A) or 1 (D) when moving horizontally

        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));  //name of parameter in animator (Abs makes the value always positive (the animator needs it to be because of the way we made it and this takes the absolute value))

        // Jumping Code

        if(Input.GetButtonDown("Jump")){
            jump = true;
        }
    }

    // This one is called so many times per second (other one is everytime a frame is drawn)
    void FixedUpdate (){

        // Move our character
        controller.Move(horizontalMove * Time.fixedDeltaTime, false, jump);   // Time fixed delta allows us to move the same amount no matter how many times the function is called
        jump = false; //makes it so you don't keep jumping forever
    }
}
