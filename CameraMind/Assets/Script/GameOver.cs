using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour {

    Animator animator;

	// Use this for initialization
	void Start () {

        animator = gameObject.GetComponent<Animator>();
		
	}

    void PauseGameOver()
    {
        animator.speed = 0;
    }

    public void GoToMainMenu()
    {        
        SceneManager.LoadScene("MainMenu", LoadSceneMode.Additive);
        animator.speed = 1;
    }

    void DestroyMyself()
    {
        SceneManager.UnloadSceneAsync(SceneManager.GetSceneByName("GameOver"));
    }
	
}
