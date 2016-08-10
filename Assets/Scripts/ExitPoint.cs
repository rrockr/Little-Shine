using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class ExitPoint : MonoBehaviour 
{

	// Use this for initialization
	void Start () 
    {
	
	}
	
	// Update is called once per frame
	void Update () 
    {
	
	}

    void OnTriggerEnter2D(Collider2D obj)
    {
        if (obj.tag == "Player")
        {
            SceneManager.LoadScene("Scenes/GameEnd");
        }
    }
}
