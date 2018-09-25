using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseGameOver : MonoBehaviour {

    void PauseAnimation(){
        RootUIManager.rootUIManager.animator.speed = 0;
    }

    void DeactiveMyself(){
        RootUIManager.rootUIManager.clicked = false;
        gameObject.SetActive(false);
    }

    void LoadRestart(){
        if(RootUIManager.rootUIManager.btnName == "Revive"){
            GameManager.gameManager.ActiveHandler();
        }
        if(RootUIManager.rootUIManager.btnName == "Restart"){
            SceneManager.LoadScene(RootUIManager.rootUIManager.sceneName, LoadSceneMode.Additive);
        }
    }
}
