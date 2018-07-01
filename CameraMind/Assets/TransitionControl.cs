using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransitionControl : MonoBehaviour {

    public GameObject levelTransition;
    public GameObject gameOver;

    public SpawnPrefab aniSpawn;

    public delegate void GoToIdle();
    public event GoToIdle goIdle;
    
    public LevelCounter display;

    public bool chkGameOver;
    Animator animator;
    AnimatorStateInfo currentBaseState;

    // Use this for initialization
    void Start () {
        display = FindObjectOfType<LevelCounter>();
        aniSpawn = FindObjectOfType<SpawnPrefab>();
        chkGameOver = false;
	}
    
    public void GameOver()
    {
        animator = aniSpawn.obj[aniSpawn.index].GetComponent<Animator>();
        animator.SetTrigger("gameOver");
        chkGameOver = true;        
    }

    public void ChkClicked()
    {
        animator = aniSpawn.obj[aniSpawn.index_track].GetComponent<Animator>();
        animator.SetTrigger("Clicked");
        aniSpawn.index_track++;
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
                if (currentBaseState.normalizedTime > 1.0f)
                {
                    DoTransition(1);
                    animator.SetTrigger("Idle");
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

        if(aniSpawn.scene == 3)
        {
            if(levelTransition.gameObject.transform.position.y == 0)
            {
                goIdle();
            }
        }
    }

    /*
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
    */
}
