using UnityEngine;
using System.Collections;

public class Teleporter : MonoBehaviour 
{
    public GameObject goWaypoint;
    public GameObject goTeleportEffect;

    private const float fTeleportDelay = 2.0f;
    private float fCurrentDelay;


	// Use this for initialization
	void Start () 
    {

	}
	
	// Update is called once per frame
	void Update ()
    {

	}


    void OnTriggerEnter2D(Collider2D col2Dother)
    {
        if (col2Dother.tag == "Player")
        {
            fCurrentDelay = Time.time;
            goTeleportEffect.transform.position = col2Dother.transform.position;
            goTeleportEffect.SetActive(true);
        }
    }


    void OnTriggerStay2D(Collider2D col2Dother)
    {
        goTeleportEffect.transform.position = col2Dother.transform.position;

        if (col2Dother.tag == "Player" && (Time.time - fCurrentDelay) >= 2.0f)
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
            fCurrentDelay = Time.time;
        }
    }
}
