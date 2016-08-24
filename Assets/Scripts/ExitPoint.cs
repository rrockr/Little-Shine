using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class ExitPoint : MonoBehaviour 
{
    public GameObject goFader;
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

    IEnumerator loadNextLevel()
    {
        yield return new WaitForSeconds(2f);

        LevelManager.iCurrentLevel++;
        SceneManager.LoadScene(LevelManager.iCurrentLevel);
    }
}
