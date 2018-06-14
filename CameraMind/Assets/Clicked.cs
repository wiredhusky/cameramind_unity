using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clicked : MonoBehaviour {

    public TransitionControl transitionType;
    public SpawnPrefab level;
    public Animator animator;
    public MoveMove moveIndex;
    public float a = 1.0f;
    

    private void Start()
    {
        transitionType = FindObjectOfType<TransitionControl>();
        level = FindObjectOfType<SpawnPrefab>();
        moveIndex = FindObjectOfType<MoveMove>();        
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
            //level.obj[level.index - 1].SendMessage("Animate");
            animator = level.obj[level.index - 1].GetComponent<Animator>();
            animator.SetTrigger("gameOver");
        }

        //Debug.Log("Success");
                
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
    /*
    private void FixedUpdate()
    {
        transform.Rotate(Vector3.forward, 360f*Time.deltaTime);
    }*/



    /*
    private void Update()
    {
        Debug.Log(transitionType.hasGameEnded);
        if (transitionType.hasGameEnded)
        {
            if (ComparePos())
            {
                animator.SetTrigger("gameOver");
                
            }
        }
    }*/
}
