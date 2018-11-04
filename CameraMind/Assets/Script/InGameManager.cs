using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InGameManager : MonoBehaviour {

    public static InGameManager inGameManager;

    public List<Vector3> posList = new List<Vector3>();
    public List<Vector3> oppCenterPos = new List<Vector3>();
    public List<int> objType = new List<int>();
    public List<GameObject> obj = new List<GameObject>();
    public List<Animator> animatorList = new List<Animator>();
    //public List<Renderer> rendererList = new List<Renderer>();
    public GameObject LevelTransitionPanel;
    public GameObject DanceTime;

    public delegate void GoToIdle();
    public event GoToIdle goIdle;
    public event GoToIdle activeCollider;
    public event GoToIdle deactiveCollider;
    public event GoToIdle enableRenderer;
    public event GoToIdle goMove;
    public event GoToIdle goRandomAni;

    public TextMeshProUGUI currentLevelText;    

    public string sceneName;
    public int index = 0;
    public int index_track = 0;
    public int index_twins = 0;
    public int index_alone = 50;
    public int index_dance = 4;
    public int index_dance_answer = 0;

    public bool turnChk = true;
    public bool trackComplete = false;

    public GameObject soomong_colored;

    AnimatorStateInfo currentBaseState;

    //int case0, case1, case2, case3, case4;

    private void Awake()
    {
        if(inGameManager == null){
            inGameManager = this;
        }
        sceneName = RootUIManager.rootUIManager.sceneName;
    }

    private void Start()
    {
        CountLevel();
        switch (sceneName)
        {
            case "DanceDance":
                DanceTime.SetActive(true);
                break;
            default:
                LevelTransitionPanel.SetActive(true);
                break;
        }
        index_dance = 4;        
    }

    public void CountLevel()
    {
        currentLevelText.text = "Level " + (index + 1).ToString();
    }    

    public void EventHandler()
    {
        if (goIdle != null)
        {
            goIdle();
        }
    }

    public void ActiveHandler()
    {
        if (activeCollider != null)
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
        if (index == 0)
        {
            enableRenderer();
        }
    }

    public void CatDance(){
        if (goMove != null){
            goMove();
        }
    }

    public void SetRandomAni(){
        if (goRandomAni != null){
            goRandomAni();
        }
        //LevelTransitionPanel.SetActive(true);
    }

    void Update()
    {
        if (RootGameManager.rootGameManager.chkGameOver)
        {
            switch (sceneName)
            {
                case "Track":
                    currentBaseState = animatorList[index_track].GetCurrentAnimatorStateInfo(0);
                    break;
                case "DanceDance":
                    currentBaseState = animatorList[index_dance_answer].GetCurrentAnimatorStateInfo(0);
                    break;
                default:
                    currentBaseState = animatorList[index].GetCurrentAnimatorStateInfo(0);
                    break;
            }            
            
            if (currentBaseState.IsName("GameOver") || currentBaseState.IsName("GameOver0") || currentBaseState.IsName("GameOver1") || currentBaseState.IsName("GameOver2"))
            {                
                if (currentBaseState.normalizedTime > 1.0f)
                {                    
                    RootGameManager.rootGameManager.chkGameOver = false;
                    RootGameManager.rootGameManager.DoTransition(1);
                    //idle로 돌려주지 않으면 Revive하고 다시 틀렸을 때 걔를 GameOver 애니메이션을 할 수가 없음
                    switch (sceneName)
                    {
                        case "Track":
                            animatorList[index_track].SetTrigger("Origin");
                            break;
                        case "DanceDance":
                            animatorList[index_dance_answer].SetTrigger("GoBack");
                            break;
                        default:
                            animatorList[index].SetTrigger("Origin");
                            break;
                    }
                }
            }
        }

        if (trackComplete)
        {
            RootUIManager.rootUIManager.DeactiveUI();
            currentBaseState = animatorList[index].GetCurrentAnimatorStateInfo(0);
            if (currentBaseState.IsName("clicked"))
            {
                if (currentBaseState.normalizedTime > 1.0f)
                {       
                    index++;
                    index_track = 0;
                    trackComplete = false;
                    RootGameManager.rootGameManager.DoTransition(0);                    
                }
            }
        }
    }
}
