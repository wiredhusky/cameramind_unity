using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverTest : MonoBehaviour {
        
    public GameObject gameOverBackPanel;
    public GameObject activeScenePanel;
    public Animator animator;
    
    bool restart = false, mainMenu = false;

	public void PauseGameOver()
    {
        animator.speed = 0;
    }

    public void GoToMainMenu()
    {
        mainMenu = true;
        activeScenePanel.GetComponent<Renderer>().enabled = false;        
        SceneManager.LoadScene("MainMenu", LoadSceneMode.Additive);
        animator.speed = 1;
    }

    public void Restart()
    {
        restart = true;
        gameOverBackPanel.SetActive(true);
        animator.speed = 1;
    }

    public void LoadNextScene()
    {        
        if (restart == true)
        {            
            SceneManager.LoadScene(SpawnPrefab.instance.scene, LoadSceneMode.Additive);                        
        }
        if(mainMenu == true)
        {
            SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene());
        }
        gameObject.SetActive(false);
    }
    
}
