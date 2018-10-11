using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class spawn : MonoBehaviour {
    
    public MoveMove move;    
    public Animator animator;

    void objCreator(){
        RootSpawnManager.rootSpawnManager.objCreator();
    }

    public void PauseAni()
    {
        RootUIManager.rootUIManager.clicked = false;
        RootUIManager.rootUIManager.menus.SetActive(false);
        if(SceneManager.GetActiveScene().name == "SceneManager"){
            SceneManager.SetActiveScene(SceneManager.GetSceneByName(RootUIManager.rootUIManager.sceneName));
        }

        if (!RootSpawnManager.rootSpawnManager.allThingsDone)
        {
            animator.speed = 0;
            //RootSpawnManager.rootSpawnManager.setScale();
            RootSpawnManager.rootSpawnManager.PosSearch(InGameManager.inGameManager.posList, 
                                                        InGameManager.inGameManager.objType);
            RootSpawnManager.rootSpawnManager.SetStart();
            RootUIManager.rootUIManager.uiNavigation.SetActive(true);
            //RootUIManager.rootUIManager.background.SetActive(true);
            animator.speed = 1;
        }        

        RootUIManager.rootUIManager.ActiveUI();
    }

    public void TimerReset()
    {        
        Timer.timerControl.timer.SetActive(true);
        Timer.timerControl.timer.transform.position = Timer.timerControl.target;
        Timer.timerControl.sec = 0;
        Timer.timerControl.counter = 0;
        Timer.timerControl.timerCounter.text = (3).ToString();
        Timer.timerControl.animator.SetInteger("TimerState", Timer.timerControl.counter);        
    }


    public void ActiveCollider()
    {
        InGameManager.inGameManager.ActiveHandler();
    }

    public void SetObj()
    {
        gameObject.SetActive(false);
    }

    public void SetTimerActive()
    {
        Timer.timerControl.setTimer = true;
        Timer.timerControl.animator.SetInteger("TimerState", Timer.timerControl.counter);
        Timer.timerControl.animator.speed = 1;
    }

    public void MovePrefab()
    {
        move._move = true;
    }

}
