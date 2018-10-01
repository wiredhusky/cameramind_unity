using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class spawn : MonoBehaviour {
    
    public MoveMove move;
    public Timer timer;
    public Animator animator;

    void objCreator(){
        RootSpawnManager.rootSpawnManager.objCreator(InGameManager.inGameManager.objType, InGameManager.inGameManager.index, 
                                                     InGameManager.inGameManager.obj, InGameManager.inGameManager.posList);
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
            RootSpawnManager.rootSpawnManager.setScale();
            RootSpawnManager.rootSpawnManager.PosSearch(InGameManager.inGameManager.posList, 
                                                        InGameManager.inGameManager.objType);
            InGameManager.inGameManager.SetStart();
            RootUIManager.rootUIManager.uiNavigation.SetActive(true);
            RootUIManager.rootUIManager.background.SetActive(true);
            animator.speed = 1;
        }        

        RootUIManager.rootUIManager.ActiveUI();
    }

    public void TimerReset()
    {
        //RootUIManager.rootUIManager.uiNavigation.SetActive(true);
        //RootUIManager.rootUIManager.background.SetActive(true);
        timer.timer.SetActive(true);
        timer.timer.transform.position = new Vector3(-7.96f, -4.38f, 0);
        timer.sec = 0;
        timer.counter = 0;
        timer.timerCounter.text = (3).ToString();
        timer.animator.SetInteger("TimerState", Timer.timerControl.counter);
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
        timer.setTimer = true;
        timer.animator.SetInteger("TimerState", Timer.timerControl.counter);
        timer.animator.speed = 1;
    }

    public void MovePrefab()
    {
        move._move = true;
    }

}
