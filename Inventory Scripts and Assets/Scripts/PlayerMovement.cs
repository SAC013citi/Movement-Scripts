using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Animator animator;
    public bool facingRight;
    public float runSpeed = 10f;
    bool isAttacking;
    bool isDashing;

    void Start (){
        facingRight = true;
        isAttacking = false;
    }
    // Update is called once per frame
    void Update()
    {
        


        animator.SetFloat("Horizontal", Input.GetAxis("Horizontal"));
        

        float horizontal = Input.GetAxis("Horizontal"); 
        flip(horizontal);

        void Attack() {
            animator.SetTrigger("Attack");
            isAttacking = true;

        }
        

        if (Input.GetKeyDown(KeyCode.L)) {
            Attack();
                
               
        }

        isAttacking = false;
        
        if (isAttacking == false ){
           float x = Input.GetAxis ("Horizontal") * Time.deltaTime * runSpeed;
           float y = Input.GetAxis ("Vertical") * Time.deltaTime * runSpeed;

           transform.Translate (x , y, 0);

        }

        

        
        
    
     
            
// Walk up Animation trigger         
 
        void Up() {
            animator.SetTrigger("Up");
        }

        void UpRelease(){
            animator.SetTrigger("UpRelease");
        }

        if (Input.GetKeyDown(KeyCode.W)) {
            Up();
            
        } else if (Input.GetKeyUp(KeyCode.W)){
            UpRelease();
           
        }



// Walk down Animation trigger         
 
        void Down() {
            animator.SetTrigger("Down");

        }

        void DownRelease(){
            animator.SetTrigger("DownRelease");
        }

        if (Input.GetKeyDown(KeyCode.S)) {
            Down();
            
        } else if (Input.GetKeyUp(KeyCode.S)){
            DownRelease();
           
        }   

// Dash Animation trigger         
 
        void Dash() {
            animator.SetTrigger("Dash");
            
        }

        void DashRelease(){
            animator.SetTrigger("DashRelease");
            
        }

        if (Input.GetKeyDown(KeyCode.K)) {
            Dash();
            
        } else if (Input.GetKeyUp(KeyCode.K)){
            DashRelease();
           
        }             


        
        

        
}
void flip (float horizontal){
            if (horizontal > 0 && !facingRight || horizontal < 0 && facingRight){
               
                facingRight = !facingRight;

                Vector3 theScale = transform.localScale;
                theScale.x *= -1;

                transform.localScale = theScale;
               
            }
        }
}

