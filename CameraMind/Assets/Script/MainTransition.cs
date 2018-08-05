﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MainTransition : MonoBehaviour {

    public GameObject soomong;
    Animator animator;

    private void Start()
    {
        animator = soomong.GetComponent<Animator>();
    }

    private void SoomongShaker()
    {        
        animator.SetTrigger("shaking");
    }

    private void GoToMain()
    {        
        SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene());
        SceneManager.LoadScene("MainMenu", LoadSceneMode.Additive);
    }

    private void DestoryMyself()
    {
        SceneManager.UnloadSceneAsync("Transition");        
    }
	
}
