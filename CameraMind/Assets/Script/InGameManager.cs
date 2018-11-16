﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InGameManager : MonoBehaviour {

    public static InGameManager inGameManager;

    public List<Vector3> posList = new List<Vector3>();
    public List<Vector3> oppCenterPos = new List<Vector3>();
    public List<int> objType = new List<int>();
    public List<GameObject> obj = new List<GameObject>();
    public List<Animator> animatorList = new List<Animator>();
    //public List<Renderer> rendererList = new List<Renderer>();
    public GameObject LevelTransitionPanel;
    public GameObject DanceTime;
    public GameObject unlockedObj;

    public delegate void GoToIdle();
    public event GoToIdle goIdle;
    public event GoToIdle activeCollider;
    public event GoToIdle deactiveCollider;
    public event GoToIdle enableRenderer;
    public event GoToIdle goMove;
    public event GoToIdle goRandomAni;

    public TextMeshProUGUI currentLevelText;    

    public string sceneName;
    public int index = 0;
    public int index_track = 0;
    public int index_twins = 0;
    public int index_alone = 50;
    public int index_dance = 4;
    public int index_dance_answer = 0;

    public bool turnChk = true;
    public bool trackComplete = false;
    
    public GameObject soomong_colored;

    AnimatorStateInfo currentBaseState;

    //unlock Level
    int unlockLevel;

    int chkUnlock;

    //int case0, case1, case2, case3, case4;

    private void Awake()
    {
        if(inGameManager == null){
            inGameManager = this;
        }
        sceneName = RootUIManager.rootUIManager.sceneName;
    }

    private void Start()
    {
        CountLevel();
        switch (sceneName)
        {
            case "Normal":
                chkUnlock = PlayerPrefs.GetInt("unlockHorizontal");
                Debug.Log("unlock: " + chkUnlock);
                unlockLevel = 11;
                LevelTransitionPanel.SetActive(true);
                break;            
            case "Flip Vertical":
                chkUnlock = PlayerPrefs.GetInt("unlockTime");                
                unlockLevel = 21;
                LevelTransitionPanel.SetActive(true);
                break;
            case "Chaos":
                chkUnlock = PlayerPrefs.GetInt("unlockDance");                
                unlockLevel = 31;
                LevelTransitionPanel.SetActive(true);
                break;
            case "DanceDance":
                chkUnlock = PlayerPrefs.GetInt("unlockAlone");                
                unlockLevel = 16;
                DanceTime.SetActive(true);
                break;
            case "Twins":
                chkUnlock = PlayerPrefs.GetInt("unlockVertical");                
                unlockLevel = 18;
                LevelTransitionPanel.SetActive(true);
                break;
            case "Temptation":
                chkUnlock = PlayerPrefs.GetInt("unlockTrack");                
                unlockLevel = 28;
                LevelTransitionPanel.SetActive(true);
                break;
            case "Track":
                chkUnlock = PlayerPrefs.GetInt("unlockChaos");                
                unlockLevel = 21;
                LevelTransitionPanel.SetActive(true);
                break;            
            case "Time Attack":
                chkUnlock = PlayerPrefs.GetInt("unlockTemptation");                
                unlockLevel = 26;
                LevelTransitionPanel.SetActive(true);
                break;
            case "Alone":
                chkUnlock = PlayerPrefs.GetInt("unlockTriple");                
                unlockLevel = 31;
                LevelTransitionPanel.SetActive(true);
                break;
            case "Triple": // last stage
                chkUnlock = 1;
                unlockLevel = 26;
                LevelTransitionPanel.SetActive(true);
                break;
            case "Double":
                chkUnlock = PlayerPrefs.GetInt("unlockTwins");                
                unlockLevel = 16;
                LevelTransitionPanel.SetActive(true);
                break;
            case "Horizon":
                chkUnlock = PlayerPrefs.GetInt("unlockDouble");                
                unlockLevel = 16;
                LevelTransitionPanel.SetActive(true);
                break;
        }        
    }

    public void chkUnlockStage()
    {
        if(chkUnlock == 0)
        {
            Debug.Log("HERE");
            if (index >= unlockLevel)
            {
                switch (sceneName)
                {
                    case "Normal":
                        Debug.Log("HERE");
                        chkUnlock = 1;
                        unlockedObj.SetActive(true);
                        PlayerPrefs.SetInt("unlockHorizontal", 1);
                        PlayerPrefs.Save();
                        RootUIManager.rootUIManager.objHorizon.SetActive(true);
                        RootUIManager.rootUIManager.unlockHorizon.SetActive(false);
                        break;
                    case "Flip Vertical":
                        chkUnlock = 1;
                        unlockedObj.SetActive(true);
                        PlayerPrefs.SetInt("unlockTime", 1);
                        PlayerPrefs.Save();
                        RootUIManager.rootUIManager.objTime.SetActive(true);
                        RootUIManager.rootUIManager.unlockTime.SetActive(false);
                        break;
                    case "Chaos":
                        chkUnlock = 1;
                        unlockedObj.SetActive(true);
                        PlayerPrefs.SetInt("unlockDance", 1);
                        PlayerPrefs.Save();
                        RootUIManager.rootUIManager.objDance.SetActive(true);
                        RootUIManager.rootUIManager.unlockDance.SetActive(false);
                        break;
                    case "DanceDance":
                        chkUnlock = 1;
                        unlockedObj.SetActive(true);
                        PlayerPrefs.SetInt("unlockAlone", 1);
                        PlayerPrefs.Save();
                        RootUIManager.rootUIManager.objAlone.SetActive(true);
                        RootUIManager.rootUIManager.unlockAlone.SetActive(false);
                        break;
                    case "Twins":
                        chkUnlock = 1;
                        unlockedObj.SetActive(true);
                        PlayerPrefs.SetInt("unlockVertical", 1);
                        PlayerPrefs.Save();
                        RootUIManager.rootUIManager.objVertical.SetActive(true);
                        RootUIManager.rootUIManager.unlockVertical.SetActive(false);
                        break;
                    case "Temptation":
                        chkUnlock = 1;
                        unlockedObj.SetActive(true);
                        PlayerPrefs.SetInt("unlockTrack", 1);
                        PlayerPrefs.Save();
                        RootUIManager.rootUIManager.objTrack.SetActive(true);
                        RootUIManager.rootUIManager.unlockTrack.SetActive(false);
                        break;
                    case "Track":
                        chkUnlock = 1;
                        unlockedObj.SetActive(true);
                        PlayerPrefs.SetInt("unlockChaos", 1);
                        PlayerPrefs.Save();
                        RootUIManager.rootUIManager.objChaos.SetActive(true);
                        RootUIManager.rootUIManager.unlockChaos.SetActive(false);
                        break;
                    case "Time Attack":
                        chkUnlock = 1;
                        unlockedObj.SetActive(true);
                        PlayerPrefs.SetInt("unlockTemptation", 1);
                        PlayerPrefs.Save();
                        RootUIManager.rootUIManager.objTemptation.SetActive(true);
                        RootUIManager.rootUIManager.unlockTemptation.SetActive(false);
                        break;
                    case "Alone":
                        chkUnlock = 1;
                        unlockedObj.SetActive(true);
                        PlayerPrefs.SetInt("unlockTriple", 1);
                        PlayerPrefs.Save();
                        RootUIManager.rootUIManager.objTriple.SetActive(true);
                        RootUIManager.rootUIManager.unlockTriple.SetActive(false);
                        break;
                    case "Triple":                        
                        break;
                    case "Double":
                        chkUnlock = 1;
                        unlockedObj.SetActive(true);
                        PlayerPrefs.SetInt("unlockTwins", 1);
                        PlayerPrefs.Save();
                        RootUIManager.rootUIManager.objTwins.SetActive(true);
                        RootUIManager.rootUIManager.unlockTwins.SetActive(false);
                        break;
                    case "Horizon":
                        chkUnlock = 1;
                        unlockedObj.SetActive(true);
                        PlayerPrefs.SetInt("unlockDouble", 1);
                        PlayerPrefs.Save();
                        RootUIManager.rootUIManager.objDouble.SetActive(true);
                        RootUIManager.rootUIManager.unlockDouble.SetActive(false);
                        break;
                }
            }
        }        
    }

    public void CountLevel()
    {
        currentLevelText.text = "Level " + (index + 1).ToString();
    }    

    public void EventHandler()
    {
        if (goIdle != null)
        {
            goIdle();
        }
    }

    public void ActiveHandler()
    {
        if (activeCollider != null)
        {
            activeCollider();
        }
    }

    public void DeactiveHandler()
    {
        deactiveCollider();
    }

    public void RendererHandler()
    {
        if (index == 0)
        {
            enableRenderer();
        }
    }

    public void CatDance(){
        if (goMove != null){
            goMove();
        }
    }

    public void SetRandomAni(){
        if (goRandomAni != null){
            goRandomAni();
        }
        //LevelTransitionPanel.SetActive(true);
    }

    void Update()
    {
        if (RootGameManager.rootGameManager.chkGameOver)
        {
            switch (sceneName)
            {
                case "Track":
                    currentBaseState = animatorList[index_track].GetCurrentAnimatorStateInfo(0);
                    break;
                case "DanceDance":
                    currentBaseState = animatorList[index_dance_answer].GetCurrentAnimatorStateInfo(0);
                    break;
                default:
                    currentBaseState = animatorList[index].GetCurrentAnimatorStateInfo(0);
                    break;
            }            
            
            if (currentBaseState.IsName("GameOver") || currentBaseState.IsName("GameOver0") || currentBaseState.IsName("GameOver1") || currentBaseState.IsName("GameOver2"))
            {                
                if (currentBaseState.normalizedTime > 1.0f)
                {                    
                    RootGameManager.rootGameManager.chkGameOver = false;
                    RootGameManager.rootGameManager.DoTransition(1);
                    //idle로 돌려주지 않으면 Revive하고 다시 틀렸을 때 걔를 GameOver 애니메이션을 할 수가 없음
                    switch (sceneName)
                    {
                        case "Track":
                            animatorList[index_track].SetTrigger("Origin");
                            break;
                        case "DanceDance":
                            animatorList[index_dance_answer].SetTrigger("GoBack");
                            break;
                        default:
                            animatorList[index].SetTrigger("Origin");
                            break;
                    }
                }
            }
        }

        if (trackComplete)
        {
            RootUIManager.rootUIManager.DeactiveUI();
            currentBaseState = animatorList[index].GetCurrentAnimatorStateInfo(0);
            if (currentBaseState.IsName("clicked"))
            {
                if (currentBaseState.normalizedTime > 1.0f)
                {       
                    index++;
                    index_track = 0;
                    trackComplete = false;
                    RootGameManager.rootGameManager.DoTransition(0);                    
                }
            }
        }
    }
}
