using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class Menu : MonoBehaviour 
{

	// Use this for initialization
	void Start ()
    {
	
	}
	
	// Update is called once per frame
	void Update () 
    {
	
	}

    public void LoadLevel()
    {
        SceneManager.LoadScene("Scenes/Main");
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene("Scenes/MainMenu");
    }
}
