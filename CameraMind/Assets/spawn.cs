﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawn : MonoBehaviour {

    public SpawnPrefab instance;
    public GameObject gameOver;
    

    // Use this for initialization
    void Start ()
    {
        instance = FindObjectOfType<SpawnPrefab>();

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
