using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test1 : MonoBehaviour {

    public test2 Test2;
    public test3 Test3;

	// Use this for initialization
	void Start () {

        //Test2 = GameObject.FindGameObjectWithTag("Test2").GetComponent<test2>();
        //Test3 = GameObject.FindGameObjectWithTag("Test3").GetComponent<test3>();
        Test2.TestFunction();
        Test3.TestFunction();
	}

    public void TestFunction(){
        Debug.Log("Test1");
    }
	
}
