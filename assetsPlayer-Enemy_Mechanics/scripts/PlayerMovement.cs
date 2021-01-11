using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Player State
public enum PlayerState
{
    idle,
    walk,
    attack,
    defend,
    interact,
    stagger
}

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D myRigidbody;
    private Vector3 change;
    private Animator animator;
    public PlayerState currentState;
    public float speed;
    public float defendStat;
    
    // Health Bar and Mechanics
    public HealthBar healthBar;
    public float currentHealth;

    void Start()
    {
        // Add movement here

        // Sets max value for the health bar.
        healthBar.SetMaxHealth((int)currentHealth);

        // By default the player will face down
        animator.SetFloat("moveX", 0);
        animator.SetFloat("moveY", -1);
    }

    void Update()
    {
        // add update movement
    
        // Updates health bar
        healthBar.SetHealth((int)currentHealth);

        // If the button is hit and the player is not already attacking attack will be true
        if (Input.GetButtonDown("attack") && currentState != PlayerState.attack && currentState != PlayerState.stagger)
        {
            StartCoroutine(AttackCo());
        }
        
        if (Input.GetButtonDown("defend") && currentState != PlayerState.defend && currentState != PlayerState.stagger)
        {
            currentState = PlayerState.defend;
            StartCoroutine(DefendCo(defendStat));
        }

        if (currentState == PlayerState.walk || currentState == PlayerState.idle || currentState == PlayerState.defend)
        {
            UpdateAnimatonAndMove();
        }
    }

    void UpdateAnimatonAndMove()
    {
        if (change != Vector3.zero)
        {
            // This is responsible for changing the players idle direction
            MoveCharacter();
            animator.SetFloat("moveX", change.x);
            animator.SetFloat("moveY", change.y);
            animator.SetBool("moving", true);
        }else
        {
            animator.SetBool("moving", false);
        }
    }

    void MoveCharacter()
    {
        change.Normalize();
        myRigidbody.MovePosition(
            transform.position + change * speed * Time.deltaTime
            );
    }

    public void Knock(float knockTime, float damage)
    {
        currentHealth -= damage;
        if (currentHealth > 0)
        {
            // Raise will activate method belonging to it example play a sound when the user takes damage.
            //         playerHealthSignal.Raise();
            StartCoroutine(KnockCo(knockTime));
        }
    }

    ///
    /// Co-routine Section
    ///

    // Handles when player attack button is active.
    private IEnumerator AttackCo()
    {
        animator.SetBool("attacking", true);
        currentState = PlayerState.attack;
        yield return null;
        animator.SetBool("attacking", false);
        yield return new WaitForSeconds(.3f);
        currentState = PlayerState.idle;
    }

    // Handles when player gets attacked by enemy.
    private IEnumerator KnockCo(float knockTime)
    {
        if (myRigidbody != null)
        {
            yield return new WaitForSeconds(knockTime);
            currentState = PlayerState.idle;
            myRigidbody.velocity = Vector2.zero;
        }
    }

    // Handles when player attack button is active.
    private IEnumerator DefendCo(float defendPercentage)
    {
        yield return new WaitForSeconds(defendPercentage);
        currentState = PlayerState.idle;
        myRigidbody.velocity = Vector2.zero;
    }
}
