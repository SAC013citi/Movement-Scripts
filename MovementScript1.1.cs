using System.Collections;
using System.Collections.Generic;
using UnityEngine; 
/* Steps b4creating scripts
rename the sprite
Add component- rigid body 2D
set gravity to 0
freeze rotation
add component - new script
**/
public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;

    public Rigidbody2D rb;  // Drag in unity the rigid body component into the new component created by the rb var( they will be linked now)
    public Animator animator;

    Vector2 movement;

    Void Update()
    {
        //Input
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);
    }

    void FixedUpdate()
    {
        //movement
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }
}/*animation
go to the 'window' select 'Animation' then 'Animation'(ctl-6)
create a new folder for player animation (idle) then (walk up)
go to characters(Project) select 'walk' Drag into animamation window
change in samples to a lower number
create another folder n repeat with all walking samples
go to the animator window
go to parameters 
both as floats 
new variable will be horizontal, and the other vertical
creat a new blend tree
drag n drop character and change to the value from 0 to -1 to 1
add another float for speed
 go to unity then click on animator in the player component
 drag the animator component into it
 **/