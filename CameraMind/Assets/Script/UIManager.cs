using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

    //Animator animator;
    public int hintCount;
    public TextMeshProUGUI hintText;
    public Button hintBtn, pauseBtn;
    public GameObject uiPanel;
    public GameObject particle, hintParticle;

    public Vector3 unknownPos = new Vector3(-20f, 20f, 0);
        
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
            hintBtn.interactable = false;
        }

        particle = Instantiate(hintParticle) as GameObject;
        particle.transform.position = unknownPos;
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
                particle.transform.position = SpawnPrefab.instance.obj[SpawnPrefab.instance.index_track].transform.position;
                break;
            case "Alone":
                //animatorObj = SpawnPrefab.instance.obj[SpawnPrefab.instance.index_alone].GetComponent<Animator>();
                //animatorObj.SetTrigger("Hint");
                //particle = Instantiate(hintParticle) as GameObject;
                particle.transform.position = SpawnPrefab.instance.obj[SpawnPrefab.instance.index_alone].transform.position;
                break;
            case "Time Attack":
                Timer.timerControl.timer.transform.position = new Vector3(-7.96f, -4.38f, 0);
                Timer.timerControl.sec = 0;
                Timer.timerControl.counter = 0;
                Timer.timerControl.timerCounter.text = (3).ToString();
                Timer.timerControl.animator.SetInteger("TimerState", Timer.timerControl.counter);
                //particle = Instantiate(hintParticle) as GameObject;
                particle.transform.position = SpawnPrefab.instance.obj[SpawnPrefab.instance.index].transform.position;
                //animatorObj = SpawnPrefab.instance.obj[SpawnPrefab.instance.index].GetComponent<Animator>();
                //animatorObj.SetTrigger("Hint");                
                break;
            default:
                //animatorObj = SpawnPrefab.instance.obj[SpawnPrefab.instance.index].GetComponent<Animator>();
                //animatorObj.SetTrigger("Hint");
                //particle = Instantiate(hintParticle) as GameObject;
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
                particle.transform.position = SpawnPrefab.instance.obj[SpawnPrefab.instance.index_track].transform.position;
                break;
            case "Alone":
                //animator = SpawnPrefab.instance.obj[SpawnPrefab.instance.index_alone].GetComponent<Animator>();
                //animator.SetTrigger("Hint");
                //particle = Instantiate(hintParticle) as GameObject;
                particle.transform.position = SpawnPrefab.instance.obj[SpawnPrefab.instance.index_alone].transform.position;
                break;
            case "Time Attack":
                Timer.timerControl.setTimer = false;
                Timer.timerControl.animator.speed = 0;
                //particle = Instantiate(hintParticle) as GameObject;
                particle.transform.position = SpawnPrefab.instance.obj[SpawnPrefab.instance.index].transform.position;
                //animator = SpawnPrefab.instance.obj[SpawnPrefab.instance.index].GetComponent<Animator>();
                //animator.SetTrigger("Hint");
                break;
            default:
                //animator = SpawnPrefab.instance.obj[SpawnPrefab.instance.index].GetComponent<Animator>();
                //animator.SetTrigger("Hint");
                //particle = Instantiate(hintParticle) as GameObject;
                particle.transform.position = SpawnPrefab.instance.obj[SpawnPrefab.instance.index].transform.position;
                break;
        }
        hintCount--;
        PlayerPrefs.SetInt("Hint", hintCount);
        PlayerPrefs.Save();
        hintText.text = "x " + hintCount.ToString();
        if(hintCount == 0)
        {
            hintBtn.interactable = false;
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
    }

    public void ActiveUI()
    {
        pauseBtn.interactable = true;
        if(hintCount != 0)
        {
            hintBtn.interactable = true;
        }        
    }

}
