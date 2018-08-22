using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LevelCounter : MonoBehaviour {


    public TextMeshProUGUI counter;
    //public SpawnPrefab indicator;
    
    // Use this for initialization
    void Start () {
        
        //counter = FindObjectOfType<TextMeshProUGUI>();
        //indicator = gameObject.GetComponent<SpawnPrefab>();
        //indicator = FindObjectOfType<SpawnPrefab>();
        //indicator = GameObject.FindWithTag("spawner").GetComponent<SpawnPrefab>();
        
        //counter = gameObject.GetComponent<TextMeshProUGUI>();
        //Debug.Log(indicator.index);
        counter.text = "Level " + (SpawnPrefab.instance.index + 1).ToString();
        //CountSpawnPrefab.instance();
	}

    
    public void CountLevel()
    {
        //counter.text = "SpawnPrefab.instance " + (indicator.index + 1).ToString();
        counter.text = "Level " + (SpawnPrefab.instance.index + 1).ToString();     
    }
    

    /*
    public void GameResult()
    {
        counter.text = "SpawnPrefab.instance " + (indicator.index).ToString();
        Debug.Log(counter.text);
    }*/
	
}
