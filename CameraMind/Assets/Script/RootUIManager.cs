using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using TMPro;
using UnityEngine.UI;
using UnityEngine.Advertisements;
using DG.Tweening;

public class RootUIManager : MonoBehaviour {

    private const string rewarded_video_id = "rewardedVideo";

    public static RootUIManager rootUIManager;
    public GameObject gamePanel;
    //public GameObject background;
    public GameObject reviveBtnObj, getReviveBtnObj, resumeBtnObj;
    public GameObject particle, hintParticle;
    public GameObject eventSystem;
    public GameObject menus;
    public GameObject topBackground;
    public GameObject uiNavigation;
    public TextMeshProUGUI currentLevelText, reviveCountText, title, hintCountText, getFreeHints, getRevives;
    public string sceneName, btnName;
    public Animator animator;
    public Button reviveBtn, getReviveBtn;
    int hintCount, reviveCount;
    int curHighScore;
    int totalTimeHintMin, totalTimeHintSec;
    int isCoroutineHint, isCoroutineRevive;
    string lastTime;
    int time;

    //tutorial
    //public GameObject tutorialBackground, tutorialObj, popUpPanel;
    public GameObject popUpPanel;
    public string tutorialName;
    //public Image tutorialImg;

    //highScore Text
    public TextMeshProUGUI highScoreNormal, highScoreHorizontal, highScoreDouble, highScoreTwins, highScoreVertical, highScoreChaos,
        highScoreDance, highScoreTemptation, highScoreTrack, highScoreTime, highScoreAlone, highScoreTriple;

    //menu unlock or not    
    public GameObject objAlone, objChaos, objDance, objDouble, objHorizon, objVertical, objTemptation,
        objTime, objTrack, objTriple, objTwins;
    public GameObject unlockAlone, unlockChaos, unlockDance, unlockDouble, unlockHorizon, unlockVertical, unlockTemptation,
        unlockTime, unlockTrack, unlockTriple, unlockTwins;

    //public GameObject cat;

    Coroutine startCoroutineHint, startCoroutineRevive;    

    //uiBtns    
    public Button pauseBtn, hintBtn, getHintBtn;
    public GameObject hintBtnObj, getHintBtnObj;

    //protect double click
    public bool clicked;

    public GameObject gameOverUnlockImg, gameOverBtns, levelCompleteBtns, inGameUnlockObj;
    public TextMeshProUGUI talkingCat;
    Image unlockImg; //공통으로 사용 talking cat이랑 unlock이랑
    Image inGameUnlockImg;

    public int buildIndex;

    System.DateTime lastDateTime;
    System.TimeSpan compareTime;
    int coroutineHintDuration = 30, coroutineReviveDuration = 30;

    //level Transition
    public GameObject levelTransition, levelTransitionImgObj;
    Image levelTransitionImg;
    public TextMeshProUGUI levelCount;
    //Sequence transitionSquence;

    public GameObject posCalculator;

    Vector3 startPos, destPos;

    private void Awake()
    {
        if(rootUIManager == null){
            rootUIManager = this;
        }

        if (!PlayerPrefs.HasKey("Hint"))
        {
            PlayerPrefs.SetInt("Hint", 3);
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
            PlayerPrefs.SetInt("HighScoreDance", 0);
            PlayerPrefs.SetInt("GetReviveCounter", 0);
            PlayerPrefs.SetInt("GetHintCounter", 0);
            PlayerPrefs.SetInt("IsRunningCoroutineHint", 0);
            PlayerPrefs.SetInt("IsRunningCoroutineRevive", 0);
            PlayerPrefs.SetInt("RemainHintDuration", 30);
            PlayerPrefs.SetInt("RemainReviveDuration", 30);
            PlayerPrefs.SetString("StartTimeCoroutineHint", null);
            PlayerPrefs.SetString("StartTimeCoroutineRevive", null);
            PlayerPrefs.SetString("HintPressedTime", null);
            PlayerPrefs.SetString("RevivePressedTime", null);
            PlayerPrefs.SetInt("LeftTimeHint", 30);
            PlayerPrefs.SetInt("LeftTimeRevive", 30);
            PlayerPrefs.SetInt("unlockHorizontal", 0);
            PlayerPrefs.SetInt("unlockVertical", 0);
            PlayerPrefs.SetInt("unlockChaos", 0);
            PlayerPrefs.SetInt("unlockDance", 0);
            PlayerPrefs.SetInt("unlockTwins", 0);
            PlayerPrefs.SetInt("unlockTemptation", 0);
            PlayerPrefs.SetInt("unlockTrack", 0);
            PlayerPrefs.SetInt("unlockDouble", 0);
            PlayerPrefs.SetInt("unlockTime", 0);
            PlayerPrefs.SetInt("unlockAlone", 0);            
            PlayerPrefs.SetInt("unlockTriple", 0);
            PlayerPrefs.Save();
        }

        isCoroutineHint = PlayerPrefs.GetInt("IsRunningCoroutineHint");
        isCoroutineRevive = PlayerPrefs.GetInt("IsRunningCoroutineRevive");             

        if (isCoroutineHint == 1)
        {
            //Application on Focus는 시작할 때는 동작 안함            
            lastTime = PlayerPrefs.GetString("HintPressedTime");
            Debug.Log("Start Time: " + lastTime);
            lastDateTime = System.DateTime.Parse(lastTime);
            compareTime = System.DateTime.Now - lastDateTime;
            time = (int)compareTime.TotalSeconds;
            Debug.Log("Time: " + time);
            if (time >= coroutineHintDuration)
            {
                PlayerPrefs.SetInt("IsRunningCoroutineHint", 0);
                PlayerPrefs.Save();                
            }
            else
            {
                getHintBtn.interactable = false;                
                startCoroutineHint = StartCoroutine(GetHintCounter(coroutineHintDuration - time));                
            }
        }

        if (isCoroutineRevive == 1)
        {
            lastTime = PlayerPrefs.GetString("RevivePressedTime");
            lastDateTime = System.DateTime.Parse(lastTime);
            compareTime = System.DateTime.Now - lastDateTime;
            time = (int)compareTime.TotalSeconds;
            if (time >= coroutineReviveDuration)
            {
                PlayerPrefs.SetInt("IsRunningCoroutineRevive", 0);
                PlayerPrefs.Save();
            }
            else
            {
                getReviveBtn.interactable = false;                
                startCoroutineRevive = StartCoroutine(GetReviveCounter(coroutineReviveDuration - time));                
            }
        }
    }

    private void Start()
    {        
        particle = Instantiate(hintParticle) as GameObject;
        particle.SetActive(false);
        clicked = false;
        InitScene();
        unlockImg = gameOverUnlockImg.GetComponent<Image>();
        inGameUnlockImg = inGameUnlockObj.GetComponent<Image>();
        levelTransitionImg = levelTransitionImgObj.GetComponent<Image>();
        Debug.Log("position: " + levelTransition.transform.position);

        destPos = posCalculator.transform.position;
        startPos = levelTransition.transform.position;
        //tutorialImg = tutorialObj.GetComponent<Image>();
    }

    IEnumerator StayTransition(float pauseTime)
    {
        yield return new WaitForSeconds(pauseTime);
        RootSpawnManager.rootSpawnManager.objCreator();
        levelTransition.transform.DOMove(startPos, 0.5f).SetEase(Ease.OutCubic).OnComplete(DoOutComplete);
    }

    IEnumerator GetReviveCounter(int totalSec)
    {
        PlayerPrefs.SetInt("IsRunningCoroutineRevive", 1);
        PlayerPrefs.SetInt("LeftTimeRevive", totalSec);
        isCoroutineRevive = PlayerPrefs.GetInt("IsRunningCoroutineRevive");
        PlayerPrefs.SetString("StartTimeCoroutineRevive", System.DateTime.Now.ToString());
        PlayerPrefs.Save();        
        while (true)
        {
            totalTimeHintMin = totalSec / 60;
            totalTimeHintSec = totalSec % 60;
            if (totalTimeHintMin == 0 && totalTimeHintSec == 0)
            {
                StopCoroutine(startCoroutineRevive);
                getReviveBtn.interactable = true;
                getRevives.text = "Get Free Revive";
                PlayerPrefs.SetInt("IsRunningCoroutineRevive", 0);
                isCoroutineRevive = PlayerPrefs.GetInt("IsRunningCoroutineRevive");
                PlayerPrefs.Save();
            }
            else
            {
                getRevives.text = string.Format("{0}", totalTimeHintMin) + " : " + string.Format("{0:00}", totalTimeHintSec);
                totalSec--;                
            }
            yield return new WaitForSeconds(1);
        }        
    }

    IEnumerator GetHintCounter(int totalSec)
    {        
        PlayerPrefs.SetInt("IsRunningCoroutineHint", 1);
        PlayerPrefs.SetInt("LeftTimeHint", totalSec);
        isCoroutineHint = PlayerPrefs.GetInt("IsRunningCoroutineHint");
        PlayerPrefs.SetString("StartTimeCoroutineHint", System.DateTime.Now.ToString());
        PlayerPrefs.Save();
        while (true)
        {
            totalTimeHintMin = totalSec / 60;
            totalTimeHintSec = totalSec % 60;            
            if(totalTimeHintMin == 0 && totalTimeHintSec == 0)
            {
                StopCoroutine(startCoroutineHint);
                getHintBtn.interactable = true;
                getFreeHints.text = "Get Free Hints";
                PlayerPrefs.SetInt("IsRunningCoroutineHint", 0);
                isCoroutineHint = PlayerPrefs.GetInt("IsRunningCoroutineHint");
                PlayerPrefs.Save();
            }
            else
            {
                getFreeHints.text = string.Format("{0}", totalTimeHintMin) + " : " + string.Format("{0:00}", totalTimeHintSec);
                totalSec--;                
            }
            yield return new WaitForSeconds(1);
        }
    }

    public void InitScene(){

        int highScore;
        int chkUnlock;
        PlayerPrefs.SetInt("unlockTriple", 0);

        //related to Hint Button
        hintCount = PlayerPrefs.GetInt("Hint");
        reviveCount = PlayerPrefs.GetInt("Revive");
        hintCountText.text = "x " + hintCount.ToString();

        if (hintCount == 0)
        {
            hintBtnObj.SetActive(false);
            getHintBtnObj.SetActive(true);            
        }

        //it's about recording HighScore
        highScore = PlayerPrefs.GetInt("HighScoreNormal");
        highScoreNormal.text = "High Score: " + highScore;
        highScore = PlayerPrefs.GetInt("HighScoreAlone");
        highScoreAlone.text = "High Score: " + highScore;
        highScore = PlayerPrefs.GetInt("HighScoreChaos");
        highScoreChaos.text = "High Score: " + highScore;
        highScore = PlayerPrefs.GetInt("HighScoreDance");
        highScoreDance.text = "High Score: " + highScore;
        highScore = PlayerPrefs.GetInt("HighScoreDouble");
        highScoreDouble.text = "High Score: " + highScore;
        highScore = PlayerPrefs.GetInt("HighScoreHorizon");
        highScoreHorizontal.text = "High Score: " + highScore;
        highScore = PlayerPrefs.GetInt("HighScoreVertical");
        highScoreVertical.text = "High Score: " + highScore;
        highScore = PlayerPrefs.GetInt("HighScoreTemptation");
        highScoreTemptation.text = "High Score: " + highScore;
        highScore = PlayerPrefs.GetInt("HighScoreTimeAttack");
        highScoreTime.text = "High Score: " + highScore;
        highScore = PlayerPrefs.GetInt("HighScoreTrack");
        highScoreTrack.text = "High Score: " + highScore;
        highScore = PlayerPrefs.GetInt("HighScoreTriple");
        highScoreTriple.text = "High Score: " + highScore;
        highScore = PlayerPrefs.GetInt("HighScoreTwins");
        highScoreTwins.text = "High Score: " + highScore;

        //Alone unlock or not
        chkUnlock = PlayerPrefs.GetInt("unlockAlone");
        if(chkUnlock == 1)
        {
            unlockAlone.SetActive(false);
            objAlone.SetActive(true);
        }
        //Chaos unlock or not
        chkUnlock = PlayerPrefs.GetInt("unlockChaos");
        if (chkUnlock == 1)
        {
            unlockChaos.SetActive(false);
            objChaos.SetActive(true);
        }
        //Dance
        chkUnlock = PlayerPrefs.GetInt("unlockDance");
        if (chkUnlock == 1)
        {
            unlockDance.SetActive(false);
            objDance.SetActive(true);
        }
        //Double
        chkUnlock = PlayerPrefs.GetInt("unlockDouble");
        if (chkUnlock == 1)
        {
            unlockDouble.SetActive(false);
            objDouble.SetActive(true);
        }
        //Horizon        
        chkUnlock = PlayerPrefs.GetInt("unlockHorizontal");
        if (chkUnlock == 1)
        {
            unlockHorizon.SetActive(false);
            objHorizon.SetActive(true);
        }
        //Vertical
        chkUnlock = PlayerPrefs.GetInt("unlockVertical");
        if (chkUnlock == 1)
        {
            unlockVertical.SetActive(false);
            objVertical.SetActive(true);
        }
        //Temptation
        chkUnlock = PlayerPrefs.GetInt("unlockTemptation");
        if (chkUnlock == 1)
        {
            unlockTemptation.SetActive(false);
            objTemptation.SetActive(true);
        }
        //Time
        chkUnlock = PlayerPrefs.GetInt("unlockTime");
        if (chkUnlock == 1)
        {
            unlockTime.SetActive(false);
            objTime.SetActive(true);
        }
        //Track
        chkUnlock = PlayerPrefs.GetInt("unlockTrack");
        if (chkUnlock == 1)
        {
            unlockTrack.SetActive(false);
            objTrack.SetActive(true);
        }
        //Triple
        chkUnlock = PlayerPrefs.GetInt("unlockTriple");
        if (chkUnlock == 1)
        {
            unlockTriple.SetActive(false);
            objTriple.SetActive(true);
        }
        //Twins
        chkUnlock = PlayerPrefs.GetInt("unlockTwins");
        if (chkUnlock == 1)
        {
            unlockTwins.SetActive(false);
            objTwins.SetActive(true);
        }
    }

    public void ActivePauseGameOver(int type, int index)
    {        
        if (!clicked)
        {
            clicked = true;
            switch (type)
            {
                case 0: // pause
                    title.text = "Pause";
                    gameOverBtns.SetActive(true);
                    levelCompleteBtns.SetActive(false);
                    resumeBtnObj.SetActive(true);
                    reviveBtnObj.SetActive(false);
                    getReviveBtnObj.SetActive(false);
                    ImageChanger(0);
                    talkingCat.text = "take a rest!";
                    currentLevelText.text = "Level " + index.ToString();
                    gamePanel.transform.DOMove(destPos, 0.5f).SetEase(Ease.OutCubic).OnComplete(PauseComplete);
                    //gamePanel.SetActive(true);
                    break;
                case 1: // gameOver
                    gameOverBtns.SetActive(true);
                    levelCompleteBtns.SetActive(false);
                    title.text = "Game Over";
                    resumeBtnObj.SetActive(false);
                    reviveCount = PlayerPrefs.GetInt("Revive");
                    if (ChkHighScore())
                    {
                        currentLevelText.text = "New High Score " + index.ToString();
                    }
                    else
                    {
                        currentLevelText.text = "Level " + index.ToString();
                    }
                    reviveCountText.text = "Revive x " + reviveCount.ToString();
                    if (reviveCount == 0)
                    {
                        reviveBtnObj.SetActive(false);
                        getReviveBtnObj.SetActive(true);
                    }
                    else
                    {
                        reviveBtnObj.SetActive(true);
                        getReviveBtnObj.SetActive(false);
                    }

                    if (InGameManager.inGameManager.unlockEvent)
                    {
                        //gameOverUnlockObj.SetActive(true);
                        ImageChanger(1);
                        talkingCat.text = "is unlocked";
                        InGameManager.inGameManager.unlockEvent = false;
                    }
                    else
                    {
                        ImageChanger(0);
                        GameOverChat();
                    }
                    gamePanel.transform.DOMove(destPos, 0.5f).SetEase(Ease.OutCubic).OnComplete(PauseComplete);
                    break;
                case 2: // level complete
                    gameOverBtns.SetActive(false);
                    levelCompleteBtns.SetActive(true);
                    title.text = "Level Complete";
                    
                    if (ChkHighScore())
                    {
                        currentLevelText.text = "New High Score " + index.ToString();
                    }
                    else
                    {
                        currentLevelText.text = "Level " + index.ToString();
                    }

                    if (InGameManager.inGameManager.unlockEvent)
                    {
                        //gameOverUnlockObj.SetActive(true);
                        ImageChanger(1);                        
                        talkingCat.text = "is unlocked";
                        InGameManager.inGameManager.unlockEvent = false;
                    }
                    else
                    {
                        ImageChanger(2);
                        talkingCat.text = "The Cat God is Pleased";
                    }
                    gamePanel.transform.DOMove(destPos, 0.5f).SetEase(Ease.OutCubic);
                    break;
            }
        }
    }

    void PauseComplete()
    {
        clicked = false;
    }

    public void ImageChanger(int option)
    {
        string objName;
        int buildIndex_unlock;
        //int buildIndex;
        switch (option)
        {
            case 0: //pause
                objName = "img/" + buildIndex.ToString();
                unlockImg.sprite = Resources.Load<Sprite>(objName);
                Debug.Log(objName);
                break;
            case 1: //unlock event
                buildIndex_unlock = buildIndex + 1;
                objName = "img/" + buildIndex_unlock.ToString();
                unlockImg.sprite = Resources.Load<Sprite>(objName);
                break;
            case 2: //level complete
                objName = "img/" + "catGod";
                unlockImg.sprite = Resources.Load<Sprite>(objName);
                break;
            case 3: //unlock event in game notification
                buildIndex_unlock = buildIndex + 1;
                objName = "img/" + buildIndex_unlock.ToString();
                inGameUnlockImg.sprite = Resources.Load<Sprite>(objName);
                break;
            case 4: //level transition img changer
                objName = "img/" + buildIndex.ToString() + "_transition";
                levelTransitionImg.sprite = Resources.Load<Sprite>(objName);
                break;
        }        
    }

    void GameOverChat()
    {
        int evaluation;
        evaluation = InGameManager.inGameManager.index / 5;
        switch (evaluation)
        {
            case 0:
                talkingCat.text = "Your power of memory is like an EARTHWORM";
                break;
            case 1:
                talkingCat.text = "";
                break;
            case 2:
                talkingCat.text = "";
                break;
            case 3:
                talkingCat.text = "";
                break;
            case 4:
                talkingCat.text = "";
                break;
            case 5:
                talkingCat.text = "";
                break;
            case 6:
                talkingCat.text = "";
                break;
            case 7:
                talkingCat.text = "";
                break;
            case 8:
                talkingCat.text = "";
                break;
            case 9:
                talkingCat.text = "";
                break;
            case 10:
                talkingCat.text = "";
                break;
            case 11:
                talkingCat.text = "";
                break;
            case 12:
                talkingCat.text = "";
                break;
            case 13:
                talkingCat.text = "";
                break;
            case 14:
                talkingCat.text = "";
                break;
            case 15:
                talkingCat.text = "";
                break;
            case 16:
                talkingCat.text = "";
                break;
            default:
                talkingCat.text = "";
                break;
        }
    }

    bool ChkHighScore()
    {
        if (curHighScore < InGameManager.inGameManager.index)
        {
            curHighScore = InGameManager.inGameManager.index;
            switch (sceneName)
            {
                case "Normal":
                    PlayerPrefs.SetInt("HighScoreNormal", curHighScore);
                    PlayerPrefs.Save();
                    highScoreNormal.text = "High Score: " + curHighScore;
                    break;
                case "Double":
                    PlayerPrefs.SetInt("HighScoreDouble", curHighScore);
                    PlayerPrefs.Save();
                    highScoreDouble.text = "High Score: " + curHighScore;
                    break;
                case "Flip Horizon":
                    PlayerPrefs.SetInt("HighScoreHorizon", curHighScore);
                    PlayerPrefs.Save();
                    highScoreHorizontal.text = "High Score: " + curHighScore;
                    break;
                case "Temptation":
                    PlayerPrefs.SetInt("HighScoreTemptation", curHighScore);
                    PlayerPrefs.Save();
                    highScoreTemptation.text = "High Score: " + curHighScore;
                    break;
                case "Twins":
                    PlayerPrefs.SetInt("HighScoreTwins", curHighScore);
                    PlayerPrefs.Save();
                    highScoreTwins.text = "High Score: " + curHighScore;
                    break;
                case "Triple":
                    PlayerPrefs.SetInt("HighScoreTriple", curHighScore);
                    PlayerPrefs.Save();
                    highScoreTriple.text = "High Score: " + curHighScore;
                    break;
                case "Flip Vertical":
                    PlayerPrefs.SetInt("HighScoreVertical", curHighScore);
                    PlayerPrefs.Save();
                    highScoreVertical.text = "High Score: " + curHighScore;
                    break;
                case "Alone":
                    PlayerPrefs.SetInt("HighScoreAlone", curHighScore);
                    PlayerPrefs.Save();
                    highScoreAlone.text = "High Score: " + curHighScore;
                    break;
                case "Track":
                    PlayerPrefs.SetInt("HighScoreTrack", curHighScore);
                    PlayerPrefs.Save();
                    highScoreTrack.text = "High Score: " + curHighScore;
                    break;
                case "Chaos":
                    PlayerPrefs.SetInt("HighScoreChaos", curHighScore);
                    PlayerPrefs.Save();
                    highScoreChaos.text = "High Score: " + curHighScore;
                    break;
                case "Time Attack":
                    PlayerPrefs.SetInt("HighScoreTimeAttack", curHighScore);
                    PlayerPrefs.Save();
                    highScoreTime.text = "High Score: " + curHighScore;
                    break;
                case "DanceDance":
                    PlayerPrefs.SetInt("HighScoreDance", curHighScore);
                    PlayerPrefs.Save();
                    highScoreDance.text = "High Score: " + curHighScore;
                    break;
            }
            return true;
        }
        else
        {
            return false;
        }
    }

    /*
    public void PauseGamePanel(){
        animator.speed = 0;
    }
    */

    public void Resume(){
        if(!clicked){
            clicked = true;
            btnName = EventSystem.current.currentSelectedGameObject.name;
            gamePanel.transform.DOMove(startPos, 0.5f).SetEase(Ease.OutCubic).OnComplete(PauseOutComplete);
        }
    }

    void PauseOutComplete()
    {
        clicked = false;
        if (sceneName == "Time Attack")
        {
            Timer.timerControl.setTimer = true;
            Timer.timerControl.animator.speed = 1;
        }

        if (btnName == "Revive")
        {
            Debug.Log("Enter");
            InGameManager.inGameManager.ActiveHandler();
        }
        if (btnName == "Restart")
        {
            SceneManager.LoadScene(sceneName, LoadSceneMode.Additive);
        }
    }

    public void Restart(){        
        if(!clicked){
            clicked = true;
            btnName = EventSystem.current.currentSelectedGameObject.name;            
            SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene());        
            uiNavigation.SetActive(false);
            gamePanel.transform.DOMove(startPos, 0.5f).SetEase(Ease.OutCubic).OnComplete(PauseOutComplete);
            RootSpawnManager.rootSpawnManager.allThingsDone = false;
            RootSpawnManager.rootSpawnManager.exceptCase = 5;
        }
    }
    
    public void MainMenu(){
        if(!clicked){
            clicked = true;
            btnName = EventSystem.current.currentSelectedGameObject.name;
            SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene());
            menus.SetActive(true);
            topBackground.SetActive(true);
            uiNavigation.SetActive(false);
            gamePanel.transform.DOMove(startPos, 0.5f).SetEase(Ease.OutCubic).OnComplete(PauseComplete);
            RootSpawnManager.rootSpawnManager.allThingsDone = false;
            RootSpawnManager.rootSpawnManager.exceptCase = 5;
        }
    }

    public void Revive(){        
        if (!clicked)
        {
            clicked = true;
            btnName = EventSystem.current.currentSelectedGameObject.name;
            Debug.Log(btnName);
            reviveCount--;
            reviveCountText.text = "Revive x " + reviveCount.ToString();
            PlayerPrefs.SetInt("Revive", reviveCount);
            PlayerPrefs.Save();

            if(reviveCount == 0)
            {
                int chkCoroutine;
                chkCoroutine = PlayerPrefs.GetInt("GetReviveCounter");
                reviveBtnObj.SetActive(false);
                getReviveBtnObj.SetActive(true);
                if (chkCoroutine == 0)
                {
                    PlayerPrefs.SetInt("GetReviveCounter", 1);
                }
                else
                {
                    getReviveBtn.interactable = false;
                    startCoroutineRevive = StartCoroutine(GetReviveCounter(30));
                    PlayerPrefs.SetString("RevivePressedTime", System.DateTime.Now.ToString());
                    PlayerPrefs.Save();
                }                
            }

            gamePanel.transform.DOMove(startPos, 0.5f).SetEase(Ease.OutCubic).OnComplete(PauseOutComplete);

            switch (sceneName)
            {
                case "Track":
                    particle.SetActive(true);
                    particle.transform.position = InGameManager.inGameManager.obj[InGameManager.inGameManager.index_track].transform.position;
                    break;
                case "Alone":
                    particle.SetActive(true);
                    particle.transform.position = InGameManager.inGameManager.obj[InGameManager.inGameManager.index_alone].transform.position;
                    break;
                case "Time Attack":
                    Timer.timerControl.timer.transform.position = Timer.timerControl.target;
                    Timer.timerControl.sec = 12;
                    Timer.timerControl.counter = 0;
                    Timer.timerControl.timerCounter.text = 12.ToString("N2");
                    Timer.timerControl.animator.SetInteger("TimerState", Timer.timerControl.counter);
                    particle.SetActive(true);
                    particle.transform.position = InGameManager.inGameManager.obj[InGameManager.inGameManager.index].transform.position;
                    break;
                default:
                    particle.SetActive(true);
                    particle.transform.position = InGameManager.inGameManager.obj[InGameManager.inGameManager.index].transform.position;
                    break;
            }
        }
    }

    public void Hint(){                
        hintCount--;
        PlayerPrefs.SetInt("Hint", hintCount);
        PlayerPrefs.Save();
        hintCountText.text = "x " + hintCount.ToString();

        if (sceneName == "Time Attack")
        {
            Timer.timerControl.setTimer = false;
            Timer.timerControl.animator.speed = 0;
        }

        if(hintCount == 0){
            int chkCoroutine;
            hintBtnObj.SetActive(false);
            chkCoroutine = PlayerPrefs.GetInt("GetHintCounter");
            getHintBtnObj.SetActive(true);
            if (chkCoroutine == 0)
            {
                //getHintBtn.interactable = true;
                PlayerPrefs.SetInt("GetHintCounter", 1);
            }
            else
            {                
                getHintBtn.interactable = false;
                startCoroutineHint = StartCoroutine(GetHintCounter(30));
                PlayerPrefs.SetString("HintPressedTime", System.DateTime.Now.ToString());
                PlayerPrefs.Save();
            }            
        }

        switch (sceneName)
        {
            case "Track":
                particle.SetActive(true);
                particle.transform.position = InGameManager.inGameManager.obj[InGameManager.inGameManager.index_track].transform.position;
                break;
            case "Alone":
                particle.SetActive(true);
                particle.transform.position = InGameManager.inGameManager.obj[InGameManager.inGameManager.index_alone].transform.position;
                break;
            case "Time Attack":
                Timer.timerControl.setTimer = false;
                Timer.timerControl.animator.speed = 0;
                particle.SetActive(true);
                particle.transform.position = InGameManager.inGameManager.obj[InGameManager.inGameManager.index].transform.position;
                break;
            case "Twins":
                particle.SetActive(true);
                if (InGameManager.inGameManager.turnChk)
                {
                    particle.transform.position = InGameManager.inGameManager.obj[InGameManager.inGameManager.index_twins].transform.position;
                }
                else
                {
                    particle.transform.position = InGameManager.inGameManager.obj[InGameManager.inGameManager.index_twins+1].transform.position;
                }                
                break;
            case "DanceDance":
                particle.SetActive(true);
                particle.transform.position = InGameManager.inGameManager.obj[InGameManager.inGameManager.index_dance_answer].transform.position;
                break;
            default:
                particle.SetActive(true);
                particle.transform.position = InGameManager.inGameManager.obj[InGameManager.inGameManager.index].transform.position;
                break;
        }
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void SceneLoader()
    {
        if(!clicked){
            clicked = true;
            sceneName = EventSystem.current.currentSelectedGameObject.name;
            switch (sceneName)
            {
                case "Normal":
                    curHighScore = PlayerPrefs.GetInt("HighScoreNormal");
                    buildIndex = 1;
                    break;
                case "Double":
                    curHighScore = PlayerPrefs.GetInt("HighScoreDouble");
                    buildIndex = 3;
                    break;
                case "Flip Horizon":
                    curHighScore = PlayerPrefs.GetInt("HighScoreHorizon");
                    buildIndex = 2;
                    break;
                case "Temptation":
                    curHighScore = PlayerPrefs.GetInt("HighScoreTemptation");
                    buildIndex = 7;
                    break;
                case "Twins":
                    curHighScore = PlayerPrefs.GetInt("HighScoreTwins");
                    buildIndex = 4;
                    break;
                case "Triple":
                    curHighScore = PlayerPrefs.GetInt("HighScoreTriple");
                    break;
                case "Flip Vertical":
                    curHighScore = PlayerPrefs.GetInt("HighScoreVertical");
                    buildIndex = 5;
                    break;
                case "Alone":
                    curHighScore = PlayerPrefs.GetInt("HighScoreAlone");
                    break;
                case "Track":
                    curHighScore = PlayerPrefs.GetInt("HighScoreTrack");
                    buildIndex = 8;
                    break;
                case "Chaos":
                    curHighScore = PlayerPrefs.GetInt("HighScoreChaos");
                    buildIndex = 9;
                    break;
                case "Time Attack":
                    curHighScore = PlayerPrefs.GetInt("HighScoreTimeAttack");
                    buildIndex = 6;
                    break;
                case "DanceDance":
                    curHighScore = PlayerPrefs.GetInt("HighScoreDance");
                    buildIndex = 10;
                    break;
            }
            //eventSystem.SetActive(false);
            //menus.SetActive(false);
            SceneManager.LoadScene(sceneName, LoadSceneMode.Additive);
        }
    }

    public void ShowRewardedAd()
    {
        btnName = EventSystem.current.currentSelectedGameObject.name;
        if (sceneName == "Time Attack")
        {
            Timer.timerControl.setTimer = false;
            Timer.timerControl.animator.speed = 0;
        }

        if (Advertisement.IsReady(rewarded_video_id))
        {
            var options = new ShowOptions { resultCallback = HandleShowResult };
            Advertisement.Show(rewarded_video_id, options);
        }
    }

    private void HandleShowResult(ShowResult result)
    {
        switch (result)
        {
            case ShowResult.Finished:
                Debug.Log(btnName);
                switch (btnName)
                {
                    case "GetHint":
                        PlayerPrefs.SetInt("Hint", 2);                        
                        PlayerPrefs.Save();
                        hintCount = PlayerPrefs.GetInt("Hint");
                        hintCountText.text = "x " + hintCount.ToString();
                        getHintBtnObj.SetActive(false);
                        hintBtnObj.SetActive(true);
                        hintBtn.interactable = true;
                        break;
                    case "GetRevive":
                        PlayerPrefs.SetInt("Revive", 1);
                        PlayerPrefs.Save();
                        reviveCount = PlayerPrefs.GetInt("Revive");                        
                        reviveCountText.text = "Revive x " + reviveCount.ToString();
                        getReviveBtnObj.SetActive(false);
                        reviveBtnObj.SetActive(true);
                        reviveBtn.interactable = true;
                        break;
                }
                Debug.Log("Finished");
                break;
            case ShowResult.Skipped:
                Debug.Log("Skipped");
                break;
            case ShowResult.Failed:
                Debug.Log("Failed");
                break;
        }
    }
        
    public void DeactiveUI()
    {
        pauseBtn.interactable = false;
        hintBtn.interactable = false;
        getHintBtn.interactable = false;
    }

    public void ActiveUI()
    {
        pauseBtn.interactable = true;
        if(isCoroutineHint == 0)
        {
            getHintBtn.interactable = true;
        }        
        hintBtn.interactable = true;
    }    

    private void OnApplicationFocus(bool focus)
    {        
        if (focus)
        {   
            if(isCoroutineHint == 1)
            {         
                lastTime = PlayerPrefs.GetString("StartTimeCoroutineHint");
                coroutineHintDuration = PlayerPrefs.GetInt("LeftTimeHint");
                lastDateTime = System.DateTime.Parse(lastTime);
                compareTime = System.DateTime.Now - lastDateTime;
                time = (int)compareTime.TotalSeconds;                                
                if(time >= coroutineHintDuration)
                {                    
                    StopCoroutine(startCoroutineHint);                    
                    coroutineHintDuration = 30;
                    getHintBtn.interactable = true;
                    getFreeHints.text = "Get Free Hints";
                    PlayerPrefs.SetInt("IsRunningCoroutineHint", 0);
                    PlayerPrefs.Save();
                }
                else
                {                    
                    StopCoroutine(startCoroutineHint);
                    coroutineHintDuration -= time;                    
                    startCoroutineHint = StartCoroutine(GetHintCounter(coroutineHintDuration));
                }
            }

            if(isCoroutineRevive == 1)
            {
                lastTime = PlayerPrefs.GetString("StartTimeCoroutineRevive");
                coroutineReviveDuration = PlayerPrefs.GetInt("LeftTimeRevive");
                lastDateTime = System.DateTime.Parse(lastTime);
                compareTime = System.DateTime.Now - lastDateTime;
                time = (int)compareTime.TotalSeconds;                
                if (time >= coroutineReviveDuration)
                {
                    StopCoroutine(startCoroutineRevive);
                    coroutineReviveDuration = 30;
                    getReviveBtn.interactable = true;
                    getRevives.text = "Get Free Revives";
                    PlayerPrefs.SetInt("IsRunningCoroutineRevive", 0);
                    PlayerPrefs.Save();                    
                }
                else
                {
                    StopCoroutine(startCoroutineRevive);
                    coroutineReviveDuration -= time;
                    startCoroutineRevive = StartCoroutine(GetReviveCounter(coroutineReviveDuration));
                }
            }
        }        
    }

    public void PausePressed()
    {
        if (sceneName == "Time Attack")
        {
            Timer.timerControl.setTimer = false;
            Timer.timerControl.animator.speed = 0;
        }
        ActivePauseGameOver(0, InGameManager.inGameManager.index);
    }    

    public void Tutorial()
    {              
        tutorialName = EventSystem.current.currentSelectedGameObject.name;       
        popUpPanel.transform.Find(tutorialName).gameObject.SetActive(true);
        popUpPanel.SetActive(true);        
    }

    public void DoLevelTransition()
    {
        levelCount.text = "Level " + (InGameManager.inGameManager.index + 1).ToString();
        levelTransition.transform.DOMove(destPos, 0.5f).SetEase(Ease.OutCubic).OnComplete(DoComplete);
    }

    void DoComplete()
    {
        switch (sceneName)
        {
            case "Double":
                PauseAni();
                StartCoroutine(StayTransition(1.0f));
                break;
            case "DanceDance":
                break;
            case "Chaos":
                PauseAni();
                StartCoroutine(StayTransition(1.0f));
                break;
            default:
                PauseAni();
                StartCoroutine(StayTransition(0.5f));
                break;
        }
    }

    void DoOutComplete()
    {   
        switch (sceneName)
        {
            case "Flip Vertical":
                DoMove();
                break;
            case "Flip Horizon":
                DoMove();
                break;
            case "Time Attack":
                InGameManager.inGameManager.ActiveHandler();
                Timer.timerControl.setTimer = true;
                break;
            case "DanceDance":
                break;
            default:
                InGameManager.inGameManager.ActiveHandler();
                break;
        }
        ActiveUI();
    }

    public void PauseAni()
    {
        clicked = false;
        if (SceneManager.GetActiveScene().name == "SceneManager")
        {
            menus.SetActive(false);
            topBackground.SetActive(false);
            SceneManager.SetActiveScene(SceneManager.GetSceneByName(sceneName));
        }

        if (!RootSpawnManager.rootSpawnManager.allThingsDone)
        {
            RootSpawnManager.rootSpawnManager.setScale(RootSpawnManager.rootSpawnManager.cats);

            switch (sceneName)
            {
                case "Twins":
                    RootSpawnManager.rootSpawnManager.PosSearch(InGameManager.inGameManager.posList,
                                                        InGameManager.inGameManager.objType);
                    RootSpawnManager.rootSpawnManager.InstantiateObjTwins(InGameManager.inGameManager.posList.Count);

                    break;
                case "Flip Vertical":
                    RootSpawnManager.rootSpawnManager.PosSearch(InGameManager.inGameManager.posList,
                                                        InGameManager.inGameManager.objType);
                    RootSpawnManager.rootSpawnManager.InstantiateObj(RootSpawnManager.rootSpawnManager.flyingCat,
                                                                     InGameManager.inGameManager.posList.Count);
                    break;
                default:
                    RootSpawnManager.rootSpawnManager.PosSearch(InGameManager.inGameManager.posList,
                                                        InGameManager.inGameManager.objType);
                    RootSpawnManager.rootSpawnManager.InstantiateObj(RootSpawnManager.rootSpawnManager.cats,
                                                                     InGameManager.inGameManager.posList.Count);
                    break;
            }
            uiNavigation.SetActive(true);
            //RootUIManager.rootUIManager.background.SetActive(true);
        }
        //RootSpawnManager.rootSpawnManager.objCreator();
        InGameManager.inGameManager.chkUnlockStage();
    }

    public void DoMove()
    {
        switch (InGameManager.inGameManager.sceneName)
        {
            case "Flip Horizon":
                if (InGameManager.inGameManager.turnChk)
                {
                    for (int i = 0; i <= InGameManager.inGameManager.index; i++)
                    {
                        if (i == InGameManager.inGameManager.index)
                        {
                            //When only last obj is completed their MOVE, do flipSprite
                            InGameManager.inGameManager.obj[i].transform.DOMove(InGameManager.inGameManager.oppCenterPos[i], 0.8f).SetEase(Ease.OutQuint).OnComplete(FlipSprite);
                        }
                        else
                        {
                            InGameManager.inGameManager.obj[i].transform.DOMove(InGameManager.inGameManager.oppCenterPos[i], 0.8f).SetEase(Ease.OutQuint);
                        }
                    }
                    InGameManager.inGameManager.turnChk = false;
                }
                else
                {
                    for (int i = 0; i <= InGameManager.inGameManager.index; i++)
                    {
                        if (i == InGameManager.inGameManager.index)
                        {
                            InGameManager.inGameManager.obj[i].transform.DOMove(InGameManager.inGameManager.posList[i], 0.8f).SetEase(Ease.OutQuint).OnComplete(FlipSprite);
                        }
                        else
                        {
                            InGameManager.inGameManager.obj[i].transform.DOMove(InGameManager.inGameManager.posList[i], 0.8f).SetEase(Ease.OutQuint);
                        }
                    }
                    InGameManager.inGameManager.turnChk = true;
                }

                //InGameManager.inGameManager.ActiveHandler();
                break;
            case "Flip Vertical":
                if (InGameManager.inGameManager.turnChk)
                {
                    for (int i = 0; i <= InGameManager.inGameManager.index; i++)
                    {
                        InGameManager.inGameManager.obj[i].transform.DOMove(InGameManager.inGameManager.oppCenterPos[i], 0.8f).SetEase(Ease.OutQuint).OnComplete(InGameManager.inGameManager.ActiveHandler);
                    }
                    InGameManager.inGameManager.turnChk = false;
                }
                else
                {
                    for (int i = 0; i <= InGameManager.inGameManager.index; i++)
                    {
                        InGameManager.inGameManager.obj[i].transform.DOMove(InGameManager.inGameManager.posList[i], 0.8f).SetEase(Ease.OutQuint).OnComplete(InGameManager.inGameManager.ActiveHandler);
                    }
                    InGameManager.inGameManager.turnChk = true;
                }
                break;
        }
    }

    private void FlipSprite()
    {
        for (int i = 0; i <= InGameManager.inGameManager.index; i++)
        {
            if (InGameManager.inGameManager.obj[i].transform.position.x > 0)
            {
                InGameManager.inGameManager.obj[i].transform.DORotate(new Vector3(0, 180, 0), 0.3f);
            }
            else
            {
                InGameManager.inGameManager.obj[i].transform.DORotate(new Vector3(0, 0, 0), 0.3f);
            }
        }
        InGameManager.inGameManager.ActiveHandler();
    }

}
