using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clicked : MonoBehaviour {
    
    public TransitionControl transitionType;
    public SpawnPrefab level;
    public Animator animator;
    public MoveMove moveIndex;    
    
    private void Start()
    {
        transitionType = GameObject.FindWithTag("transitionControl").GetComponent<TransitionControl>();
        level = GameObject.FindWithTag("spawner").GetComponent<SpawnPrefab>();        
        animator = GetComponent<Animator>();
        transitionType.goIdle += SetIdle;
        transitionType.activeCollider += ActiveCol;
        transitionType.deactiveCollider += DeActiveCol;

        if(level.scene == 2)
        {
            moveIndex = GameObject.FindWithTag("movement").GetComponent<MoveMove>();
        }
        //moveIndex.OnIdleAnimation += GoToIdle;
    }

    /*
    IEnumerator TransitionGameOver()
    {
        while (transitionType.GameOver)
        {
            yield return new WaitForSeconds(0.8f);
            //Debug.Log("GoGo");
            transitionType.DoTransition(1);
            transitionType.GameOver = false;
        }
    }
    */

    private void OnMouseDown()
    {        

        switch (level.scene)
        {
            case 0:
                break;
            case 1:
                transitionType.DeactiveHandler();
                if (ComparePos_Normal())
                {
                    level.index++;
                    transitionType.DoTransition(0);
                    
                }
                else
                {
                    transitionType.DeactiveHandler();
                    transitionType.GameOver();
                }
                //Debug.Log("double click");
                
                break;
            case 2:
                transitionType.DeactiveHandler();
                if (ComparePos())
                {
                    level.index++;
                    Debug.Log(level.index);
                    transitionType.DoTransition(0);                    
                }
                else
                {
                    transitionType.DeactiveHandler();
                    transitionType.GameOver();
                }
                break;
            case 3:                
                if (ComparePos_Track())
                {                    
                    transitionType.ChkClicked();
                }
                else
                {
                    transitionType.DeactiveHandler();
                    animator.SetTrigger("Clicked");
                    transitionType.GameOver();                    
                }
                Debug.Log(level.index_track);
                break;
            case 4:
                transitionType.DeactiveHandler();
                if (ComparePosTwins())
                {
                    level.index_twins += 2;
                    level.index++;
                    transitionType.DoTransition(0);

                }
                else
                {
                    transitionType.DeactiveHandler();
                    transitionType.GameOver();
                }
                break;
        }
    }
    

    private bool ComparePos_Track()
    {   
        if(gameObject.transform.position == level.posList[level.index_track])
        {            
            return true;
        }
        else
        {
            return false;            
        }
    }

    private bool ComparePos_Normal()
    {   
        if (gameObject.transform.position == level.posList[level.index])
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
        if (moveIndex.reverse)
        {
            if (gameObject.transform.position == level.posList[level.index])
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
            if (gameObject.transform.position == moveIndex.OppCenterPos[level.index])
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }

    private bool ComparePosTwins()
    {
        if (level.colored)
        {
            if (gameObject.transform.position == level.posList[level.index_twins])
            {
                level.colored = false;
                return true;
            }
            else
            {
                return false;
            }
        }
        else
        {
            if (gameObject.transform.position == level.posList[level.index_twins+1])
            {
                level.colored = true;
                return true;
            }
            else
            {
                return false;
            }
        }
    }

    public void SetIdle()
    {
        //animator = gameObject.GetComponent<Animator>();
        animator.SetTrigger("Origin");
        
    }

    public void ActiveCol()
    {
        gameObject.GetComponent<PolygonCollider2D>().enabled = true;
    }

    public void DeActiveCol()
    {
        gameObject.GetComponent<PolygonCollider2D>().enabled = false;
    }
}
