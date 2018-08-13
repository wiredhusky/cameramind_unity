﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class spawn : MonoBehaviour {

    
    public MoveMove move;
    //public Clicked tap;    
    public TransitionControl transitionControl;

    Animator animator;
    
    int randObj, randAni;    
    
    // Use this for initialization
    void Start ()
    {
        //instance = GameObject.FindWithTag("spawner").GetComponent<SpawnPrefab>();
        transitionControl = GameObject.FindWithTag("transitionControl").GetComponent<TransitionControl>();        
        if(SpawnPrefab.instance.scene == 2 || SpawnPrefab.instance.scene == 10 || SpawnPrefab.instance.scene == 7)
        {
            move = GameObject.FindWithTag("movement").GetComponent<MoveMove>();
        }        
        
        //animator = gameObject.GetComponent<Animator>();
        //tap = GetComponent<Clicked>();
	}

    
    /*
    public void SetAnimation()
    {
        switch (instance.scene)
        {
            case 6: // temptation
                randObj = Random.Range(0, instance.index);
                randAni = Random.Range(0, 3);
                switch (randAni)
                {
                    case 0:
                        animator = instance.obj[randObj].GetComponent<Animator>();
                        animator.SetTrigger("rotation");
                        break;
                    case 1:
                        animator = instance.obj[randObj].GetComponent<Animator>();
                        animator.SetTrigger("angry");
                        break;
                    case 2:
                        animator = instance.obj[randObj].GetComponent<Animator>();
                        animator.SetTrigger("shaking");
                        break;
                }
                break;
        }
    }*/

	public void objCreator()
    {
        SpawnPrefab.instance.scene = SceneManager.GetActiveScene().buildIndex;
        switch (SpawnPrefab.instance.scene)
        {
            case 0:
                break;            
            case 2:
                SpawnPrefab.instance.SpawnObj_Flip();
                break;
            case 3: // track
                SpawnPrefab.instance.SpawnObj();                
                transitionControl.EventHandler();
                break;
            case 4: // twins
                SpawnPrefab.instance.SpawnObj_Twins();
                break;
            case 5: // alone
                SpawnPrefab.instance.SpawnObj_Alone();
                transitionControl.RendererHandler();
                break;
            case 6: // temptation
                SpawnPrefab.instance.SpawnObj();
                randObj = Random.Range(0, SpawnPrefab.instance.index);
                randAni = Random.Range(0, 3);
                switch (randAni)
                {
                    case 0:
                        animator = SpawnPrefab.instance.obj[randObj].GetComponent<Animator>();
                        animator.SetTrigger("rotation");
                        break;
                    case 1:
                        animator = SpawnPrefab.instance.obj[randObj].GetComponent<Animator>();
                        animator.SetTrigger("angry");
                        break;
                    case 2:
                        animator = SpawnPrefab.instance.obj[randObj].GetComponent<Animator>();
                        animator.SetTrigger("shaking");
                        break;
                }
                break;
            case 7: // vertical flip
                SpawnPrefab.instance.SpawnObj_Flip();
                break;
            case 10: // mix
                SpawnPrefab.instance.SpawnObj_Flip();
                randObj = Random.Range(0, SpawnPrefab.instance.index);
                randAni = Random.Range(0, 3);
                switch (randAni)
                {
                    case 0:
                        animator = SpawnPrefab.instance.obj[randObj].GetComponent<Animator>();
                        animator.SetTrigger("rotation");
                        break;
                    case 1:
                        animator = SpawnPrefab.instance.obj[randObj].GetComponent<Animator>();
                        animator.SetTrigger("angry");
                        break;
                    case 2:
                        animator = SpawnPrefab.instance.obj[randObj].GetComponent<Animator>();
                        animator.SetTrigger("shaking");
                        break;
                }
                break;
            default: // normal, double, triple
                SpawnPrefab.instance.SpawnObj();
                break;
        }        
    }

    public void PauseAni()
    {
        if (!SpawnPrefab.instance.allThingsDone)
        {
            animator = gameObject.GetComponent<Animator>();
            animator.speed = 0;
        }

        if(SceneManager.GetActiveScene().buildIndex == 0)
        {
            SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene().buildIndex);            
        }      

        //GameObject.FindWithTag("background").transform.GetChild(0).gameObject.SetActive(true);
        //instance.CalPos();
    }

    public void ActiveCollider()
    {
        transitionControl.ActiveHandler();
    }

    public void SetObj()
    {
        //animator.SetTrigger("getBackIdle");
        gameObject.SetActive(false);
    }

    /*
    public void DeactiveGameOver()
    {
        gameOver.SetActive(false);        
    }*/

    public void MovePrefab()
    {
        move._move = true;
    }

}
