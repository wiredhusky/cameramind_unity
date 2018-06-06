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
	
    public void MoveNow()
    {
        //Debug.Log("Move");
        move.objTranslate();
    }

	public void objCreator()
    {
        instance.SpawnObj();
    }

    public void SetObj()
    {        
        gameObject.SetActive(false);
    }

    public void DeactiveGameOver()
    {
        gameOver.SetActive(false);
    }
	
}
