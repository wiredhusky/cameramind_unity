using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class spawn : MonoBehaviour {

    
    public MoveMove move;
    
    //public Clicked tap;    
    public TransitionControl transitionControl;

    public Animator animator;
    public GameObject background;
    
    int randObj, randAni;

    //bool isSet = false;
    
    // Use this for initialization
    /*void Start ()
    {
        //instance = GameObject.FindWithTag("spawner").GetComponent<SpawnPrefab>();
        animator = gameObject.GetComponent<Animator>();
        background = GameObject.FindWithTag("background");        
        //animator = gameObject.GetComponent<Animator>();
        //tap = GetComponent<Clicked>();
    }*/

    
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
        switch (SpawnPrefab.instance.scene)
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
        if (SceneManager.GetActiveScene().name == "MainMenu")
        {
            //SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene().buildIndex);            
            SceneManager.SetActiveScene(SceneManager.GetSceneByName(MainMenu.mainMenu.sceneName));
            Debug.Log("active scene: " + SceneManager.GetActiveScene().name);
            SceneManager.UnloadSceneAsync(0);     
        }

        if(SceneManager.GetActiveScene().name == "GameOver")
        {
            Debug.Log(SpawnPrefab.instance.scene);
            SceneManager.SetActiveScene(SceneManager.GetSceneByName(SpawnPrefab.instance.scene));
            SceneManager.UnloadSceneAsync("GameOver");
        }

        if (!SpawnPrefab.instance.allThingsDone)
        {           
            animator.speed = 0;
            SpawnPrefab.instance.setScale();
            SpawnPrefab.instance.PosSearch();
            SpawnPrefab.instance.SetStart();

            //background.transform.GetChild(0).gameObject.SetActive(true);            
            background.SetActive(true);
            animator.speed = 1;
        }        

        //GameObject.FindWithTag("background").transform.GetChild(0).gameObject.SetActive(true);
        //instance.CalPos();
    }

    /*
    void SetComponent()
    {
        if (!isSet)
        {
            transitionControl = GameObject.FindWithTag("transitionControl").GetComponent<TransitionControl>();

            if (SpawnPrefab.instance.scene == "Flip Horizon" || SpawnPrefab.instance.scene == "Flip Vertical" || SpawnPrefab.instance.scene == "Chaos")
            {
                move = GameObject.FindWithTag("movement").GetComponent<MoveMove>();
            }
            isSet = true;
        }
    }*/

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
        //Debug.Log(move._move);
        move._move = true;
        //Debug.Log(move._move);
    }

}
