using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clicked : MonoBehaviour {

    public TransitionControl transitionType;
    public SpawnPrefab level;
    public Animator animator;
    public MoveMove moveIndex;
    int index_track = 0;
    //public float a = 1.0f;
    

    private void Start()
    {
        transitionType = FindObjectOfType<TransitionControl>();
        level = FindObjectOfType<SpawnPrefab>();
        moveIndex = FindObjectOfType<MoveMove>();        
    }

    private void OnMouseDown()
    {
        switch (level.scene)
        {
            case 0:
                break;
            case 1:
                if (ComparePos_Normal())
                {
                    transitionType.DoTransition(0);       
                }
                else
                {
                    //level.obj[level.index - 1].SendMessage("Animate");
                    animator = level.obj[level.index - 1].GetComponent<Animator>();
                    animator.SetTrigger("gameOver");
                }
                //Debug.Log("double click");
                
                break;
            case 2:
                if (ComparePos())
                {
                    transitionType.DoTransition(0);
                }
                else
                {
                    //level.obj[level.index - 1].SendMessage("Animate");
                    animator = level.obj[level.index - 1].GetComponent<Animator>();
                    animator.SetTrigger("gameOver");
                }
                break;
            case 3:
                if (ComparePos_Track())
                {
                    if(index_track == level.index)
                    {
                        transitionType.DoTransition(0);
                        //This is Problem when first prefab is cliked index_track is initialized!!!!!!!
                        //index_track = 0;
                    }
                }
                else
                {
                    animator = level.obj[level.index - 1].GetComponent<Animator>();
                    animator.SetTrigger("gameOver");
                }
                //OK sign
                //Trigger Animation or New Sprite
                //if last tap is last object Do Transition(Success) else Do Transition(Fail)
                break;
        }
    }

    /*
    public void Animate()
    {
        animator.SetTrigger("gameOver");
    }*/

    public void GameEnded()
    {
        transitionType.DoTransition(1);        
    }

    private bool ComparePos_Track()
    {
        Vector3 tempPos;
        tempPos = level.PosReturn_Track(index_track);
        //Debug.Log(tempPos);
        //Debug.Log(gameObject.transform.position);
        Debug.Log(index_track);
        if(gameObject.transform.position == tempPos)
        {
            index_track++;
            Debug.Log(index_track);
            return true;
        }
        else
        {
            return false;
        }
    }

    private bool ComparePos_Normal()
    {
        Vector3 tempPos;
        tempPos = level.PosReturn();
        
        if (gameObject.transform.position == tempPos)
        {
            return true;
        }
        else
        {
            return false;
        }
        
    }

    private bool ComparePos()
    {
        Vector3 tempPos;

        //Debug.Log(tempPos.x);
        //Debug.Log(gameObject.transform.position.x); // obj가 하나 생성되면 index는 1개 올라갔기 때문에 2번째 값을 보내줌
        if (moveIndex.reverse)
                {
                    tempPos = level.PosReturn();
                    if (gameObject.transform.position == tempPos)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    tempPos = moveIndex.OppCenterPos[level.index - 1];
                    if (gameObject.transform.position == tempPos)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
    }
}
