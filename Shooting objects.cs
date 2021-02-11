/*click on firing object(gun/blaster,etc) and object being fired(bullets/lazers) in the HIERARCHY
click on 'pixels per unit' in the INSPECTOR, and set it to the required number.
set the filter - point (no filter); set Compression to - none
click on object being fired - drag into scene - click on sorting layer - set it to - breakable
make that object a prefab - drag into object prefab folder. double click on it.
Add component - Rigidbody2d - set gravity - 0 - freeze physics - set sleeping mode - never sleep - set collision Detection - continues
add component box collider2d - check isTrigger - edit collider - resize collider
create new script in the objects folder - rename it appropriatly
**/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class firedObject : MonoBehaviour
{
    public float speed;
    public Rigidbody2d myRigidbody;

    void Start()
    {

    }

    public void Setup(Vector2 velocity, Vector3 direction)
    {
        myRigidbody.velocity = velocity.normailzed * speed;
        transform.rotation = Quaternion.Euler(direction);
    }

    public void OnTriggerEnter2D(collider2D other)
    {
        if (other.GameObject.CompareTag("enemy"))
        {
            Destroy(this.GameObject);
        }
        
    }
}



/* go into the Playermovement script **/

//create new variable under public class
public GameObject projectile; 
/* go to unity
click on the firedobject sprite - click on 'layer' - set it to new layer - player projecttile.
go back to scene - click on player - set layer to - player 
click on Edit - project settings - physics2d - decheck player projectile - player and player projectile.
and player.
click on input in the project manager - create new axis - rename it - scweapon
under the 'void update' method in the playermovement script, under the attack code **/

{
    else if(Input.GetButtonDown("scweapon") && CureentState != PlayerState.attack)etc...//dunno the rest of the code but yeah its something like this
    {
        StartCoroutine(secondAttackCo());
    }


    // below the ienumerator attack code make one for the firing the object
    private IEnumerator secondAttackCo()
    {
        
        currentState = PlayerState.attack;
        yield return null;
        Makeobj();
        yield return new WaitForSeconds(.3f);
        if (currentState != PlayerState.interact)
        {
            currentState = PlayerState.walk;
        }
    }

    private void Make /*Objectbeing thrown**/()
    {
        Vector2 temp = new Vector2(animator.Getfloat("moveX"), animator.Getfloat("moveY"));
        Objectbeingthrown obj = Instantiate(projectile, transform.position, Quaternion.identity).GetComponent<Objectbeingthrown>();
        obj.Setup(temp, chooseobjDirection());
    }
    Vector3 chooseobjDirection()
    {
        float temp = Mathf.Atan2(animator.Getfloat("moveY"), animator("moveX"))* Mathf.Rad2Deg;
        return new Vector3(0, 0, temp);
    }
    /* delet the objectbeingthrown sprite in the scene
        go to  Prefabs - click on player in the HIERARCHY - in the playermovement script drag the fired object into
        the projectile variable **/ 
        /* click on the firedobject - go to scripts - obj - drag the firedobject script into the objects components - set speed - assign the rigidbody to the script
**/
/*go to the firedboject in the prefabs - double click on it - add component - knockback script
set thrust - any number, knockback time, damage
**/
}
