using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour {

    public Animator animator;    
    bool restart = false;
    //AsyncOperation test;
    bool clicked = false;
    public GameObject gameOverBack;
    public string scene;
    //AsyncOperation asyncOperation;

    public static GameOver gameOver;

    // Use this for initialization
    private void Awake()
    {
        if(gameOver == null)
        {
            gameOver = this;
        }
        scene = SpawnPrefab.instance.scene;
    }

    /*
    void Start () {
        
        //animator = gameObject.GetComponent<Animator>();        
        restart = false;
        clicked = false;
        //gameOverBack = GameObject.FindWithTag("gameOverBack");    
    }*/

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
            //SpawnPrefab.instance.setScene(scene);
            //Debug.Log("Current Scene: " + scene);
            //SceneManager.SetActiveScene(SceneManager.GetSceneByName(scene));
            clicked = true;
            restart = true;
            //gameOverBack.transform.GetChild(0).gameObject.SetActive(true);
            gameOverBack.SetActive(true);
            animator.speed = 1;            
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
        if (!restart)
        {
            SceneManager.UnloadSceneAsync(SceneManager.GetSceneByName("GameOver"));
        }        
        //Debug.Log(SceneManager.GetActiveScene().name);
    }
	
}
