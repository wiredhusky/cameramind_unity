using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LevelCounter : MonoBehaviour {


    public TextMeshProUGUI counter;
    public SpawnPrefab indicator;
    
    // Use this for initialization
    void Start () {

        //counter = FindObjectOfType<TextMeshProUGUI>();
        //indicator = gameObject.GetComponent<SpawnPrefab>();
        indicator = FindObjectOfType<SpawnPrefab>();
                
        counter = gameObject.GetComponent<TextMeshProUGUI>();

        //Debug.Log(indicator.index);
        CountLevel();
        
        
        
	}

    public void CountLevel()
    {
        counter.text = "Level " + (indicator.index + 1).ToString();
    }
	
}
