using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransitionControl : MonoBehaviour {

    public GameObject levelTransition;
    public GameObject gameOver;
    public LevelCounter display;

	// Use this for initialization
	void Start () {
        display = FindObjectOfType<LevelCounter>();
	}
	
	// Update is called once per frame
	void Update () {
		
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
                gameOver.SetActive(true);
                break;
        }        
    }
}
