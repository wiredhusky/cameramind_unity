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
        transitionType = FindObjectOfType<TransitionControl>();
        level = FindObjectOfType<SpawnPrefab>();
        moveIndex = FindObjectOfType<MoveMove>();
        animator = GetComponent<Animator>();
        transitionType.goIdle += SetIdle;        
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
                    transitionType.GameOver();
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
                    animator.SetTrigger("Clicked");
                    transitionType.GameOver();
                }
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

    public void SetIdle()
    {
        //animator = gameObject.GetComponent<Animator>();
        animator.SetTrigger("Idle");
    }
}
