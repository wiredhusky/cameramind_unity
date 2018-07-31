using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class MainMenu : MonoBehaviour {

    //public GameObject mainMenuTransition;
    public string sceneName;

    public void PlayGame()
    {
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Resume()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 2);
    }

    public void GameOver()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
    }

    public void GoToMainMenu()
    {
        SceneManager.LoadScene("Transition", LoadSceneMode.Additive);
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void SceneLoader()
    {        
        sceneName = EventSystem.current.currentSelectedGameObject.name;
        SceneManager.LoadScene("Transition", LoadSceneMode.Additive);        
    }

}
