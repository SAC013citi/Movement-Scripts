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
    
    Path path;
    int currentWaypoint = 0;
    bool reachedEndOfPath = false;
    Seeker seeker;
    Rigidbody2D rb;

    void Start()
    {
        seeker = GetComponent<Seeker>();
        rb = GetComponent<Rigidbody2D>();
        seeker.StartPath(rb.position, target.position, OnPathComplete);
    }
    void OnPathComplete(Path p)
    {
       if(!p.error)
       {
         path = p;
         currentWaypoint = 0;
       }
    }
}
