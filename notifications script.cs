/*click on GameObject - 3D/2D object - any Shape
click on character - rightclick - ui - canvas - click on canvas - ui - text (enter the text in the text box)
decrease font size, font types etc. disable the text on canvas
create new c# script - rename it - open it**/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour {
    public GameObject uiObject;
    public GameObject cube/*Shape**/;
    void start(){
        uiObject.SetActive(false);
    }
    void OntriggerEnter(Collider other){
        if(other.tag=="Player"){
            uiObject.SetActive(true);
        }
    }
    void Updtae(){

    }
    void OntriggerExit(Collider other){
        uiObject.SetActive(false);
       
    }
}
/*click on the shape in the hierarchy - drag the script below the components - drag in the text from the 
hierarchy into the uiobject var that was created
take the trigger obj(shape) - drag into var created in the script
check mesh renderer
check box collider is trigger **/