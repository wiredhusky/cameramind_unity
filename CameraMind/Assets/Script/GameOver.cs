using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour {

    Animator animator;
    AsyncOperation asyncOperation;

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
        asyncOperation = SceneManager.UnloadSceneAsync(SpawnPrefab.instance.scene);
        SceneManager.LoadSceneAsync("MainMenu", LoadSceneMode.Additive);
        //Wait until ActiveScene is unloaded completely 
        /*while (!asyncOperation.isDone)
        {
            //nothing. Wait until...
        }*/
        animator.speed = 1;
    }

    void DestroyMyself()
    {
        SceneManager.UnloadSceneAsync(SceneManager.GetSceneByName("GameOver"));
    }
	
}
