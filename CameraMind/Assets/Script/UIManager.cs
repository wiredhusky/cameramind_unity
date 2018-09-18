using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;
using UnityEngine.Advertisements;
using UnityEngine.EventSystems;

public class UIManager : MonoBehaviour {

    private const string rewarded_video_id = "rewardedVideo";
    string buttonName;

    //Animator animator;
    public int hintCount;
    public TextMeshProUGUI hintText;
    public Button pauseBtn, hintBtn, hintAdsBtn;
    public GameObject uiPanel;
    public GameObject particle, hintParticle, hintObj, hintAdsObj;
    
    public int revive;

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
        hintCount = PlayerPrefs.GetInt("Hint");
        hintText.text = "x " + hintCount.ToString();

        if(hintCount == 0)
        {
            hintObj.SetActive(false);
            hintAdsObj.SetActive(true);            
        }

        particle = Instantiate(hintParticle) as GameObject;
        particle.SetActive(false);
    }

    public void InitGameOver()
    {
        if (GameOver.gameOver.gameObject.name == "GameOver")
        {
            revive = PlayerPrefs.GetInt("Revive");
            GameOver.gameOver.count.text = "Level " + (SpawnPrefab.instance.index).ToString();
            GameOver.gameOver.reviveCounter.text = "Revive x " + revive.ToString();

            if (revive == 0)
            {
                GameOver.gameOver.reviveBtn.interactable = false;
            }
        }        
    }

    public void GoToMainMenu()
    {
        SceneManager.UnloadSceneAsync(GameOver.gameOver.scene);
        SceneManager.LoadScene("MainMenu", LoadSceneMode.Additive);
        GameOver.gameOver.animator.speed = 1;
    }

    public void Restart()
    {
        GameOver.gameOver.gameOverBack.SetActive(true);
        SceneManager.UnloadSceneAsync(GameOver.gameOver.scene);
        GameOver.gameOver.animator.speed = 1;
    }

    public void Revive()
    {
        GameOver.gameOver.reviveBtn.interactable = false;        
        revive--;
        GameOver.gameOver.reviveCounter.text = "Revive x " + revive.ToString();
        PlayerPrefs.SetInt("Revive", revive);
        PlayerPrefs.Save();        

        GameOver.gameOver.animator.speed = 1;

        switch (SpawnPrefab.instance.scene)
        {
            case "Track":
                //animatorObj = SpawnPrefab.instance.obj[SpawnPrefab.instance.index_track].GetComponent<Animator>();
                //animatorObj.SetTrigger("Hint");
                //particle = Instantiate(hintParticle) as GameObject;
                particle.SetActive(true);
                particle.transform.position = SpawnPrefab.instance.obj[SpawnPrefab.instance.index_track].transform.position;
                break;
            case "Alone":
                //animatorObj = SpawnPrefab.instance.obj[SpawnPrefab.instance.index_alone].GetComponent<Animator>();
                //animatorObj.SetTrigger("Hint");
                //particle = Instantiate(hintParticle) as GameObject;
                particle.SetActive(true);
                particle.transform.position = SpawnPrefab.instance.obj[SpawnPrefab.instance.index_alone].transform.position;
                break;
            case "Time Attack":
                Timer.timerControl.timer.transform.position = new Vector3(-7.96f, -4.38f, 0);
                Timer.timerControl.sec = 0;
                Timer.timerControl.counter = 0;
                Timer.timerControl.timerCounter.text = (3).ToString();
                Timer.timerControl.animator.SetInteger("TimerState", Timer.timerControl.counter);
                //particle = Instantiate(hintParticle) as GameObject;
                particle.SetActive(true);
                particle.transform.position = SpawnPrefab.instance.obj[SpawnPrefab.instance.index].transform.position;
                //animatorObj = SpawnPrefab.instance.obj[SpawnPrefab.instance.index].GetComponent<Animator>();
                //animatorObj.SetTrigger("Hint");                
                break;
            default:
                //animatorObj = SpawnPrefab.instance.obj[SpawnPrefab.instance.index].GetComponent<Animator>();
                //animatorObj.SetTrigger("Hint");
                //particle = Instantiate(hintParticle) as GameObject;
                particle.SetActive(true);
                particle.transform.position = SpawnPrefab.instance.obj[SpawnPrefab.instance.index].transform.position;
                break;
        }
    }

    public void HintPressed()
    {
        switch (SpawnPrefab.instance.scene)
        {
            case "Track":
                //animator = SpawnPrefab.instance.obj[SpawnPrefab.instance.index_track].GetComponent<Animator>();
                //animator.SetTrigger("Hint");
                //particle = Instantiate(hintParticle) as GameObject;
                particle.SetActive(true);
                particle.transform.position = SpawnPrefab.instance.obj[SpawnPrefab.instance.index_track].transform.position;
                break;
            case "Alone":
                //animator = SpawnPrefab.instance.obj[SpawnPrefab.instance.index_alone].GetComponent<Animator>();
                //animator.SetTrigger("Hint");
                //particle = Instantiate(hintParticle) as GameObject;
                particle.SetActive(true);
                particle.transform.position = SpawnPrefab.instance.obj[SpawnPrefab.instance.index_alone].transform.position;
                break;
            case "Time Attack":
                Timer.timerControl.setTimer = false;
                Timer.timerControl.animator.speed = 0;
                //particle = Instantiate(hintParticle) as GameObject;
                particle.SetActive(true);
                particle.transform.position = SpawnPrefab.instance.obj[SpawnPrefab.instance.index].transform.position;
                //animator = SpawnPrefab.instance.obj[SpawnPrefab.instance.index].GetComponent<Animator>();
                //animator.SetTrigger("Hint");
                break;
            default:
                //animator = SpawnPrefab.instance.obj[SpawnPrefab.instance.index].GetComponent<Animator>();
                //animator.SetTrigger("Hint");
                //particle = Instantiate(hintParticle) as GameObject;
                particle.SetActive(true);
                particle.transform.position = SpawnPrefab.instance.obj[SpawnPrefab.instance.index].transform.position;
                break;
        }
        hintCount--;
        PlayerPrefs.SetInt("Hint", hintCount);
        PlayerPrefs.Save();
        hintCount = PlayerPrefs.GetInt("Hint");
        hintText.text = "x " + hintCount.ToString();
        if(hintCount == 0)
        {
            hintObj.SetActive(false);
            hintAdsObj.SetActive(true);
        }
    }

    public void PausePressed()
    {        
        if (SpawnPrefab.instance.scene == "Time Attack")
        {
            Timer.timerControl.setTimer = false;
            Timer.timerControl.animator.speed = 0;
        }
        SceneManager.LoadScene("Pause", LoadSceneMode.Additive);
    }

    public void DeactiveUI()
    {
        pauseBtn.interactable = false;
        hintBtn.interactable = false;
        hintAdsBtn.interactable = false;
    }

    public void ActiveUI()
    {
        pauseBtn.interactable = true;
        hintAdsBtn.interactable = true;
        if(hintCount != 0)
        {
            hintBtn.interactable = true;
        }        
    }

    public void ShowRewardedAd()
    {
        buttonName = EventSystem.current.currentSelectedGameObject.name;
        if (SpawnPrefab.instance.scene == "Time Attack")
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
                switch (buttonName)
                {
                    case "HintAds":
                        PlayerPrefs.SetInt("Hint", 3);
                        PlayerPrefs.Save();
                        hintText.text = "x " + hintCount.ToString();
                        hintAdsObj.SetActive(false);
                        hintObj.SetActive(true);
                        break;
                    case "ReviveAds":
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

}
