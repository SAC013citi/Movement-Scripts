/* code for inter acting with objects
must have Player / rigidbody2d / box collider / character controller
**/
//code for treasure chests
using System.Collections;
using System.Collections.Generic;
using UnityEngine; 

public class ChestController : MonoBehaviour
{
    public bool isOpen;
    public Animator animator;

    public void OpenChest()
    {
        if(!isOpen)
        {
            isOpen = true;
            Debug.Log("Chest is now open...");
            animator. SetBool("IsOpen", isOpen);
        }
    }
}
//code for interaction with objects i.e. a door
public class interactable : MonoBehaviour
{
  public Bool IsInRange;
  public KeyCode interactKey;
  public UnityEvent interAction;

  void start()
  {

  }  

  void Update()
  {
      if(IsInRange)//if the character is in rang to interact with object
      {
          if(Input.GetKeyDown(interactKey))
          {
              interAction.Invoke();//the triger event 
          }
      }
  }

  private void OnTriggerEnter2D(collider2D collision)
  {
      if(collision.gameObject.CompareTag("Player"))
      {
          IsInRange = true;
          collision.GetComponent<PlayerManager>().NotifyPlayer();
          Debug.Log("Player now in range");
      }
  }

  private void OnTriggerExit2D(collider2D collision)
  {
       if(collision.gameObject.CompareTag("Player"))
      {
          IsInRange = false;
          collision.GetComponent<PlayerManager>().DeNotifyPlayer();
          Debug.Log("Player now not in range");
      }
  }
}
/*now add a new component called circle collider 
check trigger to true
create 2 of em a square**/

public class PlayerManager : MonoBehaviour
{
    public int keyCount;
    public void PickUpKey()
    {
        keyCount++;
         Debug.Log("Picked up key");
    }

    public void UseKey()
    {
        keyCount--;
         Debug.Log("Used a key");
    }
    public void NotifyPlayer()
    {
        interactNotification.SetActive(true);
    }
    public void DeNotifyPlayer()
    {
        interactNotification.SetActive(false);
    }
}

//creating new script for doors

public class DoorController : MonoBehaviour
{
    public Bool isOpen;
    public Animator animator;
    public AudioClip sound;

    public void openDoor(gameObject obj)
    {
        if(!isOpen)
        {
            PlayerManager manager = obj.GetComponent<PlayerManager>();
            if(manager)
            {
                if(manager.keyCount > 0)
                {
                    isOpen = true;
                    manager.UseKey();
                    animator.setBool("IsOpen", isOpen);
                    AudioSource.PlayClipAtPoint(soundEffect, transform.position);
                    Debug.Log("Door is Unlocked");
                }
            }
        }
        else
        {
           SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        
    }
}