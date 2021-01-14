/*path finding system NPC
using a path finding asset
go to the Hierarchy - create empty object - rename - reset transform
add new component 'Pathfinder' - click on graphs - create new grid graph - resize using scale tool in the scene mode
check 'Use 2d physics', increase diameter - 1.5 
goto tiles/environment - middle - inspector - add new layer - assign it to the new layer(optional)
click on the Hierarchy empty obj - set obstical layer task to the desired layer - scan
hide graph
create new obj - name it - drage n drop above enemy sprite- click on enemy sprite - reset trasnform
create new component - Ai path(2D,3D)- change orientation to yAxisForward(2Dgames)
set 'pick next waypoint' to 1.3 - disable gravity
Add a new component - ai Destination setter - drag and drop player into 'target' on destination setter
go to the gizmos top right - select seeker - on enemy - check 
disable rotation ai path 
add a circle collider 2D - select sprite - add component - new script
**/
using System.Collections;
using Sysem.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class EnemyGFX : MonoBehaviour
{
    public AIPath aipath;

    void Update()
    {
        if(aipath.desiredVelocity.x >= 0.01f)
        {
            transform.localScale = new Vector3(-1f, 1f, 1f);
        }else if (aipath.desiredVelocity.x <= -0.01df)
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
        }
    }
}
/* goto the Hierarchy select sprite - drag n drop enemy into aipath