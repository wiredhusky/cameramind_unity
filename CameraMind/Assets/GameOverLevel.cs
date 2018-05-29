﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameOverLevel : MonoBehaviour {

    private TextMeshProUGUI counter;
    private SpawnPrefab indicator;

	// Use this for initialization
	void Start () {

        counter = gameObject.GetComponent<TextMeshProUGUI>();
        indicator = FindObjectOfType<SpawnPrefab>();
        counter.text = "Level " + (indicator.index-1).ToString();
		
	}
	
	
}
