using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawn : MonoBehaviour {

    public SpawnPrefab instance;
    public MoveMove move;
    public GameObject gameOver;
    

    // Use this for initialization
    void Start ()
    {
        instance = FindObjectOfType<SpawnPrefab>();
        move = FindObjectOfType<MoveMove>();

	}
	
    public void MoveNow()
    {
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
