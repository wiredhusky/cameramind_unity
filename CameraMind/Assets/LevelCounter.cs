using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class LevelCounter : MonoBehaviour {

    //[SerializeField]
    private Text counter;
    //public SpawnPrefab indicator;
    
	// Use this for initialization
	void Start () {

        //indicator = GameObject.Find("spawner").GetComponent<SpawnPrefab>();
        counter = GetComponent<Text>();		
	}
	
	// Update is called once per frame
	void Update () {
        counter.text = "Level " + GameObject.Find("spawner").GetComponent<SpawnPrefab>().index.ToString();
        //counter.text = "Level " + indicator.index.ToString();
	}
}
