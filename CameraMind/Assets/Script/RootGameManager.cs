using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RootGameManager : MonoBehaviour {

    public static RootGameManager rootGameManager;

    public bool chkGameOver = false;
    public Animator animator;

    private void Awake()
    {
        if(rootGameManager == null){
            rootGameManager = this;
        }
    }

    public void ComPos(Vector3 _objPos, Animator _animator)
    {
        RootUIManager.rootUIManager.particle.SetActive(false);
        switch (RootUIManager.rootUIManager.sceneName)
        {
            default:
                GameManager.gameManager.DeactiveHandler();
                RootUIManager.rootUIManager.DeactiveUI();
                if (ComparePos_Normal(_objPos))
                {
                    GameManager.gameManager.index++;
                    DoTransition(0);
                }
                else
                {
                    GameOver();
                }
                break;
            case "Flip Horizon":
                GameManager.gameManager.DeactiveHandler();
                RootUIManager.rootUIManager.DeactiveUI();
                if (ComparePos(_objPos))
                {
                    GameManager.gameManager.index++;
                    Debug.Log(GameManager.gameManager.index);
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
                    GameManager.gameManager.DeactiveHandler();
                    RootUIManager.rootUIManager.DeactiveUI();
                    _animator.SetTrigger("Clicked");
                    GameOver();
                }
                break;
            case "Twins":
                GameManager.gameManager.DeactiveHandler();
                RootUIManager.rootUIManager.DeactiveUI();
                if (ComparePosTwins(_objPos))
                {
                    GameManager.gameManager.index_twins += 2;
                    GameManager.gameManager.index++;
                    DoTransition(0);
                }
                else
                {
                    GameOver();
                }
                break;
            case "Alone":
                GameManager.gameManager.DeactiveHandler();
                RootUIManager.rootUIManager.DeactiveUI();
                if (ComparePos_Alone(_objPos))
                {
                    GameManager.gameManager.index++;
                    GameManager.gameManager.index_alone++;
                    DoTransition(0);
                }
                else
                {
                    GameOver();
                }
                break;
            case "Flip Vertical": // vertical flip
                GameManager.gameManager.DeactiveHandler();
                RootUIManager.rootUIManager.DeactiveUI();
                if (ComparePos(_objPos))
                {
                    GameManager.gameManager.index++;
                    Debug.Log(GameManager.gameManager.index);
                    DoTransition(0);
                }
                else
                {
                    GameOver();
                }
                break;
            case "Time Attack":
                Timer.timerControl.setTimer = false;
                Timer.timerControl.animator.speed = 0;
                GameManager.gameManager.DeactiveHandler();
                RootUIManager.rootUIManager.DeactiveUI();
                if (ComparePos_Normal(_objPos))
                {
                    GameManager.gameManager.index++;
                    DoTransition(0);
                }
                else
                {
                    GameOver();
                }
                break;
            case "Chaos":
                GameManager.gameManager.DeactiveHandler();
                RootUIManager.rootUIManager.DeactiveUI();
                if (ComparePos(_objPos))
                {
                    GameManager.gameManager.index++;
                    Debug.Log(GameManager.gameManager.index);
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
        if (_objPosAlone == GameManager.gameManager.posList[GameManager.gameManager.index_alone])
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
        if (_objPosTrack == GameManager.gameManager.posList[GameManager.gameManager.index_track])
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
        if (_objPosNormal == GameManager.gameManager.posList[GameManager.gameManager.index])
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
        if (GameManager.gameManager.turnChk)
        {
            if (_objPosFlip == GameManager.gameManager.posList[GameManager.gameManager.index])
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
            if (_objPosFlip == GameManager.gameManager.oppCenterPos[GameManager.gameManager.index])
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
        if (GameManager.gameManager.turnChk)
        {
            if (_objPosTwins == GameManager.gameManager.posList[GameManager.gameManager.index_twins])
            {
                GameManager.gameManager.turnChk = false;
                return true;
            }
            else
            {
                return false;
            }
        }
        else
        {
            if (_objPosTwins == GameManager.gameManager.posList[GameManager.gameManager.index_twins + 1])
            {
                GameManager.gameManager.turnChk = true;
                return true;
            }
            else
            {
                return false;
            }
        }
    }

    public void GameOver()
    {
        RootUIManager.rootUIManager.particle.SetActive(false);
        switch (RootUIManager.rootUIManager.sceneName)
        {
            case "SceneManager":
                break;
            case "Track":
                animator = GameManager.gameManager.obj[GameManager.gameManager.index_track].GetComponent<Animator>();
                break;
            case "Twins":
                if (GameManager.gameManager.turnChk)
                {
                    animator = GameManager.gameManager.obj[GameManager.gameManager.index_twins].GetComponent<Animator>();
                }
                else
                {
                    animator = GameManager.gameManager.obj[GameManager.gameManager.index_twins + 1].GetComponent<Animator>();
                }
                break;
            case "Alone":
                animator = GameManager.gameManager.obj[GameManager.gameManager.index_alone].GetComponent<Animator>();
                break;
            case "Time Attack":
                animator = GameManager.gameManager.obj[GameManager.gameManager.index].GetComponent<Animator>();
                break;
            default: // normal, double, triple, vertical/horizontal flip, temptation
                animator = GameManager.gameManager.obj[GameManager.gameManager.index].GetComponent<Animator>();
                break;
        }
        animator.SetTrigger("gameOver");
        chkGameOver = true;
    }

    public void ChkClicked()
    {
        animator = GameManager.gameManager.obj[GameManager.gameManager.index_track].GetComponent<Animator>();
        animator.SetTrigger("Clicked");
        GameManager.gameManager.index_track++;
        if (GameManager.gameManager.index_track == GameManager.gameManager.index + 1)
        {
            GameManager.gameManager.trackComplete = true;
            GameManager.gameManager.DeactiveHandler();
        }
    }

    public void DoTransition(int type)
    {
        switch (type)
        {
            case 0: // GameManager.gameManager Transition
                GameManager.gameManager.CountLevel();
                GameManager.gameManager.LevelTransitionPanel.SetActive(true);
                break;
            case 1:
                //SceneManager.LoadScene("GameOver", LoadSceneMode.Additive);
                RootUIManager.rootUIManager.ActivePauseGameOver(1, GameManager.gameManager.index);
                break;
        }
    }

}
