using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clicked : MonoBehaviour {

    public TransitionControl transitionType;
    public SpawnPrefab level;
    public Animator animator;
    public MoveMove moveIndex;

    Vector3 destPos, startPos;

    float currentTime, lerpTime=1.5f, speed;
    bool reverse = true;
        
    //public float a = 1.0f;
    

    private void Start()
    {
        transitionType = FindObjectOfType<TransitionControl>();
        level = FindObjectOfType<SpawnPrefab>();
        moveIndex = FindObjectOfType<MoveMove>();
        startPos = gameObject.transform.position;
        //Debug.Log(gameObject.transform.localScale);

        if(gameObject.transform.localScale.x == 0.2f)
        {
            destPos.x = gameObject.transform.position.x * -1.0f - level.onScreenScale_20.x;
            destPos.y = gameObject.transform.position.y;
        }else if(gameObject.transform.localScale.x == 0.25f)
        {
            destPos.x = gameObject.transform.position.x * -1.0f - level.onScreenScale_25.x;
            destPos.y = gameObject.transform.position.y;
        }


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
                    animator = level.obj[level.index_track-1].GetComponent<Animator>();
                    animator.SetTrigger("Clicked");
                    //transition is operated in the event of Clicked animation
                    //Don't use animation EVENT!!!
                }
                else
                {
                    animator = level.obj[level.index_track].GetComponent<Animator>();
                    animator.SetTrigger("gameOver");
                }
                //OK sign
                //Trigger Animation or New Sprite
                //if last tap is last object Do Transition(Success) else Do Transition(Fail)
                break;
        }
    }
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

    public void GameEnded()
    {
        transitionType.DoTransition(1);        
    }

    private bool ComparePos_Track()
    {
        Vector3 tempPos;
        tempPos = level.PosReturn_Track(level.index_track);
        
        Debug.Log(level.index_track);
        if(gameObject.transform.position == tempPos)
        {
            level.index_track++;
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

    void DoTransitonTrack()
    {
        if (level.index_track == level.index)
        {
            transitionType.DoTransition(0);
            level.index_track = 0;
        }
    }

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
