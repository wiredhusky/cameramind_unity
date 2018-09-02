using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour {

    public GameObject timer;
    public bool setTimer = false;
    float speed = 1;
    float sec = 0;
    Vector3 target;

	// Use this for initialization
	void Start () {
        target = new Vector3(-2.96f, -4.38f, 0);        
	}
	
	// Update is called once per frame
	void Update () {
        if (setTimer)
        {
            sec += speed * Time.deltaTime;
            timer.transform.position = Vector3.MoveTowards(timer.transform.position, target, speed * Time.deltaTime);
            Debug.Log("Second: " + sec);
            if(timer.transform.position == target)
            {
                setTimer = false;
            }
        }        
	}
}
