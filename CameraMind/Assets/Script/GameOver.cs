using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour {

    Animator animator;    
    bool restart;
    GameObject gameOverBack;
    string scene;
    //AsyncOperation asyncOperation;

	// Use this for initialization
	void Start () {
        scene = SpawnPrefab.instance.scene;
        animator = gameObject.GetComponent<Animator>();        
        restart = false;
        gameOverBack = GameObject.FindWithTag("gameOverBack");    
    }

    void PauseGameOver()
    {
        animator.speed = 0;
        SceneManager.UnloadSceneAsync(SpawnPrefab.instance.scene);        
    }

    public void GoToMainMenu()
    {
        SceneManager.LoadSceneAsync("MainMenu", LoadSceneMode.Additive);
        animator.speed = 1;
    }

    public void Restart()
    {
        gameOverBack.transform.GetChild(0).gameObject.SetActive(true);
        animator.speed = 1;
        restart = true;
    }

    void DestroyMyself()
    {
        if (restart)
        {
            SceneManager.LoadScene(SpawnPrefab.instance.scene, LoadSceneMode.Additive);
            SceneManager.SetActiveScene(SceneManager.GetSceneByName(scene));
        }        
        SceneManager.UnloadSceneAsync(SceneManager.GetSceneByName("GameOver"));
    }
	
}
