using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RootGameManager : MonoBehaviour {

    public static RootGameManager rootGameManager;

    public bool chkGameOver = false;
    //public Animator animator;

    private void Awake()
    {
        if(rootGameManager == null){
            rootGameManager = this;
        }
        Application.targetFrameRate = 60;
    }

    public void ComPos(Vector3 _objPos, Animator _animator)
    {
        RootUIManager.rootUIManager.particle.SetActive(false);
        switch (RootUIManager.rootUIManager.sceneName)
        {
            default:
                InGameManager.inGameManager.DeactiveHandler();
                RootUIManager.rootUIManager.DeactiveUI();
                if (ComparePos_Normal(_objPos))
                {
                    InGameManager.inGameManager.index++;
                    DoTransition(0);
                }
                else
                {
                    GameOver();
                }
                break;
            case "Flip Horizon":
                InGameManager.inGameManager.DeactiveHandler();
                RootUIManager.rootUIManager.DeactiveUI();
                if (ComparePos(_objPos))
                {
                    InGameManager.inGameManager.index++;
                    Debug.Log(InGameManager.inGameManager.index);
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
                    InGameManager.inGameManager.DeactiveHandler();
                    RootUIManager.rootUIManager.DeactiveUI();
                    _animator.SetTrigger("Clicked");
                    GameOver();
                }
                break;
            case "Twins":
                InGameManager.inGameManager.DeactiveHandler();
                RootUIManager.rootUIManager.DeactiveUI();
                if (ComparePosTwins(_objPos))
                {
                    InGameManager.inGameManager.index_twins += 2;
                    InGameManager.inGameManager.index++;
                    DoTransition(0);
                }
                else
                {
                    GameOver();
                }
                break;
            case "Alone":
                InGameManager.inGameManager.DeactiveHandler();
                RootUIManager.rootUIManager.DeactiveUI();
                if (ComparePos_Alone(_objPos))
                {
                    InGameManager.inGameManager.index++;
                    InGameManager.inGameManager.index_alone++;
                    DoTransition(0);
                }
                else
                {
                    GameOver();
                }
                break;
            case "Flip Vertical": // vertical flip
                InGameManager.inGameManager.DeactiveHandler();
                RootUIManager.rootUIManager.DeactiveUI();
                if (ComparePos(_objPos))
                {
                    InGameManager.inGameManager.index++;
                    Debug.Log(InGameManager.inGameManager.index);
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
                InGameManager.inGameManager.DeactiveHandler();
                RootUIManager.rootUIManager.DeactiveUI();
                if (ComparePos_Normal(_objPos))
                {
                    InGameManager.inGameManager.index++;
                    DoTransition(0);
                }
                else
                {
                    GameOver();
                }
                break;
            case "Chaos":
                InGameManager.inGameManager.DeactiveHandler();
                RootUIManager.rootUIManager.DeactiveUI();
                if (ComparePos(_objPos))
                {
                    InGameManager.inGameManager.index++;
                    Debug.Log(InGameManager.inGameManager.index);
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
        if (_objPosAlone == InGameManager.inGameManager.posList[InGameManager.inGameManager.index_alone])
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
        if (_objPosTrack == InGameManager.inGameManager.posList[InGameManager.inGameManager.index_track])
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
        if (_objPosNormal == InGameManager.inGameManager.posList[InGameManager.inGameManager.index])
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
        if (InGameManager.inGameManager.turnChk)
        {
            if (_objPosFlip == InGameManager.inGameManager.posList[InGameManager.inGameManager.index])
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
            if (_objPosFlip == InGameManager.inGameManager.oppCenterPos[InGameManager.inGameManager.index])
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
        if (InGameManager.inGameManager.turnChk)
        {
            if (_objPosTwins == InGameManager.inGameManager.posList[InGameManager.inGameManager.index_twins])
            {
                InGameManager.inGameManager.turnChk = false;
                return true;
            }
            else
            {
                return false;
            }
        }
        else
        {
            if (_objPosTwins == InGameManager.inGameManager.posList[InGameManager.inGameManager.index_twins + 1])
            {
                InGameManager.inGameManager.turnChk = true;
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
                InGameManager.inGameManager.animatorList[InGameManager.inGameManager.index_track].SetTrigger("gameOver");
                break;
            case "Twins":
                if (InGameManager.inGameManager.turnChk)
                {   
                    InGameManager.inGameManager.animatorList[InGameManager.inGameManager.index_twins].SetTrigger("gameOver");
                }
                else
                {
                    InGameManager.inGameManager.animatorList[InGameManager.inGameManager.index_twins+1].SetTrigger("gameOver");
                }
                break;
            case "Alone":
                InGameManager.inGameManager.animatorList[InGameManager.inGameManager.index_alone].SetTrigger("gameOver");
                break;
            default: // normal, double, triple, vertical/horizontal flip, temptation
                InGameManager.inGameManager.animatorList[InGameManager.inGameManager.index].SetTrigger("gameOver");
                break;
        }
        chkGameOver = true;
    }

    public void ChkClicked()
    {
        InGameManager.inGameManager.animatorList[InGameManager.inGameManager.index_track].SetTrigger("Clicked");
        InGameManager.inGameManager.index_track++;
        if (InGameManager.inGameManager.index_track == InGameManager.inGameManager.index + 1)
        {
            InGameManager.inGameManager.trackComplete = true;
            InGameManager.inGameManager.DeactiveHandler();
        }
    }

    public void DoTransition(int type)
    {
        switch (type)
        {
            case 0: // InGameManager.inGameManager Transition
                InGameManager.inGameManager.CountLevel();
                InGameManager.inGameManager.LevelTransitionPanel.SetActive(true);
                break;
            case 1:
                //SceneManager.LoadScene("GameOver", LoadSceneMode.Additive);
                RootUIManager.rootUIManager.ActivePauseGameOver(1, InGameManager.inGameManager.index);
                break;
        }
    }

}
