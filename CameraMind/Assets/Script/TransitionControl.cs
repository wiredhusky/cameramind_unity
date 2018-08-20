using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TransitionControl : MonoBehaviour {

    public GameObject LevelTransition;
    //public GameObject gameOver;    

    public delegate void GoToIdle();
    public event GoToIdle goIdle;
    public event GoToIdle activeCollider;
    public event GoToIdle deactiveCollider;
    public event GoToIdle enableRenderer;

    MoveMove moveIndex;

    public LevelCounter display;
    public bool chkGameOver;
    Animator animator;
    AnimatorStateInfo currentBaseState;

    // Use this for initialization
    void Start () {
        display = GameObject.FindWithTag("LevelCounter").GetComponent<LevelCounter>();
        chkGameOver = false;
        if(SpawnPrefab.instance.scene == "Flip Horizon" || SpawnPrefab.instance.scene == "Flip Vertical" || SpawnPrefab.instance.scene == "Chaos"){
            moveIndex = GameObject.FindWithTag("movement").GetComponent<MoveMove>();
        }
        if(moveIndex == null)
        {
            Debug.Log("Move Index is Null");
        }
	}

    public void ComPos(Vector3 _objPos, Animator _animator)
    {
        
        switch (SpawnPrefab.instance.scene)
        {
            default:
                DeactiveHandler();
                if (ComparePos_Normal(_objPos))
                {
                    SpawnPrefab.instance.index++;
                    DoTransition(0);

                }
                else
                {
                    GameOver();
                }
                //Debug.Log("double click");                
                break;
            case "Flip Horizon":
                Debug.Log("Horizontal");
                DeactiveHandler();
                if (ComparePos(_objPos))
                {
                    SpawnPrefab.instance.index++;
                    Debug.Log(SpawnPrefab.instance.index);
                    DoTransition(0);
                }
                else
                {
                    GameOver();
                }
                break;
            case "Track":
                if (ComparePos_Track(_objPos))
                {
                    ChkClicked();
                }
                else
                {
                    DeactiveHandler();
                    _animator.SetTrigger("Clicked");
                    GameOver();
                }
                Debug.Log(SpawnPrefab.instance.index_track);
                break;
            case "Twins":
                DeactiveHandler();
                if (ComparePosTwins(_objPos))
                {
                    SpawnPrefab.instance.index_twins += 2;
                    SpawnPrefab.instance.index++;
                    DoTransition(0);

                }
                else
                {
                    GameOver();
                }
                break;
            case "Alone":
                DeactiveHandler();
                if (ComparePos_Alone(_objPos))
                {
                    SpawnPrefab.instance.index++;
                    SpawnPrefab.instance.index_alone++;
                    DoTransition(0);
                }
                else
                {
                    GameOver();
                }
                break;
            case "Flip Vertical": // vertical flip
                DeactiveHandler();
                if (ComparePos(_objPos))
                {
                    SpawnPrefab.instance.index++;
                    Debug.Log(SpawnPrefab.instance.index);
                    DoTransition(0);
                }
                else
                {
                    GameOver();
                }
                break;
            case "Chaos":
                DeactiveHandler();
                if (ComparePos(_objPos))
                {
                    SpawnPrefab.instance.index++;
                    Debug.Log(SpawnPrefab.instance.index);
                    DoTransition(0);
                }
                else
                {
                    GameOver();
                }
                break;
        }
    }


    private bool ComparePos_Alone(Vector3 _objPosAlone)
    {
        if (_objPosAlone == SpawnPrefab.instance.posList[SpawnPrefab.instance.index_alone])
        {
            return true;
        }
        else
        {
            return false;
        }
    }


    private bool ComparePos_Track(Vector3 _objPosTrack)
    {
        if (_objPosTrack == SpawnPrefab.instance.posList[SpawnPrefab.instance.index_track])
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    private bool ComparePos_Normal(Vector3 _objPosNormal)
    {
        if (_objPosNormal == SpawnPrefab.instance.posList[SpawnPrefab.instance.index])
        {
            return true;
        }
        else
        {
            return false;
        }

    }

    private bool ComparePos(Vector3 _objPosFlip)
    {
        if (moveIndex.reverse)
        {
            if (_objPosFlip == SpawnPrefab.instance.posList[SpawnPrefab.instance.index])
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
            if (_objPosFlip == moveIndex.OppCenterPos[SpawnPrefab.instance.index])
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }

    private bool ComparePosTwins(Vector3 _objPosTwins)
    {
        if (SpawnPrefab.instance.colored)
        {
            if (_objPosTwins == SpawnPrefab.instance.posList[SpawnPrefab.instance.index_twins])
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
            if (_objPosTwins == SpawnPrefab.instance.posList[SpawnPrefab.instance.index_twins + 1])
            {
                SpawnPrefab.instance.colored = true;
                return true;
            }
            else
            {
                return false;
            }
        }
    }



    public void EventHandler()
    {
        if(goIdle != null)
        {
            goIdle();
        }
    }

    public void ActiveHandler()
    {
        if(activeCollider != null)
        {
            activeCollider();
        }
    }

    public void DeactiveHandler()
    {
        deactiveCollider();
    }

    public void RendererHandler()
    {
        if(SpawnPrefab.instance.index == 0)
        {
            enableRenderer();
        }        
    }
    
    public void GameOver()
    {
        switch (SpawnPrefab.instance.scene)
        {
            case "MainMenu":
                break;
            case "Track":
                animator = SpawnPrefab.instance.obj[SpawnPrefab.instance.index_track].GetComponent<Animator>();
                break;
            case "Twins":
                if (SpawnPrefab.instance.colored)
                {
                    animator = SpawnPrefab.instance.obj[SpawnPrefab.instance.index_twins].GetComponent<Animator>();
                }
                else
                {
                    animator = SpawnPrefab.instance.obj[SpawnPrefab.instance.index_twins+1].GetComponent<Animator>();
                }                
                break;
            case "Alone":
                animator = SpawnPrefab.instance.obj[SpawnPrefab.instance.index_alone].GetComponent<Animator>();
                break;            
            default: // normal, double, triple, vertical/horizontal flip, temptation
                animator = SpawnPrefab.instance.obj[SpawnPrefab.instance.index].GetComponent<Animator>();
                break;
        }        
        animator.SetTrigger("gameOver");
        chkGameOver = true;        
    }

    public void ChkClicked()
    {
        animator = SpawnPrefab.instance.obj[SpawnPrefab.instance.index_track].GetComponent<Animator>();
        animator.SetTrigger("Clicked");
        SpawnPrefab.instance.index_track++;
        if(SpawnPrefab.instance.index_track == SpawnPrefab.instance.index + 1)
        {
            DeactiveHandler();
        }
        Debug.Log("OK");
    }

    public void DoTransition(int type)
    {
        switch (type)
        {
            case 0: // SpawnPrefab.instance Transition
                display.CountLevel();
                LevelTransition.SetActive(true);
                break;
            case 1:
                //display.GameResult();
                //meOver.SetActive(true);
                SceneManager.LoadScene("GameOver", LoadSceneMode.Additive);
                break;
        }        
    }

    void Update()
    {
        if (chkGameOver)
        {   
            currentBaseState = animator.GetCurrentAnimatorStateInfo(0);
            if (currentBaseState.IsName("soomong20_twinkle"))
            {
                //Debug.Log(currentBaseState.normalizedTime);
                if (currentBaseState.normalizedTime > 1.0f)
                {
                    chkGameOver = false;
                    DoTransition(1);
                    //animator.SetTrigger("Clicked");
                }
            }            
        }

        if (SpawnPrefab.instance.scene == "Track" && SpawnPrefab.instance.index_track == SpawnPrefab.instance.index + 1)
        {            
            currentBaseState = animator.GetCurrentAnimatorStateInfo(0);
            if (currentBaseState.IsName("soomong20_clicked"))
            {
                if (currentBaseState.normalizedTime > 1.0f)
                {
                    SpawnPrefab.instance.index++;
                    DoTransition(0);
                    SpawnPrefab.instance.index_track = 0;
                }
            }            
        }
    }
    
}
