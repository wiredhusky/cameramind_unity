using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clicked : MonoBehaviour {

    public TransitionControl transitionType;
    public SpawnPrefab level;
    public Animator animator;
    

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
            level.obj[level.index - 1].SendMessage("Animate");
        }

        //Debug.Log("Success");
                
    }

    public void Animate()
    {
        animator.SetTrigger("gameOver");
    }

    public void GameEnded()
    {
        transitionType.DoTransition(1);
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
