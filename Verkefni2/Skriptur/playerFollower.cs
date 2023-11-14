using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class playerFollower : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform player;
    //Skilgreinir vectorstaðsetningu sem er stillanleg með x,y,z hnitum.
    public Vector3 offset;
    private Space offsetPositionSpace = Space.Self;
    private bool lookAt = true;
    // Update is called once per frame
    void Update()
    {
        //Lætur cameru elta leikmann.
        if (offsetPositionSpace==Space.Self)
        {
            transform.position =player.TransformPoint(offset);
        }
        else
        {
           transform.position = player.position + offset;
  
        }

        // stillir rotation
        if (lookAt)
        {
            transform.LookAt(player);
        }
        else
        {
            transform.rotation = player.rotation;
        }

    }
  
}

