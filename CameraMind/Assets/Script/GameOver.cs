using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameOver : MonoBehaviour {

    public Animator animator;    
    bool restart = false;
    bool clicked = false;
    public GameObject gameOverBack;
    
    public string scene;
    public TextMeshProUGUI count;
    
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
    
    public void PauseGame()
    {
        animator.speed = 0;        
        if(gameObject.name == "GameOver")
        {
            SceneManager.UnloadSceneAsync(SpawnPrefab.instance.scene);
        }
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
                    //SceneManager.LoadScene(scene, LoadSceneMode.Additive);
                    animator.speed = 1;
                    break;
                case "Pause":                    
                    SceneManager.UnloadSceneAsync(scene);
                    animator.speed = 1;
                    //pauseBtns.SetActive(false);                    
                    break;
            }            
        }
    }        

    public void PauseResume()
    {
        if (!clicked)
        {
            animator.speed = 1;
            clicked = true;
        }        
    }

    void LoadScene()
    {
        if (restart)
        {
            SceneManager.LoadScene(scene, LoadSceneMode.Additive);
        }
    }

    void DestroyMyself()
    {
        animator.speed = 0;
        if (!restart)
        {
            if(scene == "Time Attack")
            {
                Timer.timerControl.setTimer = true;
                Timer.timerControl.animator.speed = 1;
            }
            SceneManager.UnloadSceneAsync(SceneManager.GetSceneByName(gameObject.name));
        }
    }
	
}
