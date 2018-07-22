using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawn : MonoBehaviour {

    public SpawnPrefab instance;
    public MoveMove move;
    //public Clicked tap;
    public GameObject gameOver;
    public TransitionControl transitionControl;
    //Animator animator;
    
    // Use this for initialization
    void Start ()
    {
        instance = GameObject.FindWithTag("spawner").GetComponent<SpawnPrefab>();
        transitionControl = GameObject.FindWithTag("transitionControl").GetComponent<TransitionControl>();        
        if(instance.scene == 2)
        {
            move = GameObject.FindWithTag("movement").GetComponent<MoveMove>();
        }
        //animator = gameObject.GetComponent<Animator>();
        //tap = GetComponent<Clicked>();
	}

    public void SetAnimation()
    {
        switch (instance.scene)
        {
            case 6: // temptation
                break;
        }
    }

	public void objCreator()
    {
        switch (instance.scene)
        {
            case 0:
                break;
            case 1:
                instance.SpawnObj();                
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
                break;
            case 7: // vertical flip
                break;
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

    public void DeactiveGameOver()
    {
        gameOver.SetActive(false);        
    }

    private void Update()
    {   
        if (instance.scene == 2)
        {
            if (gameObject.transform.position.y <= -10.1f)
            {
                move._move = true;
                gameObject.transform.position = new Vector3(0, 10.1f, 0);
                gameObject.SetActive(false);
            }
        }        
    }

}
