using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawn : MonoBehaviour {

    public SpawnPrefab instance;

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
	
}
