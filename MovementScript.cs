using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public CharacterController2D controller;// each time we call this controller it references the controller variables in unity allowing us to move the sprites

    public float runspeed = 40f; // the speed at which the sprite moves

    float horizontalMove = 0f; // the axis it moves on (x-axis)

    bool jump = false; // the jump variable

    bool crouch = false; // the crouching variable

//called once per frame
    void Update () {
       horizontalMove = Input.GetAxisRaw("Horizontal") * runspeed; //indicates that the character how fast it should move 
       if (Input.GetButtonDown("Jump"))
       {
           jump = true;// if the button used for jumping is pressed('space bar') then the charater jumps
       }

       if(Input.GetButtonDown("Crouch"))
       {
           crouch = true;
       }else if (Input.GetButtonUp("Crouch")) //if statement for whether or not the crouch button is pressed 
       {
           crouch = false;
       }
    }

    void FixedUpdate (){
        //move our charater
        controller.Move(horizontalMove * Time.FixedDeltaTime, crouch, jump);
        jump = false;// makes sure that the character does not keep jumping
        
    }
}