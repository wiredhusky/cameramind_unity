using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawn : MonoBehaviour {

    public SpawnPrefab instance;
    public MoveMove move;
    //public Clicked tap;    
    public TransitionControl transitionControl;

    Animator animator;
    int randObj, randAni;
    
    // Use this for initialization
    void Start ()
    {
        instance = GameObject.FindWithTag("spawner").GetComponent<SpawnPrefab>();
        transitionControl = GameObject.FindWithTag("transitionControl").GetComponent<TransitionControl>();        
        if(instance.scene == 2 || instance.scene == 10 || instance.scene == 7)
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
        switch (instance.scene)
        {
            case 0:
                break;            
            case 2:
                instance.SpawnObj_Flip();
                break;
            case 3: // track
                instance.SpawnObj();                
                transitionControl.EventHandler();
                break;
            case 4: // twins
                instance.SpawnObj_Twins();
                break;
            case 5: // alone
                instance.SpawnObj_Alone();
                transitionControl.RendererHandler();
                break;
            case 6: // temptation
                instance.SpawnObj();
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
            case 7: // vertical flip
                instance.SpawnObj_Flip();
                break;
            case 10: // mix
                instance.SpawnObj_Flip();
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
            default: // normal, double, triple
                instance.SpawnObj();
                break;
        }        
    }

    public void PauseAni()
    {
        if (!instance.allThingsDone)
        {
            animator = gameObject.GetComponent<Animator>();
            animator.speed = 0;
        }        
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
