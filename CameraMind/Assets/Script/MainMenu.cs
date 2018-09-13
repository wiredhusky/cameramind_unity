using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class MainMenu : MonoBehaviour {
    
    //public GameObject mainMenuTransition;
    public string sceneName;
    public static MainMenu mainMenu;

    private void Awake()
    {
        if(mainMenu == null)
        {
            mainMenu = this;
        }

        if (!PlayerPrefs.HasKey("Hint"))
        {
            PlayerPrefs.SetInt("Hint", 5);
            PlayerPrefs.SetInt("Revive", 3);
            PlayerPrefs.SetInt("HighScoreNormal", 0);
            PlayerPrefs.SetInt("HighScoreAlone", 0);
            PlayerPrefs.SetInt("HighScoreChaos", 0);
            PlayerPrefs.SetInt("HighScoreDouble", 0);
            PlayerPrefs.SetInt("HighScoreHorizon", 0);
            PlayerPrefs.SetInt("HighScoreVertical", 0);
            PlayerPrefs.SetInt("HighScoreTemptation", 0);
            PlayerPrefs.SetInt("HighScoreTimeAttack", 0);
            PlayerPrefs.SetInt("HighScoreTrack", 0);
            PlayerPrefs.SetInt("HighScoreTriple", 0);
            PlayerPrefs.SetInt("HighScoreTwins", 0);
        }

        //Debug Mode
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void SceneLoader()
    {        
        sceneName = EventSystem.current.currentSelectedGameObject.name;
        SceneManager.LoadScene(sceneName, LoadSceneMode.Additive);
    }
}
