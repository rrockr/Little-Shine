using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class clsMenu : MonoBehaviour 
{
    //Use for fade to black
    public GameObject goFader;
    private Animator animFader;

	// Use this for initialization
	void Start ()
    {
        //Get animator
        animFader = goFader.GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () 
    {
	
	}

    public void startGame()
    {
        animFader.SetTrigger("FadeToBlack");
        StartCoroutine(loadScene("Scenes/Level1"));
    }

    public void retryGame()
    {
        animFader.SetTrigger("FadeToBlack");
        StartCoroutine(loadScene("Scenes/MainMenu"));
    }

    IEnumerator loadScene(string levelName)
    {
        yield return new WaitForSeconds(2f);

        SceneManager.LoadScene(levelName);
    }
}
