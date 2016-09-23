using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class clsExitPoint : MonoBehaviour 
{
    public GameObject goFader;  //Image object required to FadetoBlack/FadetoClear
    private Animator animFader;


	// Use this for initialization
	void Start () 
    {
        animFader = goFader.GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () 
    {
	
	}

    void OnTriggerEnter2D(Collider2D obj)
    {
        if (obj.tag == "Player")    
        {
            animFader.SetTrigger("FadeToBlack");
            StartCoroutine(loadNextLevel());
        }
    }

    IEnumerator loadNextLevel() //Wait 2 seconds before starting next level to give goFader time to play animation
    {
        yield return new WaitForSeconds(2f);

        clsLevelManager.iCurrentLevel++;
        SceneManager.LoadScene(clsLevelManager.iCurrentLevel);
    }
}
