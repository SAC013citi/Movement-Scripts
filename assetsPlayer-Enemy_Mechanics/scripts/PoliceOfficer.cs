using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
    This script will inherit everything from the "Enemy.cs" script.
    This achieved by "public class PoliceOfficer : Enemy" as opposed to
    public class PoliceOfficer : MonoBehaviour
*/

public class PoliceOfficer : Enemy
{
    private Rigidbody2D myRigidbody;
    public Transform target;
    public float chaseRadius;
    public float attackRadius;
    public Transform homePosition;

    // Start is called before the first frame update
    void Start()
    {
        currentState = EnemyState.idle;
        myRigidbody = GetComponent<Rigidbody2D>();
        target = GameObject.FindWithTag("player").transform;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        CheckDistance();
    }

    void CheckDistance()
    {
        if(Vector3.Distance(target.position, transform.position) <= chaseRadius && Vector3.Distance(target.position, transform.position) > attackRadius)
        {
            // Once the enemy is staggered it will begin moving.
            if(currentState == EnemyState.idle || currentState == EnemyState.walk && currentState != EnemyState.stagger)
            {
                transform.position = Vector3.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);   
            }
            ChangeState(EnemyState.walk);
        }else
        {
            ChangeState(EnemyState.idle);
        }
        
    }

    // Method compares the state passed in to the current state. If the states are different it updates the state.
    private void ChangeState(EnemyState newState)
    {
        if(currentState != newState)
        {
            currentState = newState;
        }
    }
}
