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
        
        if (GameManager.gameManager.turnChk)
        {
            for (int i = 0; i <= GameManager.gameManager.index; i++)
            {   
                GameManager.gameManager.obj[i].transform.position = Vector3.Lerp(GameManager.gameManager.obj[i].transform.position, GameManager.gameManager.oppCenterPos[i], speed);
                
                if (GameManager.gameManager.obj[GameManager.gameManager.index].transform.position == GameManager.gameManager.oppCenterPos[GameManager.gameManager.index])
                {   
                    _move = false;
                    GameManager.gameManager.turnChk = false;
                    GameManager.gameManager.ActiveHandler();
                    currentTime = 0;
                }
            }
        }
        else
        {
            for (int i = 0; i <= GameManager.gameManager.index; i++)
            {
                GameManager.gameManager.obj[i].transform.position = Vector3.Lerp(GameManager.gameManager.obj[i].transform.position, GameManager.gameManager.posList[i], speed);
                
                if (GameManager.gameManager.obj[GameManager.gameManager.index].transform.position == GameManager.gameManager.posList[GameManager.gameManager.index])
                {   
                    _move = false;
                    GameManager.gameManager.turnChk = true;        
                    GameManager.gameManager.ActiveHandler();
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
