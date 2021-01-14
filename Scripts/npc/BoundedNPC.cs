using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoundedNPC : Interactable
{ 
    private Vector3 directionVector;
    private Transform myTransform;
    public float speed;
    private Rigidbody2D myRigidbody;
    private Animator anim;
    public Collider2D bounds;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        myTransform = GetComponent<Transform>();
        myRigidbody = GetComponent<Rigidbody2D>();
        ChangeDirection();
    }

    // Update is called once per frame
    void Update()
    {
        if (!playerInRange) {
            Move();
        }
    }

    private void Move()
    {
        Vector3 temp = myTransform.position + directionVector * speed * Time.deltaTime;
        if (bounds.bounds.Contains(temp))
        {
            myRigidbody.MovePosition(temp);
        }
        else
        {
            ChangeDirection();
        }
    }

    void ChangeDirection()
    {
        int direction = Random.Range(0, 4);
        switch (direction)
        {
            case 0:
                // Walk to right
                directionVector = Vector3.right;
                break;
            case 1:
                // Walk to up
                directionVector = Vector3.up;
                break;
            case 2:
                // Walk to left
                directionVector = Vector3.left;
                break;
            case 3:
                // Walk to down
                directionVector = Vector3.down;
                break;
            default:
                break;
        }

        UpdateAnimation();
    }

    // This method changes the NPC animation based on the direction it is going.
    void UpdateAnimation()
    {
        anim.SetFloat("MoveX", directionVector.x);
        anim.SetFloat("MoveY", directionVector.y);
    }


    // This makes sure the NPC will change direction when coming in contact with a box collider
    void OnCollisionEnter2D(Collision2D other)
    {
        Vector3 temp = directionVector;
        ChangeDirection();
        int loops = 0;

        // Ensures that the NPC direction changes to prevent glitch.
        // Variable Loops ensure thay an infinte loop doesn't occur.
        while(temp == directionVector && loops < 100)
        {
            ChangeDirection();
            loops += 1;
        }

    }
}
