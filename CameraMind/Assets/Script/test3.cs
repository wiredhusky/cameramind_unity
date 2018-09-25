using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test3 : MonoBehaviour {

    public Test1 test1;
    public test2 Test2;

	// Use this for initialization
	void Start () {
        //test1 = GameObject.FindGameObjectWithTag("Test1").GetComponent<Test1>();
        //Test2 = GameObject.FindGameObjectWithTag("Test2").GetComponent<test2>();
        test1.TestFunction();
        Test2.TestFunction();
		
	}

    public void TestFunction()
    {
        Debug.Log("Test3");
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
