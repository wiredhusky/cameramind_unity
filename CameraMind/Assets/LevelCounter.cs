using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LevelCounter : MonoBehaviour {


    public TextMeshProUGUI counter;
    public SpawnPrefab indicator;
    
    // Use this for initialization
    void Start () {

        counter = FindObjectOfType<TextMeshProUGUI>();
        //indicator = FindObjectOfType<SpawnPrefab>();        

        //counter.text = "Level " + (indicator.index+1).ToString();
        
	}
	
	// Update is called once per frame
	void Update () {
        //counter.text = "Level " + indicator.index;
        //counter.text = "Level " + (indicator.index + 1).ToString();
    }
}
