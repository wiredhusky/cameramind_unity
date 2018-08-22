using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameOverLevel : MonoBehaviour {

    public TextMeshProUGUI counter;
    //private SpawnPrefab indicator;

	// Use this for initialization
	void Start () {

        //counter = gameObject.GetComponent<TextMeshProUGUI>();
        //indicator = GameObject.FindWithTag("spawner").GetComponent<SpawnPrefab>();
        counter.text = "Level " + (SpawnPrefab.instance.index).ToString();
		
	}
	
	
}
