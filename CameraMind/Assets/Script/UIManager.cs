using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class UIManager : MonoBehaviour {

    Animator animator;
    public int hintCount = 3;
    public TextMeshProUGUI hintText;

    private void Start()
    {
        hintText.text = "x " + hintCount.ToString();
    }

    public void HintPressed()
    {        
        switch (SpawnPrefab.instance.scene)
        {
            case "Track":
                break;
            default:
                animator = SpawnPrefab.instance.obj[SpawnPrefab.instance.index].GetComponent<Animator>();
                animator.SetTrigger("Hint");
                break;
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
    
}
