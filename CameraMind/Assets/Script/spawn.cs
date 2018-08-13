using System.Collections;
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
        if (SceneManager.GetActiveScene().name == "Flip Horizon" || SceneManager.GetActiveScene().name == "Flip Vertical" || SceneManager.GetActiveScene().name == "Chaos")
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
        //SpawnPrefab.instance.scene = SceneManager.GetActiveScene().buildIndex;
        switch (SceneManager.GetActiveScene().name)
        {
            case "MainMenu":
                break;            
            case "Flip Horizon":
                SpawnPrefab.instance.SpawnObj_Flip();
                break;
            case "Track": // track
                SpawnPrefab.instance.SpawnObj();                
                transitionControl.EventHandler();                
                break;
            case "Twins": // twins
                SpawnPrefab.instance.SpawnObj_Twins();
                break;
            case "Alone": // alone
                SpawnPrefab.instance.SpawnObj_Alone();
                transitionControl.RendererHandler();
                break;
            case "Temptation": // temptation
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
            case "Flip Vertical": // vertical flip
                SpawnPrefab.instance.SpawnObj_Flip();
                break;
            case "Chaos": // mix
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
