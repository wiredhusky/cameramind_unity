using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class MoveMove : MonoBehaviour {
    
    //public bool _move = false;
    
    //float speed, currentTime, lerpTime=1.5f;

    /*
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
                    if(InGameManager.inGameManager.obj[InGameManager.inGameManager.index].transform.position.x < 0)
                    {
                        InGameManager.inGameManager.obj[InGameManager.inGameManager.index].transform.Rotate(0, 0, 0);
                    }
                    else
                    {
                        InGameManager.inGameManager.obj[InGameManager.inGameManager.index].transform.Rotate(0, 180, 0);
                    }
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
                    //change sprite direction whenever they arrive the destination position
                    if (InGameManager.inGameManager.obj[InGameManager.inGameManager.index].transform.position.x < 0)
                    {
                        InGameManager.inGameManager.obj[InGameManager.inGameManager.index].transform.Rotate(0, 0, 0);
                    }
                    else
                    {
                        InGameManager.inGameManager.obj[InGameManager.inGameManager.index].transform.Rotate(0, 180, 0);
                    }
                    _move = false;
                    InGameManager.inGameManager.turnChk = true;        
                    InGameManager.inGameManager.ActiveHandler();
                    currentTime = 0;
                }
            }
        }
    }*/

    public void DoMove()
    {
        switch(InGameManager.inGameManager.sceneName){
            case "Flip Horizon":
                if (InGameManager.inGameManager.turnChk)
                {
                    for (int i = 0; i <= InGameManager.inGameManager.index; i++)
                    {
                        InGameManager.inGameManager.obj[i].transform.DOMove(InGameManager.inGameManager.oppCenterPos[i], 0.8f).SetEase(Ease.OutQuint).OnComplete(FlipSprite);
                    }
                    InGameManager.inGameManager.turnChk = false;
                }
                else
                {
                    for (int i = 0; i <= InGameManager.inGameManager.index; i++)
                    {
                        InGameManager.inGameManager.obj[i].transform.DOMove(InGameManager.inGameManager.posList[i], 0.8f).SetEase(Ease.OutQuint).OnComplete(FlipSprite);
                    }
                    InGameManager.inGameManager.turnChk = true;
                }

                InGameManager.inGameManager.ActiveHandler();
                break;
            case "Flip Vertical":
                if (InGameManager.inGameManager.turnChk)
                {
                    for (int i = 0; i <= InGameManager.inGameManager.index; i++)
                    {
                        InGameManager.inGameManager.obj[i].transform.DOMove(InGameManager.inGameManager.oppCenterPos[i], 0.8f).SetEase(Ease.OutQuint);
                    }
                    InGameManager.inGameManager.turnChk = false;
                }
                else
                {
                    for (int i = 0; i <= InGameManager.inGameManager.index; i++)
                    {
                        InGameManager.inGameManager.obj[i].transform.DOMove(InGameManager.inGameManager.posList[i], 0.8f).SetEase(Ease.OutQuint);
                    }
                    InGameManager.inGameManager.turnChk = true;
                }

                InGameManager.inGameManager.ActiveHandler();
                break;
        }
    }
    
    private void FlipSprite()
    {
        for (int i = 0; i <= InGameManager.inGameManager.index; i++){
            if(InGameManager.inGameManager.obj[i].transform.position.x > 0){
                InGameManager.inGameManager.obj[i].transform.DORotate(new Vector3(0, 180, 0), 0.3f);
            }else{
                InGameManager.inGameManager.obj[i].transform.DORotate(new Vector3(0, 0, 0), 0.3f);
            }
        }
    }

    /*
    private void Update()
    {   
        if(_move)
        {
            //TempMove();
        }
    }*/
}
