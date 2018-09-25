using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test2 : MonoBehaviour {

    public Test1 test1;
    public test3 Test3;

	// Use this for initialization
	void Start () {

        //test1 = GameObject.FindGameObjectWithTag("Test1").GetComponent<Test1>();
        //Test3 = GameObject.FindGameObjectWithTag("Test3").GetComponent<test3>();
        test1.TestFunction();
        Test3.TestFunction();
		
	}

    public void TestFunction()
    {
        Debug.Log("Test2");
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
