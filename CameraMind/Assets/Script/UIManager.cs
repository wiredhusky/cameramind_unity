using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

    private const string rewarded_video_id = "rewardedVideo";

    public TextMeshProUGUI hintText;
    public Button pauseBtn, hintBtn, getHintBtn;
    public GameObject uiPanel;
    public GameObject hintBtnObj, getHintBtnObj;
    public GameObject eventSystem;

    public static UIManager uiManager;

    private void Awake()
    {
        if(uiManager == null)
        {
            uiManager = this;
        }        
    }

    private void Start()
    {
        RootUIManager.rootUIManager.InitScene(hintBtnObj, getHintBtnObj, hintText);
    }

    public void HintPressed()
    {
        if(RootUIManager.rootUIManager.sceneName == "Time Attack"){
            Timer.timerControl.setTimer = false;
            Timer.timerControl.animator.speed = 0;
        }
        RootUIManager.rootUIManager.Hint(hintBtnObj, getHintBtnObj, getHintBtn, hintText);
    }

    public void GetHint(){
        RootUIManager.rootUIManager.ShowRewardedAd();
    }

    public void PausePressed()
    {   
        if (RootUIManager.rootUIManager.sceneName == "Time Attack")
        {
            Timer.timerControl.setTimer = false;
            Timer.timerControl.animator.speed = 0;
        }
        RootUIManager.rootUIManager.ActivePauseGameOver(0, GameManager.gameManager.index);
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
}
