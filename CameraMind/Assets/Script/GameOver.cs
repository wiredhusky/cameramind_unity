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
    //public GameObject pauseBtns;
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
            clicked = true;
            switch (gameObject.name)
            {
                case "GameOver":
                    SceneManager.LoadScene("MainMenu", LoadSceneMode.Additive);
                    animator.speed = 1;
                    break;
                case "Pause":
                    SceneManager.UnloadSceneAsync(scene);
                    SceneManager.LoadScene("MainMenu", LoadSceneMode.Additive);
                    animator.speed = 1;
                    break;
            }                        
        }        
    }

    public void Restart()
    {        
        if (!clicked)
        {
            clicked = true;
            restart = true;
            gameOverBack.SetActive(true);

            switch (gameObject.name)
            {
                case "GameOver":
                    SceneManager.LoadScene(scene, LoadSceneMode.Additive);
                    animator.speed = 1;
                    break;
                case "Pause":
                    animator.speed = 1;
                    SceneManager.UnloadSceneAsync(scene);
                    //pauseBtns.SetActive(false);
                    SceneManager.LoadScene(scene, LoadSceneMode.Additive);                    
                    break;
            }            
        }
    }    

    public void PauseResume()
    {
        animator.speed = 1;
    }

    void LoadScene()
    {
        //animator.speed = 1;
        SceneManager.LoadScene(scene, LoadSceneMode.Additive);        
    }

    void DestroyMyself()
    {        
        if (!restart)
        {
            Debug.Log(gameObject.name);
            switch (gameObject.name)
            {
                case "GameOver":
                    SceneManager.UnloadSceneAsync(SceneManager.GetSceneByName("GameOver"));
                    break;
                case "Pause":
                    SceneManager.UnloadSceneAsync(SceneManager.GetSceneByName("Pause"));
                    break;
                default:
                    break;
            }            
        }                
    }
	
}
