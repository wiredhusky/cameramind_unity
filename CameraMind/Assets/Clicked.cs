using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clicked : MonoBehaviour {

    public TransitionControl transitionType;
    public SpawnPrefab level;

    private void Start()
    {
        transitionType = FindObjectOfType<TransitionControl>();
        level = FindObjectOfType<SpawnPrefab>();
    }

    private void OnMouseDown()
    {
        //Debug.Log(ComparePos());
        
        if (ComparePos())
        {
            transitionType.DoTransition(0);
        }
        else
        {
            transitionType.DoTransition(1);
        }

        //Debug.Log("Success");

        
    }

    private bool ComparePos()
    {
        Vector3 tempPos;
        tempPos = level.PosReturn();
        //Debug.Log(tempPos.x);
        //Debug.Log(gameObject.transform.position.x); // obj가 하나 생성되면 index는 1개 올라갔기 때문에 2번째 값을 보내줌
        if(gameObject.transform.position == tempPos)
        {
            return true;
            
        }
        else
        {
            return false;
            
        }
    }
}
