using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameOver : MonoBehaviour {

    public Animator animator;    
    bool restart = false;
    //AsyncOperation test;
    bool clicked = false;
    public GameObject gameOverBack;
    public GameObject pauseBtns;
    public string scene;
    public TextMeshProUGUI count;
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

    private void Start()
    {
        if(gameObject.name == "GameOver")
        {
            count.text = "Level " + (SpawnPrefab.instance.index).ToString();
        }        
    }    

    void PauseGameOver()
    {
        animator.speed = 0;
        SceneManager.UnloadSceneAsync(SpawnPrefab.instance.scene);        
    }
    
    public void PauseGame()
    {
        animator.speed = 0;
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

    public void PauseRestart()
    {
        if (!clicked)
        {
            SceneManager.UnloadSceneAsync(scene);
            clicked = true;
            restart = true;
            pauseBtns.SetActive(false);
        }
        Invoke("LoadScene", 0.2f);        
    }

    public void PauseResume()
    {
        animator.speed = 1;
    }

    void LoadScene()
    {
        SceneManager.LoadScene(scene, LoadSceneMode.Additive);
        animator.speed = 1;
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
