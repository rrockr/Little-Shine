using UnityEngine;
using System.Collections;

public class clsTeleporter : MonoBehaviour 
{
    public GameObject goWaypoint;          //Teleporter Destination
    public GameObject goTeleportEffect;    //Special effects to inform player he or she is being teleported

    private const float fTeleportDelay = 2.0f;  //Time taken to teleport player, does not vary
    private float fCurrentDelay;                //Current amount of time player has spent in teleporter

    void OnTriggerEnter2D(Collider2D col2Dother)
    {
        if (col2Dother.tag == "Player")
        {
            fCurrentDelay = Time.time;  //Start timer
            goTeleportEffect.transform.position = col2Dother.transform.position;
            goTeleportEffect.SetActive(true);  //Start special effect
        }
    }


    void OnTriggerStay2D(Collider2D col2Dother)
    {
        goTeleportEffect.transform.position = col2Dother.transform.position;

        if (col2Dother.tag == "Player" && (Time.time - fCurrentDelay) >= 2.0f) //Once the player has spent enough time in teleporter, move player
        {
            col2Dother.transform.position = goWaypoint.transform.position;
            fCurrentDelay = Time.time;
        }
    }

    void OnTriggerExit2D(Collider2D col2Dother)  
    {
        goTeleportEffect.SetActive(false);

        if (col2Dother.tag == "Player")
        {
            fCurrentDelay = Time.time;  //If player leaves before being teleported, reset time spent
        }
    }
}
