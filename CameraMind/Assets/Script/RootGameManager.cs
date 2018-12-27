using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class RootGameManager : MonoBehaviour {

    public static RootGameManager rootGameManager;    

    public bool chkGameOver = false;
    //public Animator animator;

    SpriteRenderer objRenderer;
    Material material;

    Sequence gameOverSequence;

    private void Awake()
    {
        if(rootGameManager == null){
            rootGameManager = this;
        }
        Application.targetFrameRate = 60;
        gameOverSequence = DOTween.Sequence();
    }

    private void GameOver(GameObject _obj){
        Debug.Log("GameOver Entered");
        _obj.transform.DOMove(new Vector3(0, 0, 0), 1.0f);
        material = _obj.GetComponent<Material>();
        material.DOFade(0, 1.0f);
        objRenderer.DOColor(Color.red, 1.0f);
        objRenderer = _obj.GetComponent<SpriteRenderer>();
        gameOverSequence.Append(objRenderer.DOFade(0, 0.17f))
                        .Append(objRenderer.DOFade(100, 0.17f))
                        .Append(objRenderer.DOFade(0, 0.17f))
                        .Append(objRenderer.DOFade(100, 0.17f))
                        .AppendCallback(() => DoTransition(1));
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
                    InGameManager.inGameManager.animatorList[InGameManager.inGameManager.index].SetTrigger("gameOver");
                    chkGameOver = true;
                }
                break;
            case "Track":
                if (_objPos == InGameManager.inGameManager.posList[InGameManager.inGameManager.index_track])
                {
                    ChkClicked();
                }
                else
                {
                    InGameManager.inGameManager.DeactiveHandler();
                    RootUIManager.rootUIManager.DeactiveUI();
                    _animator.SetTrigger("Clicked");
                    InGameManager.inGameManager.animatorList[InGameManager.inGameManager.index_track].SetTrigger("gameOver");
                    chkGameOver = true;
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
                        InGameManager.inGameManager.animatorList[InGameManager.inGameManager.index_twins].SetTrigger("gameOver");
                    }
                    else
                    {
                        InGameManager.inGameManager.animatorList[InGameManager.inGameManager.index_twins + 1].SetTrigger("gameOver");
                    }
                    chkGameOver = true;
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
                    InGameManager.inGameManager.animatorList[InGameManager.inGameManager.index_alone].SetTrigger("gameOver");
                    chkGameOver = true;
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
                    InGameManager.inGameManager.animatorList[InGameManager.inGameManager.index].SetTrigger("gameOver");
                    chkGameOver = true;
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
                    InGameManager.inGameManager.animatorList[InGameManager.inGameManager.index].SetTrigger("gameOver");
                    chkGameOver = true;
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
                    InGameManager.inGameManager.animatorList[InGameManager.inGameManager.index].SetTrigger("gameOver");
                    chkGameOver = true;
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
                        case 5:
                            InGameManager.inGameManager.index_dance = 8;
                            InGameManager.inGameManager.DanceTime.SetActive(true);
                            break;
                        case 10:
                            InGameManager.inGameManager.index_dance = 12;
                            InGameManager.inGameManager.DanceTime.SetActive(true);
                            break;
                        case 15:
                            InGameManager.inGameManager.index_dance = 20;
                            InGameManager.inGameManager.DanceTime.SetActive(true);
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
                    InGameManager.inGameManager.animatorList[InGameManager.inGameManager.index_dance_answer].SetTrigger("gameOver");
                    chkGameOver = true;
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

    /*
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
                    InGameManager.inGameManager.animatorList[InGameManager.inGameManager.index_twins + 1].SetTrigger("gameOver");
                }
                break;
            case "Alone":
                InGameManager.inGameManager.animatorList[InGameManager.inGameManager.index_alone].SetTrigger("gameOver");
                break;
            case "DanceDance":
                InGameManager.inGameManager.animatorList[InGameManager.inGameManager.index_dance_answer].SetTrigger("gameOver");
                break;
            default: // normal, double, triple, vertical/horizontal flip, temptation
                InGameManager.inGameManager.animatorList[InGameManager.inGameManager.index].SetTrigger("gameOver");
                break;
        }
        chkGameOver = true;
    }*/

        /*
    void LevelComplete()
    {
        switch (RootUIManager.rootUIManager.sceneName)
        {
            case "SceneManager":
                break;
            case "Track":
                if (InGameManager.inGameManager.index >= InGameManager.inGameManager.posList.Count)
                {
                    DoTransition(2);
                }
                else
                {
                    DoTransition(0);
                }
                break;
            case "Twins":
                if (InGameManager.inGameManager.index_twins >= InGameManager.inGameManager.posList.Count)
                {
                    DoTransition(2);
                }
                else
                {
                    DoTransition(0);
                }
                break;
            case "Alone":
                if (InGameManager.inGameManager.index_alone >= InGameManager.inGameManager.posList.Count)
                {
                    DoTransition(2);
                }
                else
                {
                    DoTransition(0);
                }
                break;
            case "DanceDance":
                if (InGameManager.inGameManager.index >= 31)
                {
                    DoTransition(2);
                }
                else
                {
                    DoTransition(0);
                }
                break;
            default: // normal, double, triple, vertical/horizontal flip, temptation
                if (InGameManager.inGameManager.index >= InGameManager.inGameManager.posList.Count)
                {
                    DoTransition(2);
                }
                else
                {
                    DoTransition(0);
                }
                break;
        }
    }*/

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
                //new stage is unlocked
                //InGameManager.inGameManager.chkUnlockStage();
                InGameManager.inGameManager.LevelTransitionPanel.SetActive(true);
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
