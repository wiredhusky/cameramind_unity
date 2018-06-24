using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawn : MonoBehaviour {

    public SpawnPrefab instance;
    public MoveMove move;
    //public Clicked tap;
    public GameObject gameOver;
    

    // Use this for initialization
    void Start ()
    {
        instance = FindObjectOfType<SpawnPrefab>();
        move = FindObjectOfType<MoveMove>();
        //tap = GetComponent<Clicked>();

	}
    /*
    public void ActiveClicked()
    {
        tap.enabled = true;
    }*/
	
    /*
    public void MoveNow()
    {
        //Debug.Log("Move");
        move.objTranslate();  
        //y position -10.2f
    }*/

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
            case 3:
                instance.SpawnObj();
                break;
        }        
    }

    public void SetObj()
    {        
        gameObject.SetActive(false);
    }

    public void DeactiveGameOver()
    {
        gameOver.SetActive(false);        
    }

    private void FixedUpdate()
    {       
        if(gameObject.transform.position.y <= -10.1f)
        {               
            move._move = true;
            gameObject.transform.position = new Vector3(0, 10.1f, 0);
            gameObject.SetActive(false);
        }
    }

}
