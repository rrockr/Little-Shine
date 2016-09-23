using UnityEngine;
using System.Collections;

public class clsSwitch : MonoBehaviour 
{
    public GameObject goTarget;     //Target for switch to make appear/disappear
    public float fSwitchTimer = 0;  //If 0, does nothing, otherwise goTarget will only appear/disappear for set amount of time
    public bool bAppear = false;    //If true, goTarget will appear instead of disappearing

    private Animator animSwitch;    //Although Switch has no animations, it has a transition from green(not pressed) to red(pressed)
    private float fCurrentTime;     //If Switch has a timer, note current time
    private AudioSource audsrcSwitchTriggered;

	void Start () 
    {
        animSwitch = GetComponent<Animator>();
        audsrcSwitchTriggered = GetComponent<AudioSource>();
	}
	
	void Update () 
    {
        if (animSwitch.GetBool("bIsSwitchTriggered") && fSwitchTimer > 0) //Make goTarget appear/disappear and check if there is a timer involved
        {
            if ((Time.time - fCurrentTime) >= fSwitchTimer)
            {

                if (bAppear)
                {
                    goTarget.SetActive(false);
                }
                else
                {
                    goTarget.SetActive(true);
                }

                animSwitch.SetBool("bIsSwitchTriggered", false); //Change state of switch from red to green
            }
        }
            
	}

    void OnTriggerEnter2D(Collider2D col2Dother)
    {
        if (animSwitch.GetBool("bIsSwitchTriggered"))
        {
            return; //Prevent the switch from being triggered twice in a row
        }
        else
        {
            if (bAppear)
            {
                goTarget.SetActive(true);
            }
            else
            {
                goTarget.SetActive(false);
            }

            animSwitch.SetBool("bIsSwitchTriggered", true); //Change state of switch from green to red

            if (fSwitchTimer > 0)
            {
                fCurrentTime = Time.time;  //Start recording time spent
            }

            audsrcSwitchTriggered.Play();
        }
    }
}
