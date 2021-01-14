using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{

    public bool playerInRange;
    public Signal context;
     

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Check if other is "Player". collision box
        if (other.CompareTag("player"))
        {
            //context.Raise();
            playerInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        // Check if other is "Player". collision box
        if (other.CompareTag("player") && !other.isTrigger)
        {
            //context.Raise();
            playerInRange = false;
        }
    }
}
