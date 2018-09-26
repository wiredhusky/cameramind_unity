using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using TMPro;
using UnityEngine.UI;
using UnityEngine.Advertisements;

public class RootUIManager : MonoBehaviour {

    private const string rewarded_video_id = "rewardedVideo";

    public static RootUIManager rootUIManager;
    public GameObject gamePanel, background;
    public GameObject reviveBtnObj, getReviveBtnObj, resumeBtnObj;
    public GameObject particle, hintParticle;
    public GameObject eventSystem;
    public GameObject menus;
    public GameObject uiNavigation;
    public TextMeshProUGUI currentLevelText, reviveCountText, title, hintCountText;
    public string sceneName, btnName;
    public Animator animator;
    public Button reviveBtn, getReviveBtn;
    int hintCount, reviveCount;

    //uiBtns
    public Button pauseBtn, hintBtn, getHintBtn;
    public GameObject hintBtnObj, getHintBtnObj;

    //protect double click
    public bool clicked;

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
        }
    }

    private void Start()
    {
        particle = Instantiate(hintParticle) as GameObject;
        particle.SetActive(false);
        clicked = false;
        InitScene();
    }

    public void InitScene(){
        
        hintCount = PlayerPrefs.GetInt("Hint");
        reviveCount = PlayerPrefs.GetInt("Revive");
        hintCountText.text = "x " + hintCount.ToString();

        if (hintCount == 0)
        {
            hintBtnObj.SetActive(false);
            getHintBtnObj.SetActive(true);
        }
    }

    public void ActivePauseGameOver(int type, int index)
    {
        //UIManager.uiManager.eventSystem.SetActive(false);
        //eventSystem.SetActive(true);
        switch(type){
            case 0: // pause
                title.text = "Pause";
                resumeBtnObj.SetActive(true);
                reviveBtnObj.SetActive(false);
                getReviveBtnObj.SetActive(false);
                currentLevelText.text = "Level " + index.ToString();
                gamePanel.SetActive(true);
                break;
            case 1: // gameOver
                title.text = "Game Over";
                resumeBtnObj.SetActive(false);
                reviveCount = PlayerPrefs.GetInt("Revive");
                currentLevelText.text = "Level " + index.ToString();
                reviveCountText.text = "Revive x " + reviveCount.ToString();

                if (reviveCount == 0)
                {
                    reviveBtnObj.SetActive(false);
                    getReviveBtnObj.SetActive(true);
                    getReviveBtn.interactable = true;
                }
                else
                {
                    reviveBtnObj.SetActive(true);
                    getReviveBtnObj.SetActive(false);
                    reviveBtn.interactable = true;
                }
                gamePanel.SetActive(true);
                break;
        }
    }

    public void PauseGamePanel(){
        animator.speed = 0;
    }

    public void Resume(){
        if(!clicked){
            clicked = true;
            btnName = EventSystem.current.currentSelectedGameObject.name;
            //eventSystem.SetActive(false);
            //UIManager.uiManager.eventSystem.SetActive(true);
            animator.speed = 1;
            if (sceneName == "Time Attack")
            {
                Timer.timerControl.setTimer = true;
                Timer.timerControl.animator.speed = 1;
            }
        }
    }

    public void Restart(){
        Debug.Log(clicked);
        if(!clicked){
            clicked = true;
            btnName = EventSystem.current.currentSelectedGameObject.name;
            //eventSystem.SetActive(false);
            //UIManager.uiManager.eventSystem.SetActive(true);
            SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene());
            //background.SetActive(true);
            uiNavigation.SetActive(false);
            animator.speed = 1;
            RootSpawnManager.rootSpawnManager.allThingsDone = false;
        }
    }

    public void MainMenu(){
        if(!clicked){
            clicked = true;
            btnName = EventSystem.current.currentSelectedGameObject.name;
            SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene());
            menus.SetActive(true);
            background.SetActive(false);
            uiNavigation.SetActive(false);
            animator.speed = 1;
            RootSpawnManager.rootSpawnManager.allThingsDone = false;
        }
    }

    public void Revive(){
        btnName = EventSystem.current.currentSelectedGameObject.name;
        reviveBtn.interactable = false;
        reviveCount--;
        reviveCountText.text = "Revive x " + reviveCount.ToString();
        PlayerPrefs.SetInt("Revive", reviveCount);
        PlayerPrefs.Save();
        //eventSystem.SetActive(false);
        //UIManager.uiManager.eventSystem.SetActive(true);

        animator.speed = 1;

        switch (sceneName)
        {
            case "Track":
                particle.SetActive(true);
                particle.transform.position = GameManager.gameManager.obj[GameManager.gameManager.index_track].transform.position;
                break;
            case "Alone":
                particle.SetActive(true);
                particle.transform.position = GameManager.gameManager.obj[GameManager.gameManager.index_alone].transform.position;
                break;
            case "Time Attack":
                Timer.timerControl.timer.transform.position = new Vector3(-7.96f, -4.38f, 0);
                Timer.timerControl.sec = 0;
                Timer.timerControl.counter = 0;
                Timer.timerControl.timerCounter.text = (3).ToString();
                Timer.timerControl.animator.SetInteger("TimerState", Timer.timerControl.counter);
                particle.SetActive(true);
                particle.transform.position = GameManager.gameManager.obj[GameManager.gameManager.index].transform.position;
                break;
            default:
                particle.SetActive(true);
                particle.transform.position = GameManager.gameManager.obj[GameManager.gameManager.index].transform.position;
                break;
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
            hintBtnObj.SetActive(false);
            getHintBtnObj.SetActive(true);
            getHintBtn.interactable = true;
        }

        switch (sceneName)
        {
            case "Track":
                particle.SetActive(true);
                particle.transform.position = GameManager.gameManager.obj[GameManager.gameManager.index_track].transform.position;
                break;
            case "Alone":
                particle.SetActive(true);
                particle.transform.position = GameManager.gameManager.obj[GameManager.gameManager.index_alone].transform.position;
                break;
            case "Time Attack":
                Timer.timerControl.setTimer = false;
                Timer.timerControl.animator.speed = 0;
                particle.SetActive(true);
                particle.transform.position = GameManager.gameManager.obj[GameManager.gameManager.index].transform.position;
                break;
            default:
                particle.SetActive(true);
                particle.transform.position = GameManager.gameManager.obj[GameManager.gameManager.index].transform.position;
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
        getHintBtn.interactable = true;
        hintBtn.interactable = true;
    }

    public void PausePressed()
    {
        if (sceneName == "Time Attack")
        {
            Timer.timerControl.setTimer = false;
            Timer.timerControl.animator.speed = 0;
        }
        ActivePauseGameOver(0, GameManager.gameManager.index);
    }
}
