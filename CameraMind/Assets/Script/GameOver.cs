using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour {

    Animator animator;    
    bool restart;
    //AsyncOperation test;
    bool clicked;
    GameObject gameOverBack;
    string scene;
    //AsyncOperation asyncOperation;

	// Use this for initialization
	void Start () {
        scene = SpawnPrefab.instance.scene;
        animator = gameObject.GetComponent<Animator>();        
        restart = false;
        clicked = false;
        gameOverBack = GameObject.FindWithTag("gameOverBack");    
    }

    void PauseGameOver()
    {
        animator.speed = 0;
        SceneManager.UnloadSceneAsync(SpawnPrefab.instance.scene);        
    }

    public void GoToMainMenu()
    {
        if (!clicked)
        {
            SceneManager.LoadScene("MainMenu", LoadSceneMode.Additive);
            animator.speed = 1;
            clicked = true;
        }        
    }

    public void Restart()
    {        
        if (!clicked)
        {
            //test = SceneManager.LoadSceneAsync(scene, LoadSceneMode.Additive);
            SceneManager.LoadScene(scene, LoadSceneMode.Additive);
            animator.speed = 1;
            //SceneManager.SetActiveScene(SceneManager.GetSceneByName(scene));
            clicked = true;
            
        }
        //gameOverBack.transform.GetChild(0).gameObject.SetActive(true);
                
        //restart = true;
    }

    void DestroyMyself()
    {        
       /*if (restart)
        {
            SceneManager.LoadScene(scene, LoadSceneMode.Additive);            
            SceneManager.SetActiveScene(SceneManager.GetSceneByName(scene));
            Debug.Log("Scene Name: " + scene);
        }*/
        SceneManager.UnloadSceneAsync(SceneManager.GetSceneByName("GameOver"));
        //Debug.Log(SceneManager.GetActiveScene().name);
    }
	
}
