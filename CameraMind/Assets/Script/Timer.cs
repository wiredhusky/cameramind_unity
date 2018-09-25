using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour {

    public static Timer timerControl;
    public Animator animator;
    public GameObject timer;    
    public bool setTimer = false;
    float speed = 2;
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
        target = new Vector3(-1.96f, -4.38f, 0);
        animator.speed = 0;
        counter = 0;
        sec = 0;
    }

    // Update is called once per frame
    void Update () {
        if (setTimer)
        {
            sec += Time.deltaTime;
            counter = (int) sec % 3;
            switch (counter)
            {
                case 0:
                    if(timer.transform.position != target)
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

            timer.transform.position = Vector3.MoveTowards(timer.transform.position, target, speed * Time.deltaTime);
            
            if(timer.transform.position == target)
            {
                GameManager.gameManager.DeactiveHandler();
                animator.speed = 0;
                setTimer = false;
                timerCounter.text = (0).ToString();
                UIManager.uiManager.DeactiveUI();
                RootGameManager.rootGameManager.GameOver();                             
            }
        }        
	}
}
