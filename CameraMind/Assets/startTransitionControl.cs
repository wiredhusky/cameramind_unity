using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class startTransitionControl : MonoBehaviour {
        
    MainMenu mainMenu;
    
	// Use this for initialization
	void Start () {
        mainMenu = GameObject.FindWithTag("MainMenu").GetComponent<MainMenu>();
        switch (mainMenu.sceneName)
        {
            case "Normal":
                //GameObject.FindWithTag("startCanvas").transform.GetChild(0).gameObject.SetActive(true);
                GameObject.FindWithTag("startCanvas").transform.Find("startNormalTransition").gameObject.SetActive(true);
                break;                    
            default:
                break;
        }
	}
	
}
