using UnityEngine;
using System.Collections;

public class Switch : MonoBehaviour 
{
    public GameObject goTarget;
    public float fSwitchTimer = 0;
    public bool bAppear = false;

    private Animator animSwitch;
    private float fCurrentTime;
    private AudioSource audsrcSwitchTriggered;

	void Start () 
    {
        animSwitch = GetComponent<Animator>();
        audsrcSwitchTriggered = GetComponent<AudioSource>();
	}
	
	void Update () 
    {
        if (animSwitch.GetBool("bIsSwitchTriggered") && fSwitchTimer > 0)
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

                animSwitch.SetBool("bIsSwitchTriggered", false);
            }
        }
            
	}

    void OnTriggerEnter2D(Collider2D col2Dother)
    {
        if (animSwitch.GetBool("bIsSwitchTriggered"))
        {
            return;
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

            animSwitch.SetBool("bIsSwitchTriggered", true);

            if (fSwitchTimer > 0)
            {
                fCurrentTime = Time.time;
            }

            audsrcSwitchTriggered.Play();
        }
    }
}
