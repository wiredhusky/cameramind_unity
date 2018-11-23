using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialManager : MonoBehaviour {

    public Animator animator;

    public void DeactiveMyself()
    {
        RootUIManager.rootUIManager.popUpPanel.transform.Find(RootUIManager.rootUIManager.tutorialName).gameObject.SetActive(false);
        gameObject.SetActive(false);
    }

    public void PauseAni()
    {
        animator.speed = 0;
    }

    public void ResumeAni()
    {
        animator.speed = 1;        
    }
	
}
