using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialManager : MonoBehaviour {

    public Animator animator;

    public void DeactiveMyself()
    {
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
