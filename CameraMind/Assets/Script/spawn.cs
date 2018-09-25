using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class spawn : MonoBehaviour {
    
    public MoveMove move;
    public Animator animator;

    void objCreator(){
        //Debug.Log("Obj Type" + GameManager.gameManager.objType[0]);
        Debug.Log("Pos" + GameManager.gameManager.posList[0]);
        Debug.Log("Index " + GameManager.gameManager.index);
        RootSpawnManager.rootSpawnManager.objCreator(GameManager.gameManager.objType, GameManager.gameManager.index, 
                                                     GameManager.gameManager.obj, GameManager.gameManager.posList);
        Debug.Log("obj" + GameManager.gameManager.obj[0].transform.position);
    }

    public void PauseAni()
    {
        RootUIManager.rootUIManager.clicked = false;
        RootUIManager.rootUIManager.menus.SetActive(false);
        if(SceneManager.GetActiveScene().name == "SceneManager"){
            SceneManager.SetActiveScene(SceneManager.GetSceneByName(RootUIManager.rootUIManager.sceneName));
        }

        if(RootUIManager.rootUIManager.sceneName == "Time Attack"){
            UIManager.uiManager.uiPanel.SetActive(true);
            Timer.timerControl.timer.transform.position = new Vector3(-7.96f, -4.38f, 0);
            Timer.timerControl.sec = 0;
            Timer.timerControl.counter = 0;
            Timer.timerControl.timerCounter.text = (3).ToString();
            Timer.timerControl.animator.SetInteger("TimerState", Timer.timerControl.counter);
        }

        if (!RootSpawnManager.rootSpawnManager.allThingsDone)
        {
            animator.speed = 0;
            RootSpawnManager.rootSpawnManager.setScale();
            RootSpawnManager.rootSpawnManager.PosSearch(GameManager.gameManager.posList, 
                                                        GameManager.gameManager.objType);
            GameManager.gameManager.SetStart();
            UIManager.uiManager.uiPanel.SetActive(true);
            animator.speed = 1;
        }        

        UIManager.uiManager.ActiveUI();
    }


    public void ActiveCollider()
    {
        GameManager.gameManager.ActiveHandler();
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
