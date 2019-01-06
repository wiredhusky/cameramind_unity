using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class RootGameManager : MonoBehaviour {

    public static RootGameManager rootGameManager;

    //SpriteRenderer trackSprite;
    Image trackImg;
    //public Animator animator;
    

    private void Awake()
    {
        if(rootGameManager == null){
            rootGameManager = this;
        }
        Application.targetFrameRate = 60;        
    }

    public void GameOver(GameObject _obj){        
        _obj.transform.DOPunchScale(new Vector3(2f, 2f), 0.6f, 4, 1.0f).SetDelay(0.1f).SetLoops(3).OnComplete(() => DoTransition(1));
    }

    public void ComPos(Vector3 _objPos, Animator _animator)
    {
        RootUIManager.rootUIManager.particle.SetActive(false);
        switch (RootUIManager.rootUIManager.sceneName)
        {
            default:
                InGameManager.inGameManager.DeactiveHandler();
                RootUIManager.rootUIManager.DeactiveUI();
                if (_objPos == InGameManager.inGameManager.posList[InGameManager.inGameManager.index])
                {
                    InGameManager.inGameManager.index++;
                    if (InGameManager.inGameManager.index >= InGameManager.inGameManager.posList.Count)
                    //if (InGameManager.inGameManager.index >= 5)
                    {
                        DoTransition(2);
                    }
                    else
                    {
                        DoTransition(0);
                    }
                }
                else
                {
                    GameOver(InGameManager.inGameManager.obj[InGameManager.inGameManager.index]);
                    //InGameManager.inGameManager.animatorList[InGameManager.inGameManager.index].SetTrigger("gameOver");
                    //chkGameOver = true;
                }
                break;
            case "Flip Horizon":
                InGameManager.inGameManager.DeactiveHandler();
                RootUIManager.rootUIManager.DeactiveUI();
                if (ComparePos(_objPos))
                {
                    InGameManager.inGameManager.index++;
                    if (InGameManager.inGameManager.index >= InGameManager.inGameManager.posList.Count)
                    {
                        DoTransition(2);
                    }
                    else
                    {
                        DoTransition(0);
                    }
                }
                else
                {
                    GameOver(InGameManager.inGameManager.obj[InGameManager.inGameManager.index]);                    
                }
                break;
            case "Track":
                if (_objPos == InGameManager.inGameManager.posList[InGameManager.inGameManager.index_track])
                {                    
                    //trackSprite = InGameManager.inGameManager.obj[InGameManager.inGameManager.index_track].GetComponent<SpriteRenderer>();
                    //trackSprite.DOColor(new Color(0.90f, 0.73f, 0.73f, 1.0f), 0.2f).OnComplete(ChkClicked);
                    trackImg = InGameManager.inGameManager.obj[InGameManager.inGameManager.index_track].GetComponent<Image>();
                    trackImg.DOColor(new Color(0.90f, 0.73f, 0.73f, 1.0f), 0.2f).OnComplete(ChkClicked);
                    //trackSprite.DOColor(Color.magenta, 0.5f).OnComplete(ChkClicked);
                }
                else
                {
                    InGameManager.inGameManager.DeactiveHandler();
                    RootUIManager.rootUIManager.DeactiveUI();                    
                    GameOver(InGameManager.inGameManager.obj[InGameManager.inGameManager.index_track]);
                }
                break;
            case "Twins":
                InGameManager.inGameManager.DeactiveHandler();
                RootUIManager.rootUIManager.DeactiveUI();
                if (ComparePosTwins(_objPos))
                {
                    InGameManager.inGameManager.index_twins += 2;
                    InGameManager.inGameManager.index++;
                    if (InGameManager.inGameManager.index_twins >= InGameManager.inGameManager.posList.Count)
                    {
                        DoTransition(2);
                    }
                    else
                    {
                        DoTransition(0);
                    }
                }
                else
                {
                    if (InGameManager.inGameManager.turnChk)
                    {
                        GameOver(InGameManager.inGameManager.obj[InGameManager.inGameManager.index_twins]);                        
                    }
                    else
                    {
                        GameOver(InGameManager.inGameManager.obj[InGameManager.inGameManager.index_twins+1]);
                    }
                }
                break;
            case "Alone":
                InGameManager.inGameManager.DeactiveHandler();
                RootUIManager.rootUIManager.DeactiveUI();
                if (_objPos == InGameManager.inGameManager.posList[InGameManager.inGameManager.index_alone])
                {
                    InGameManager.inGameManager.index++;
                    InGameManager.inGameManager.index_alone++;
                    if (InGameManager.inGameManager.index_alone >= InGameManager.inGameManager.posList.Count)
                    {
                        DoTransition(2);
                    }
                    else
                    {
                        DoTransition(0);
                    }
                }
                else
                {
                    GameOver(InGameManager.inGameManager.obj[InGameManager.inGameManager.index_alone]);
                }
                break;
            case "Flip Vertical": // vertical flip
                InGameManager.inGameManager.DeactiveHandler();
                RootUIManager.rootUIManager.DeactiveUI();
                if (ComparePos(_objPos))
                {
                    InGameManager.inGameManager.index++;
                    Debug.Log(InGameManager.inGameManager.index);
                    if (InGameManager.inGameManager.index >= InGameManager.inGameManager.posList.Count)
                    {
                        DoTransition(2);
                    }
                    else
                    {
                        DoTransition(0);
                    }
                }
                else
                {
                    GameOver(InGameManager.inGameManager.obj[InGameManager.inGameManager.index]);
                }
                break;
            case "Time Attack":
                Timer.timerControl.setTimer = false;
                Timer.timerControl.animator.speed = 0;
                InGameManager.inGameManager.DeactiveHandler();
                RootUIManager.rootUIManager.DeactiveUI();
                if (_objPos == InGameManager.inGameManager.posList[InGameManager.inGameManager.index])
                {
                    InGameManager.inGameManager.index++;
                    if (InGameManager.inGameManager.index >= InGameManager.inGameManager.posList.Count)
                    {
                        DoTransition(2);
                    }
                    else
                    {
                        DoTransition(0);
                    }
                }
                else
                {
                    GameOver(InGameManager.inGameManager.obj[InGameManager.inGameManager.index]);
                }
                break;
            case "Chaos":
                InGameManager.inGameManager.DeactiveHandler();
                RootUIManager.rootUIManager.DeactiveUI();
                if (ComparePos(_objPos))
                {
                    InGameManager.inGameManager.index++;
                    if (InGameManager.inGameManager.index >= InGameManager.inGameManager.posList.Count)
                    {
                        DoTransition(2);
                    }
                    else
                    {
                        DoTransition(0);
                    }
                }
                else
                {
                    GameOver(InGameManager.inGameManager.obj[InGameManager.inGameManager.index]);
                }
                break;
            case "DanceDance":
                InGameManager.inGameManager.DeactiveHandler();
                RootUIManager.rootUIManager.DeactiveUI();
                if (_objPos == InGameManager.inGameManager.posList[InGameManager.inGameManager.index_dance_answer])
                {
                    InGameManager.inGameManager.index++;
                    switch (InGameManager.inGameManager.index)
                    {
                        //this have to be fixed into NEW TRANSITION SYSTEM
                        case 5:
                            InGameManager.inGameManager.index_dance = 8;
                            RootUIManager.rootUIManager.DoDanceTransition();
                            break;
                        case 10:
                            InGameManager.inGameManager.index_dance = 12;
                            RootUIManager.rootUIManager.DoDanceTransition();
                            break;
                        case 15:
                            InGameManager.inGameManager.index_dance = 20;
                            RootUIManager.rootUIManager.DoDanceTransition();
                            break;
                        default:
                            if (InGameManager.inGameManager.index >= 31)
                            {
                                DoTransition(2);
                            }
                            else
                            {
                                DoTransition(0);
                            }
                            break;
                    }
                }else
                {
                    GameOver(InGameManager.inGameManager.obj[InGameManager.inGameManager.index_dance_answer]);
                }
                break;
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

    public void ChkClicked()
    {
        //InGameManager.inGameManager.animatorList[InGameManager.inGameManager.index_track].SetTrigger("Clicked");
        InGameManager.inGameManager.index_track++;
        if (InGameManager.inGameManager.index_track == InGameManager.inGameManager.index + 1)
        {
            //InGameManager.inGameManager.trackComplete = true;
            InGameManager.inGameManager.DeactiveHandler();
            RootUIManager.rootUIManager.DeactiveUI();
            InGameManager.inGameManager.index++;

            if (InGameManager.inGameManager.index == InGameManager.inGameManager.posList.Count)
            {
                DoTransition(2);
            }
            else
            {
                InGameManager.inGameManager.index_track = 0;
                DoTransition(0);
            }
        }
    }

    public void DoTransition(int type)
    {
        switch (type)
        {
            case 0: // InGameManager.inGameManager Transition
                //InGameManager.inGameManager.CountLevel();
                //new stage is unlocked
                //InGameManager.inGameManager.chkUnlockStage();
                RootUIManager.rootUIManager.DoLevelTransition();
                //InGameManager.inGameManager.LevelTransitionPanel.SetActive(true);
                break;
            case 1:
                //SceneManager.LoadScene("GameOver", LoadSceneMode.Additive);
                RootUIManager.rootUIManager.ActivePauseGameOver(1, InGameManager.inGameManager.index);
                break;
            case 2:
                RootUIManager.rootUIManager.ActivePauseGameOver(2, InGameManager.inGameManager.index);
                break;
        }
    }

}
