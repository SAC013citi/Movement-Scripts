//disable the fist enemy obj create a copy
/* add a seeker script - circle collider - add component new script
add a 'rigid body 2d' - freeze rotation -  set gravity to 0
**/

using System.Collections;
using Sysem.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class EnemyAI : MonoBehaviour
{
    public Transform target;
    public float speed = 200;
    public float nextWaypointDistance = 3f;
    public Transform EnemyAI;
    
    Path path;
    int currentWaypoint = 0;
    bool reachedEndOfPath = false;
    Seeker seeker;
    Rigidbody2D rb;

    void Start()
    {
        seeker = GetComponent<Seeker>();
        rb = GetComponent<Rigidbody2D>();
        InvokeRepeating("UpdatePath", 0f, .5f);
    }
    
    void UpdatePath()
    {
        if(seeker.IsDone())
            seeker.StartPath(rb.position, target.position, OnPathComplete);
    }
    void OnPathComplete(Path p)
    {
        Path = p;
        currentWaypoint = 0;
    } 

    void FixedUpdate()
    {
        if(path == null)
        return;

        if(currentWaypoint >= path.vectorPath.Count)
        {
            reachedEndOfPath = true;
            return;
        } else 
        {
            reachedEndOfPath = false;
        }

        Vector2 direction = ((Vector2)path.vectorPath[currentWaypoint] - rb.position).Normalized;
        Vector2 force = direction * speed * Time.deltaTime;
        rb.AddForce(force);

        float distance = Vector2.Distance(rb.position, path.vectorPath[currentWaypoint]);
        if(distance < nextWaypointDistance)
        {
            currentWaypoint++;
        }/*click on enemy - rigidbody2d - linear drag - 1.5
          click on speed - 400**/
          if(force.x >= 0.01f)
          {
              EnemyAI.localScale = new Vector3(-1f, 1f, 1f);
          }else if (force.x <= -0.01df)
          {
               EnemyAI.localScale = new Vector3(1f, 1f, 1f);
          }// click on enemyAI - drag sprite enemy into enemyAI(script component) - enemyAI
    }
}