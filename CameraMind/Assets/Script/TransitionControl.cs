using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TransitionControl : MonoBehaviour {

    public GameObject LevelTransition;
    public GameObject gameOver;    

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
        if(display == null)
        {
            Debug.Log("Null");
        }
        //SpawnPrefab.instance = GameObject.FindWithTag("spawner").GetComponent<SpawnPrefab>();
        //SpawnPrefab.instance = FindObjectOfType<SpawnPrefab>();
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
        if(SpawnPrefab.instance.index == 0)
        {
            enableRenderer();
        }        
    }
    
    public void GameOver()
    {
        switch (SpawnPrefab.instance.scene)
        {
            case 0:
                break;
            case 3:
                animator = SpawnPrefab.instance.obj[SpawnPrefab.instance.index_track].GetComponent<Animator>();
                break;
            case 4:
                if (SpawnPrefab.instance.colored)
                {
                    animator = SpawnPrefab.instance.obj[SpawnPrefab.instance.index_twins].GetComponent<Animator>();
                }
                else
                {
                    animator = SpawnPrefab.instance.obj[SpawnPrefab.instance.index_twins+1].GetComponent<Animator>();
                }                
                break;
            case 5:
                animator = SpawnPrefab.instance.obj[SpawnPrefab.instance.index_alone].GetComponent<Animator>();
                break;            
            default: // normal, double, triple, vertical/horizontal flip, temptation
                animator = SpawnPrefab.instance.obj[SpawnPrefab.instance.index].GetComponent<Animator>();
                break;
        }        
        animator.SetTrigger("gameOver");
        chkGameOver = true;        
    }

    public void ChkClicked()
    {
        animator = SpawnPrefab.instance.obj[SpawnPrefab.instance.index_track].GetComponent<Animator>();
        animator.SetTrigger("Clicked");
        SpawnPrefab.instance.index_track++;
        if(SpawnPrefab.instance.index_track == SpawnPrefab.instance.index + 1)
        {
            DeactiveHandler();
        }
        Debug.Log("OK");
    }

    public void DoTransition(int type)
    {
        switch (type)
        {
            case 0: // SpawnPrefab.instance Transition
                display.CountLevel();
                LevelTransition.SetActive(true);
                break;
            case 1:
                //display.GameResult();
                //meOver.SetActive(true);
                SceneManager.LoadScene("GameOver", LoadSceneMode.Additive);
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

        if (SpawnPrefab.instance.scene == 3 && SpawnPrefab.instance.index_track == SpawnPrefab.instance.index + 1)
        {            
            currentBaseState = animator.GetCurrentAnimatorStateInfo(0);
            if (currentBaseState.IsName("soomong20_clicked"))
            {
                if (currentBaseState.normalizedTime > 1.0f)
                {
                    SpawnPrefab.instance.index++;
                    DoTransition(0);
                    SpawnPrefab.instance.index_track = 0;
                }
            }            
        }
    }
    
}
