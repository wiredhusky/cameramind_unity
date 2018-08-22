using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clicked : MonoBehaviour {
    
    TransitionControl transitionType;
    //public SpawnPrefab SpawnPrefab.instance;
    public Animator animator;
    public CircleCollider2D _collider;
    public Renderer _renderer;
    //public MoveMove moveIndex;
    
    private void Start()
    {
        transitionType = GameObject.FindWithTag("transitionControl").GetComponent<TransitionControl>();
        //SpawnPrefab.instance = GameObject.FindWithTag("spawner").GetComponent<SpawnPrefab>();        
        //animator = GetComponent<Animator>();

        //_collider = gameObject.GetComponent<CircleCollider2D>();
        //_renderer = gameObject.GetComponent<Renderer>();        
        
        transitionType.activeCollider += ActiveCol;
        transitionType.deactiveCollider += DeActiveCol;
        

        switch (SpawnPrefab.instance.scene)
        {            
            case "Track": // Track
                transitionType.goIdle += SetIdle;
                break;
            case "Alone": //Alone, renedere enabled = true;
                transitionType.enableRenderer += EnableRenderer;
                break;
            default:
                break;            
        }
    }

    private void OnMouseUp()
    {

        transitionType.ComPos(gameObject.transform.position, animator);

        /*
        switch (SpawnPrefab.instance.scene)
        {   
            default:
                transitionType.DeactiveHandler();
                if (ComparePos_Normal())
                {
                    SpawnPrefab.instance.index++;
                    transitionType.DoTransition(0);
                    
                }
                else
                {
                    transitionType.GameOver();
                }
                //Debug.Log("double click");                
                break;
            case 2:
                transitionType.DeactiveHandler();
                if (ComparePos())
                {
                    SpawnPrefab.instance.index++;
                    Debug.Log(SpawnPrefab.instance.index);
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
                    transitionType.DeactiveHandler();
                    animator.SetTrigger("Clicked");
                    transitionType.GameOver();                    
                }
                Debug.Log(SpawnPrefab.instance.index_track);
                break;
            case 4:
                transitionType.DeactiveHandler();
                if (ComparePosTwins())
                {
                    SpawnPrefab.instance.index_twins += 2;
                    SpawnPrefab.instance.index++;
                    transitionType.DoTransition(0);

                }
                else
                {
                    transitionType.GameOver();
                }
                break;
            case 5:
                transitionType.DeactiveHandler();
                if (ComparePos_Alone())
                {
                    SpawnPrefab.instance.index++;
                    SpawnPrefab.instance.index_alone++;
                    transitionType.DoTransition(0);
                }
                else
                {
                    transitionType.GameOver();
                }
                break;            
            case 7: // vertical flip
                transitionType.DeactiveHandler();
                if (ComparePos())
                {
                    SpawnPrefab.instance.index++;
                    Debug.Log(SpawnPrefab.instance.index);
                    transitionType.DoTransition(0);
                }
                else
                {
                    transitionType.GameOver();
                }
                break;
            case 10:
                transitionType.DeactiveHandler();
                if (ComparePos())
                {
                    SpawnPrefab.instance.index++;
                    Debug.Log(SpawnPrefab.instance.index);
                    transitionType.DoTransition(0);
                }
                else
                {
                    transitionType.GameOver();
                }
                break;
        }*/
    }
    /*

    private bool ComparePos_Alone()
    {
        if (gameObject.transform.position == SpawnPrefab.instance.posList[SpawnPrefab.instance.index_alone])
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    

    private bool ComparePos_Track()
    {   
        if(gameObject.transform.position == SpawnPrefab.instance.posList[SpawnPrefab.instance.index_track])
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
        if (gameObject.transform.position == SpawnPrefab.instance.posList[SpawnPrefab.instance.index])
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
            if (gameObject.transform.position == SpawnPrefab.instance.posList[SpawnPrefab.instance.index])
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
            if (gameObject.transform.position == moveIndex.OppCenterPos[SpawnPrefab.instance.index])
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
        if (SpawnPrefab.instance.colored)
        {
            if (gameObject.transform.position == SpawnPrefab.instance.posList[SpawnPrefab.instance.index_twins])
            {
                SpawnPrefab.instance.colored = false;
                return true;
            }
            else
            {
                return false;
            }
        }
        else
        {
            if (gameObject.transform.position == SpawnPrefab.instance.posList[SpawnPrefab.instance.index_twins+1])
            {
                SpawnPrefab.instance.colored = true;
                return true;
            }
            else
            {
                return false;
            }
        }
    }*/

    public void SetIdle()
    {
        //animator = gameObject.GetComponent<Animator>();
        animator.SetTrigger("Origin");
        
    }

    public void ActiveCol()
    {
        _collider.enabled = true;
        //gameObject.GetComponent<CircleCollider2D>().enabled = true;
    }

    public void DeActiveCol()
    {
        _collider.enabled = true;
        //gameObject.GetComponent<CircleCollider2D>().enabled = false;
    }

    public void EnableRenderer()
    {
        _renderer.enabled = true;
        //gameObject.GetComponent<Renderer>().enabled = true;
    }
}
