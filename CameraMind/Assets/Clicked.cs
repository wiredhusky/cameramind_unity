using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clicked : MonoBehaviour {
    
    public TransitionControl transitionType;
    public SpawnPrefab level;
    public Animator animator;
    public MoveMove moveIndex;
    public AnimatorStateInfo currentBaseState;
    public Animator animatorFinalObject;
    
    private void Start()
    {   
        transitionType = FindObjectOfType<TransitionControl>();
        level = FindObjectOfType<SpawnPrefab>();
        moveIndex = FindObjectOfType<MoveMove>();
        animator = GetComponent<Animator>();        
        
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
                if (ComparePos_Normal())
                {
                    level.index++;
                    transitionType.DoTransition(0);
                    
                }
                else
                {
                    //level.obj[level.index - 1].SendMessage("Animate");
                    animator = level.obj[level.index].GetComponent<Animator>();
                    animator.SetTrigger("gameOver");
                    
                    //StartCoroutine("TransitionGameOver");
                }
                //Debug.Log("double click");
                
                break;
            case 2:
                if (ComparePos())
                {
                    level.index++;
                    transitionType.DoTransition(0);                    
                }
                else
                {
                    //level.obj[level.index - 1].SendMessage("Animate");
                    animator = level.obj[level.index].GetComponent<Animator>();
                    animator.SetTrigger("gameOver");
                    //StartCoroutine("TransitionGameOver");
                }
                break;
            case 3:
                if (ComparePos_Track())
                {
                    level.index_track++;
                    animator = gameObject.GetComponent<Animator>();
                    animator.SetTrigger("Clicked");                    
                    //transition is operated in the event of Clicked animation
                    //Don't use animation EVENT!!!
                }
                else
                {
                    animator = level.obj[level.index_track].GetComponent<Animator>();
                    animator.SetTrigger("gameOver");
                    //StartCoroutine("TransitionGameOver");
                }
                //OK sign
                //Trigger Animation or New Sprite
                //if last tap is last object Do Transition(Success) else Do Transition(Fail)
                break;
        }
    }

    /*
    public void destPosCal()
    {
        
        if (moveIndex.calOrnot)
        {
            if (gameObject.transform.localScale.x == 0.20f)
            {
                destPos.x = gameObject.transform.position.x * -1.0f - level.onScreenScale_20.x;
                destPos.y = gameObject.transform.position.y;
                destPos.z = 0;
            }
            else if (gameObject.transform.localScale.x == 0.25f)
            {
                destPos.x = gameObject.transform.position.x * -1.0f - level.onScreenScale_25.x;
                destPos.y = gameObject.transform.position.y;
                destPos.z = 0;
            }
            else if (gameObject.transform.localScale.x == 0.30f)
            {
                destPos.x = gameObject.transform.position.x * -1.0f - level.onScreenScale_30.x;
                destPos.y = gameObject.transform.position.y;
                destPos.z = 0;
            }
            else if (gameObject.transform.localScale.x == 0.35f)
            {
                destPos.x = gameObject.transform.position.x * -1.0f - level.onScreenScale_35.x;
                destPos.y = gameObject.transform.position.y;
                destPos.z = 0;
            }
            else if (gameObject.transform.localScale.x == 0.40f)
            {
                destPos.x = gameObject.transform.position.x * -1.0f - level.onScreenScale_40.x;
                destPos.y = gameObject.transform.position.y;
                destPos.z = 0;
            }
        }
        moveIndex.calOrnot = false;
    }*/

        /*
    public void MoveSoomong()
    {
        currentTime += Time.deltaTime;
        speed = currentTime / lerpTime;
        speed = Mathf.Sin(speed * Mathf.PI * 0.33f);

        gameObject.transform.position = Vector3.Lerp(gameObject.transform.position, destPos, speed);
        if(gameObject.transform.position == destPos)
        {
            if (moveIndex.reverse)
            {
                moveIndex.reverse = false;
            }else
            {
                moveIndex.reverse = true;
            }
            moveIndex._move = false;
            moveIndex.calOrnot = true;
            gameObject.GetComponent<PolygonCollider2D>().enabled = true;
            currentTime = 0;
        }
    }*/



    /*
    public void MovePrefab()
    {
        currentTime += Time.deltaTime;
        speed = currentTime / lerpTime;
        speed = Mathf.Sin(speed * Mathf.PI * 0.33f);
        
        if (reverse)
        {
            gameObject.transform.position = Vector3.Lerp(gameObject.transform.position, moveIndex.OppCenterPosOppCenterPos[i], speed);
            spawner.obj[i].transform.position = Vector3.Lerp(spawner.obj[i].transform.position, OppCenterPos[i], speed);

                if (spawner.obj[spawner.index - 1].transform.position == OppCenterPos[spawner.index - 1])
                {
                    _move = false;
                    reverse = false;
                    spawner.obj[spawner.index - 1].GetComponent<PolygonCollider2D>().enabled = true;
                    currentTime = 0;
                }
            
        }
        else
        {
            for (int i = 0; i < spawner.index; i++)
            {
                spawner.obj[i].transform.position = Vector3.Lerp(spawner.obj[i].transform.position, spawner.posList[i], speed);

                if (spawner.obj[spawner.index - 1].transform.position == spawner.posList[spawner.index - 1])
                {
                    _move = false;
                    reverse = true;
                    spawner.obj[spawner.index - 1].GetComponent<PolygonCollider2D>().enabled = true;
                    currentTime = 0;
                }
            }
        }
    }*/

    /*
    public void Animate()
    {
        animator.SetTrigger("gameOver");
    }*/

        /*
    public void GameEnded()
    {
        transitionType.DoTransition(1);        
    }*/

    private bool ComparePos_Track()
    {
        Vector3 tempPos;
        tempPos = level.PosReturn_Track(level.index_track);
        
        Debug.Log(level.index_track);
        if(gameObject.transform.position == tempPos)
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

    /*
    void DoTransitonTrack()
    {
        if (level.index_track == level.index)
        {
            transitionType.DoTransition(0);
            level.index_track = 0;
        }
    }*/

    private bool ComparePos()
    {
        Vector3 tempPos;

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
            tempPos = moveIndex.OppCenterPos[level.index];
            //Debug.Log("Opp: " + moveIndex.OppCenterPos[level.index - 1]);
            //Debug.Log(gameObject.transform.position);
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

    public void GoToIdle()
    {
        //animator = gameObject.GetComponent<Animator>();
        animator.SetTrigger("Idle");
    }

    private void Update()
    {
        currentBaseState = animator.GetCurrentAnimatorStateInfo(0);
        if (currentBaseState.IsName("soomong20_twinkle"))
        {            
            if(currentBaseState.normalizedTime > 1.0f)
            {   
                transitionType.DoTransition(1);
                animator.SetTrigger("Idle");                
            }            
        }

        if (currentBaseState.IsName("soomong20_clicked"))
        {
            if (currentBaseState.normalizedTime > 1.0f && level.index_track == level.index + 1)
            {
                level.index++;
                transitionType.DoTransition(0);
                level.index_track = 0;
            }
        }           
        
    }

}
