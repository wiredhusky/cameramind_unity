using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class GameOver : MonoBehaviour {

    public Animator animator, animatorObj;    
    bool restart = false;
    bool clicked = false;
    bool mainMenu = false;
    public GameObject gameOverBack;
    public Button reviveBtn;
    int revive;
    
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
        if(gameObject.name == "GameOver")
        {
            revive = PlayerPrefs.GetInt("Revive");
            count.text = "Level " + (SpawnPrefab.instance.index).ToString();
            reviveCounter.text = "Revive x " + revive.ToString();
        }

        if(revive == 0)
        {
            reviveBtn.interactable = false;
        }
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

    public void Revive()
    {
        reviveBtn.interactable = false;
        revive--;
        reviveCounter.text = "Revive x " + revive.ToString();
        PlayerPrefs.SetInt("Revive", revive);
        PlayerPrefs.Save();
        animator.speed = 1;
        switch (SpawnPrefab.instance.scene)
        {
            case "Track":
                animatorObj = SpawnPrefab.instance.obj[SpawnPrefab.instance.index_track].GetComponent<Animator>();
                animatorObj.SetTrigger("Hint");
                break;
            case "Alone":
                animatorObj = SpawnPrefab.instance.obj[SpawnPrefab.instance.index_alone].GetComponent<Animator>();
                animatorObj.SetTrigger("Hint");
                break;
            default:
                animatorObj = SpawnPrefab.instance.obj[SpawnPrefab.instance.index].GetComponent<Animator>();
                animatorObj.SetTrigger("Hint");
                break;
        }        
    }

    public void GoToMainMenu()
    {
        if (!clicked)
        {
            clicked = true;
            mainMenu = true;
            SceneManager.UnloadSceneAsync(scene);
            SceneManager.LoadScene("MainMenu", LoadSceneMode.Additive);
            animator.speed = 1;      
        }        
    }

    public void Restart()
    {        
        if (!clicked)
        {
            clicked = true;
            restart = true;
            gameOverBack.SetActive(true);

            SceneManager.UnloadSceneAsync(scene);
            animator.speed = 1;
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
            if(scene == "Time Attack" && mainMenu == false)
            {
                Timer.timerControl.setTimer = true;
                Timer.timerControl.animator.speed = 1;
            }
            SceneManager.UnloadSceneAsync(SceneManager.GetSceneByName(gameObject.name));
        }
    }
	
}
