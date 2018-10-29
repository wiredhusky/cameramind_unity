﻿using System.Collections;
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
        if(SceneManager.GetActiveScene().name == "SceneManager"){
            RootUIManager.rootUIManager.menus.SetActive(false);
            SceneManager.SetActiveScene(SceneManager.GetSceneByName(RootUIManager.rootUIManager.sceneName));
        }

        if (!RootSpawnManager.rootSpawnManager.allThingsDone)
        {
            animator.speed = 0;

            switch(RootUIManager.rootUIManager.sceneName){
                case "Alone":
                    RootSpawnManager.rootSpawnManager.setScale(RootSpawnManager.rootSpawnManager.soomong_colored);
                    RootSpawnManager.rootSpawnManager.PosSearch(InGameManager.inGameManager.posList,
                                                        InGameManager.inGameManager.objType);
                    RootSpawnManager.rootSpawnManager.InstantiateObj(RootSpawnManager.rootSpawnManager.soomong_colored, 
                                                                     InGameManager.inGameManager.posList.Count);
                    break;
                default:
                    RootSpawnManager.rootSpawnManager.setScale(RootSpawnManager.rootSpawnManager.soomong_15);
                    RootSpawnManager.rootSpawnManager.PosSearch(InGameManager.inGameManager.posList,
                                                        InGameManager.inGameManager.objType);
                    RootSpawnManager.rootSpawnManager.InstantiateObj(RootSpawnManager.rootSpawnManager.soomong_15, 
                                                                     InGameManager.inGameManager.posList.Count);
                    break;
            }
            RootUIManager.rootUIManager.uiNavigation.SetActive(true);
            //RootUIManager.rootUIManager.background.SetActive(true);
            animator.speed = 1;
        }        

        RootUIManager.rootUIManager.ActiveUI();
    }

    public void PauseAniDance()
    {
        RootUIManager.rootUIManager.clicked = false;
        if (SceneManager.GetActiveScene().name == "SceneManager")
        {
            RootUIManager.rootUIManager.menus.SetActive(false);
            SceneManager.SetActiveScene(SceneManager.GetSceneByName(RootUIManager.rootUIManager.sceneName));
        }
        if (!RootSpawnManager.rootSpawnManager.allThingsDone){
            animator.speed = 0;
            RootSpawnManager.rootSpawnManager.setScale(RootSpawnManager.rootSpawnManager.cat);
            RootSpawnManager.rootSpawnManager.PosSearchDance(InGameManager.inGameManager.posList, 
                                                             InGameManager.inGameManager.objType);
            RootSpawnManager.rootSpawnManager.InstantiateObj(RootSpawnManager.rootSpawnManager.cat, 
                                                             InGameManager.inGameManager.posList.Count);
            RootUIManager.rootUIManager.uiNavigation.SetActive(true);
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

    public void CatMove(){
        //InGameManager.inGameManager.CatDance();   
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
