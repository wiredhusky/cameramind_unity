using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour {

    public static Timer timerControl;
    public Animator animator;
    public GameObject timer;    
    public bool setTimer = false;    
    public int counter;
    public float sec;
    public Vector3 target;

    public TextMeshProUGUI timerCounter;
    
    private void Awake()
    {
        if(timerControl == null)
        {
            timerControl = this;
        }
    }

    private void Start()
    {   
        target = timer.transform.position;        
        animator.speed = 0;
        counter = 0;
        sec = 12;
    }

    // Update is called once per frame
    void Update () {
        if (setTimer)
        {
            sec -= Time.deltaTime;
            //counter = (int)sec;
            timerCounter.text = sec.ToString("N2");
            /*
            counter = (int) sec % 3;
            switch (counter)
            {
                case 0:
                    if(sec < 3)
                    {                        
                        timerCounter.text = (3).ToString();
                        animator.SetInteger("TimerState", counter);
                    }
                    break;
                case 1:
                    animator.SetInteger("TimerState", counter);
                    timerCounter.text = (2).ToString();
                    break;
                case 2:
                    animator.SetInteger("TimerState", counter);
                    timerCounter.text = (1).ToString();
                    break;
            }

            timer.transform.Translate(Vector3.right*0.2f);
            */
            if(sec <= 0)
            {
                InGameManager.inGameManager.DeactiveHandler();
                animator.speed = 0;
                setTimer = false;
                timerCounter.text = "Game Over";
                RootUIManager.rootUIManager.DeactiveUI();
                RootGameManager.rootGameManager.GameOver(InGameManager.inGameManager.obj[InGameManager.inGameManager.index]);
            }
        }        
	}
}
