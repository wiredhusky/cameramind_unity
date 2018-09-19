using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class GameOver : MonoBehaviour {

    public Animator animator;        
    public GameObject gameOverBack, reviveObj, getReviveObj;
    public Button reviveBtn;

    bool restart = false;
    bool clicked = false;
    bool mainMenu = false;
    bool revival = false;

    public string scene;
    public TextMeshProUGUI count, reviveCounter;
    
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
        UIManager.uiManager.InitGameOver();
    }    
    
    
    public void PauseGame()
    {
        animator.speed = 0;    
        /*
        if(gameObject.name == "GameOver")
        {
            SceneManager.UnloadSceneAsync(SpawnPrefab.instance.scene);
        }
        */
    }

    public void GoToMainMenu()
    {
        if (!clicked)
        {
            clicked = true;
            mainMenu = true;
            UIManager.uiManager.GoToMainMenu();
        }
    }

    public void Restart()
    {        
        if (!clicked)
        {
            clicked = true;
            restart = true;
            UIManager.uiManager.Restart();
        }
    }        

    void Revive()
    {
        UIManager.uiManager.Revive();
        revival = true;
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

    void ReviveManager()
    {
        if (revival)
        {
            TransitionControl.transitionControl.ActiveHandler();
        }
    }

    public void RevivePressed()
    {
        UIManager.uiManager.ShowRewardedAd();
    }

    void DestroyMyself()
    {
        animator.speed = 0;        

        if (!restart)
        {
            if(scene == "Time Attack" && mainMenu == false && revival == false)
            {
                Timer.timerControl.setTimer = true;
                Timer.timerControl.animator.speed = 1;
            }
            SceneManager.UnloadSceneAsync(SceneManager.GetSceneByName(gameObject.name));
        }
    }
	
}
