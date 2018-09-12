using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

    Animator animator;
    public int hintCount = 3;
    public TextMeshProUGUI hintText;
    public Button hintBtn, pauseBtn;
    public GameObject uiPanel;
    
    private void Start()
    {
        hintText.text = "x " + hintCount.ToString();
    }

    public void HintPressed()
    {        
        switch (SpawnPrefab.instance.scene)
        {
            case "Track":
                animator = SpawnPrefab.instance.obj[SpawnPrefab.instance.index_track].GetComponent<Animator>();
                animator.SetTrigger("Hint");
                break;
            case "Alone":
                animator = SpawnPrefab.instance.obj[SpawnPrefab.instance.index_alone].GetComponent<Animator>();
                animator.SetTrigger("Hint");
                break;
            case "Time Attack":
                Timer.timerControl.setTimer = false;
                Timer.timerControl.animator.speed = 0;
                animator = SpawnPrefab.instance.obj[SpawnPrefab.instance.index].GetComponent<Animator>();
                animator.SetTrigger("Hint");
                break;
            default:
                animator = SpawnPrefab.instance.obj[SpawnPrefab.instance.index].GetComponent<Animator>();
                animator.SetTrigger("Hint");
                break;
        }
        hintCount--;
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
