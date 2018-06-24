using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransitionControl : MonoBehaviour {

    public GameObject levelTransition;
    public GameObject gameOver;
    
    public LevelCounter display;

    public bool GameOver = false;
    float currentTime = 0;

	// Use this for initialization
	void Start () {
        display = FindObjectOfType<LevelCounter>();      
	}

    public void DoTransition(int type)
    {
        switch (type)
        {
            case 0: // level Transition
                display.CountLevel();
                levelTransition.SetActive(true);
                break;
            case 1:
                //display.GameResult();
                gameOver.SetActive(true);
                break;
        }        
    }

    private void FixedUpdate()
    {
        if (GameOver)
        {
            currentTime += Time.deltaTime;
            if(currentTime >= 1.0f)
            {
                GameOver = false;
                DoTransition(1);
            }
        }
    }
}
