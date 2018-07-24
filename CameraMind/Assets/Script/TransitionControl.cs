using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransitionControl : MonoBehaviour {

    public GameObject levelTransition;
    public GameObject gameOver;

    public SpawnPrefab aniSpawn;

    public delegate void GoToIdle();
    public event GoToIdle goIdle;
    public event GoToIdle activeCollider;
    public event GoToIdle deactiveCollider;
    public event GoToIdle enableRenderer;

    public LevelCounter display;
    public bool chkGameOver;
    Animator animator;
    AnimatorStateInfo currentBaseState;

    // Use this for initialization
    void Start () {
        display = GameObject.FindWithTag("LevelCounter").GetComponent<LevelCounter>();
        aniSpawn = GameObject.FindWithTag("spawner").GetComponent<SpawnPrefab>();
        //aniSpawn = FindObjectOfType<SpawnPrefab>();
        chkGameOver = false;
	}

    public void EventHandler()
    {
        if(goIdle != null)
        {
            goIdle();
        }
    }

    public void ActiveHandler()
    {
        if(activeCollider != null)
        {
            activeCollider();
        }
    }

    public void DeactiveHandler()
    {
        deactiveCollider();
    }

    public void RendererHandler()
    {
        if(aniSpawn.index == 0)
        {
            enableRenderer();
        }        
    }
    
    public void GameOver()
    {
        switch (aniSpawn.scene)
        {
            case 0:
                break;
            case 3:
                animator = aniSpawn.obj[aniSpawn.index_track].GetComponent<Animator>();
                break;
            case 4:
                if (aniSpawn.colored)
                {
                    animator = aniSpawn.obj[aniSpawn.index_twins].GetComponent<Animator>();
                }
                else
                {
                    animator = aniSpawn.obj[aniSpawn.index_twins+1].GetComponent<Animator>();
                }                
                break;
            case 5:
                animator = aniSpawn.obj[aniSpawn.index_alone].GetComponent<Animator>();
                break;            
            default: // normal, double, triple, vertical/horizontal flip, temptation
                animator = aniSpawn.obj[aniSpawn.index].GetComponent<Animator>();
                break;
        }        
        animator.SetTrigger("gameOver");
        chkGameOver = true;        
    }

    public void ChkClicked()
    {
        animator = aniSpawn.obj[aniSpawn.index_track].GetComponent<Animator>();
        animator.SetTrigger("Clicked");
        aniSpawn.index_track++;
        if(aniSpawn.index_track == aniSpawn.index + 1)
        {
            DeactiveHandler();
        }
        Debug.Log("OK");
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

    void Update()
    {
        if (chkGameOver)
        {   
            currentBaseState = animator.GetCurrentAnimatorStateInfo(0);
            if (currentBaseState.IsName("soomong20_twinkle"))
            {
                //Debug.Log(currentBaseState.normalizedTime);
                if (currentBaseState.normalizedTime > 1.0f)
                {                    
                    DoTransition(1);
                    //animator.SetTrigger("Clicked");
                }
            }            
        }

        if (aniSpawn.scene == 3 && aniSpawn.index_track == aniSpawn.index + 1)
        {            
            currentBaseState = animator.GetCurrentAnimatorStateInfo(0);
            if (currentBaseState.IsName("soomong20_clicked"))
            {
                if (currentBaseState.normalizedTime > 1.0f)
                {
                    aniSpawn.index++;
                    DoTransition(0);
                    aniSpawn.index_track = 0;
                }
            }            
        }
    }
    
}
