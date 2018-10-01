using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveMove : MonoBehaviour {
    
    public bool _move = false;
    
    float speed, currentTime, lerpTime=1.5f;

    public void TempMove()
    {
        currentTime += Time.deltaTime;
        speed = currentTime / lerpTime;
        speed = Mathf.Sin(speed * Mathf.PI * 0.33f);
        
        if (InGameManager.inGameManager.turnChk)
        {
            for (int i = 0; i <= InGameManager.inGameManager.index; i++)
            {   
                InGameManager.inGameManager.obj[i].transform.position = Vector3.Lerp(InGameManager.inGameManager.obj[i].transform.position, InGameManager.inGameManager.oppCenterPos[i], speed);
                
                if (InGameManager.inGameManager.obj[InGameManager.inGameManager.index].transform.position == InGameManager.inGameManager.oppCenterPos[InGameManager.inGameManager.index])
                {   
                    _move = false;
                    InGameManager.inGameManager.turnChk = false;
                    InGameManager.inGameManager.ActiveHandler();
                    currentTime = 0;
                }
            }
        }
        else
        {
            for (int i = 0; i <= InGameManager.inGameManager.index; i++)
            {
                InGameManager.inGameManager.obj[i].transform.position = Vector3.Lerp(InGameManager.inGameManager.obj[i].transform.position, InGameManager.inGameManager.posList[i], speed);
                
                if (InGameManager.inGameManager.obj[InGameManager.inGameManager.index].transform.position == InGameManager.inGameManager.posList[InGameManager.inGameManager.index])
                {   
                    _move = false;
                    InGameManager.inGameManager.turnChk = true;        
                    InGameManager.inGameManager.ActiveHandler();
                    currentTime = 0;
                }
            }
        }
    }

    private void Update()
    {   
        if(_move)
        {
            TempMove();
        }
    }
}
