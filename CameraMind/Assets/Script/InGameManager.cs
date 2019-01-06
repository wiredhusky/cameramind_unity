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
    public GameObject inGameBackground;
    //public List<Renderer> rendererList = new List<Renderer>();
    //public GameObject LevelTransitionPanel;
    //public GameObject DanceTime;
    //public GameObject unlockedObj;

    public delegate void GoToIdle();
    public event GoToIdle goIdle;
    public event GoToIdle activeCollider;
    public event GoToIdle deactiveCollider;
    public event GoToIdle enableRenderer;
    public event GoToIdle goMove;
    public event GoToIdle goRandomAni;
    public event GoToIdle backToOriginColor;

    //public TextMeshProUGUI currentLevelText;    

    public string sceneName;
    public int index = 0;
    public int index_track = 0;
    public int index_twins = 0;
    public int index_alone = 50;
    public int index_dance = 4;
    public int index_dance_answer = 0;

    public bool turnChk = true;

    //unlock Level
    int unlockLevel;
    public bool unlockEvent = false;
    int chkUnlock;

    //int case0, case1, case2, case3, case4;
    

    private void Awake()
    {
        if(inGameManager == null){
            inGameManager = this;
        }
        sceneName = RootUIManager.rootUIManager.sceneName;
        index_dance = 4;
    }

    private void Start()
    {
        //CountLevel();        
        switch (sceneName)
        {
            case "Normal":
                chkUnlock = PlayerPrefs.GetInt("unlockHorizontal");
                Debug.Log("unlock: " + chkUnlock);
                unlockLevel = 5;
                break;            
            case "Flip Vertical":
                chkUnlock = PlayerPrefs.GetInt("unlockTime");                
                unlockLevel = 5;
                break;
            case "Chaos":
                chkUnlock = PlayerPrefs.GetInt("unlockDance");                
                unlockLevel = 5;
                break;
            case "DanceDance":
                chkUnlock = PlayerPrefs.GetInt("unlockAlone");                
                unlockLevel = 5;
                break;
            case "Twins":
                chkUnlock = PlayerPrefs.GetInt("unlockVertical");                
                unlockLevel = 5;
                break;
            case "Temptation":
                chkUnlock = PlayerPrefs.GetInt("unlockTrack");                
                unlockLevel = 5;
                break;
            case "Track":
                chkUnlock = PlayerPrefs.GetInt("unlockChaos");                
                unlockLevel = 5;
                break;            
            case "Time Attack":
                chkUnlock = PlayerPrefs.GetInt("unlockTemptation");                
                unlockLevel = 5;
                break;
            case "Alone":
                chkUnlock = PlayerPrefs.GetInt("unlockTriple");                
                unlockLevel = 5;
                break;
            case "Triple": // last stage
                chkUnlock = 1;
                unlockLevel = 5;
                break;
            case "Double":
                chkUnlock = PlayerPrefs.GetInt("unlockTwins");                
                unlockLevel = 5;
                break;
            case "Flip Horizon":
                chkUnlock = PlayerPrefs.GetInt("unlockDouble");                
                unlockLevel = 5;
                //LevelTransitionPanel.SetActive(true);
                break;
        }
        RootUIManager.rootUIManager.InitScene();
    }    

    public void chkUnlockStage()
    {
        if(chkUnlock == 0)
        {
            if (index == unlockLevel)
            {
                switch (sceneName)
                {
                    case "Normal":
                        chkUnlock = 1;
                        //unlockedObj.SetActive(true);
                        PlayerPrefs.SetInt("unlockHorizontal", 1);
                        PlayerPrefs.Save();
                        RootUIManager.rootUIManager.objHorizon.SetActive(true);
                        RootUIManager.rootUIManager.unlockHorizon.SetActive(false);
                        break;
                    case "Flip Vertical":
                        chkUnlock = 1;
                        //unlockedObj.SetActive(true);
                        PlayerPrefs.SetInt("unlockTime", 1);
                        PlayerPrefs.Save();
                        RootUIManager.rootUIManager.objTime.SetActive(true);
                        RootUIManager.rootUIManager.unlockTime.SetActive(false);
                        break;
                    case "Chaos":
                        chkUnlock = 1;
                        //unlockedObj.SetActive(true);
                        PlayerPrefs.SetInt("unlockDance", 1);
                        PlayerPrefs.Save();
                        RootUIManager.rootUIManager.objDance.SetActive(true);
                        RootUIManager.rootUIManager.unlockDance.SetActive(false);
                        break;
                        /*
                    case "DanceDance":
                        chkUnlock = 1;
                        //unlockedObj.SetActive(true);
                        PlayerPrefs.SetInt("unlockAlone", 1);
                        PlayerPrefs.Save();
                        RootUIManager.rootUIManager.objAlone.SetActive(true);
                        RootUIManager.rootUIManager.unlockAlone.SetActive(false);
                        break;
                        */
                    case "Twins":
                        chkUnlock = 1;
                        //unlockedObj.SetActive(true);
                        PlayerPrefs.SetInt("unlockVertical", 1);
                        PlayerPrefs.Save();
                        RootUIManager.rootUIManager.objVertical.SetActive(true);
                        RootUIManager.rootUIManager.unlockVertical.SetActive(false);
                        break;
                    case "Temptation":
                        chkUnlock = 1;
                        //unlockedObj.SetActive(true);
                        PlayerPrefs.SetInt("unlockTrack", 1);
                        PlayerPrefs.Save();
                        RootUIManager.rootUIManager.objTrack.SetActive(true);
                        RootUIManager.rootUIManager.unlockTrack.SetActive(false);
                        break;
                    case "Track":
                        chkUnlock = 1;
                        //unlockedObj.SetActive(true);
                        PlayerPrefs.SetInt("unlockChaos", 1);
                        PlayerPrefs.Save();
                        RootUIManager.rootUIManager.objChaos.SetActive(true);
                        RootUIManager.rootUIManager.unlockChaos.SetActive(false);
                        break;
                    case "Time Attack":
                        chkUnlock = 1;
                        //unlockedObj.SetActive(true);
                        PlayerPrefs.SetInt("unlockTemptation", 1);
                        PlayerPrefs.Save();
                        RootUIManager.rootUIManager.objTemptation.SetActive(true);
                        RootUIManager.rootUIManager.unlockTemptation.SetActive(false);
                        break;
                    case "Alone":
                        chkUnlock = 1;
                        //unlockedObj.SetActive(true);
                        PlayerPrefs.SetInt("unlockTriple", 1);
                        PlayerPrefs.Save();
                        RootUIManager.rootUIManager.objTriple.SetActive(true);
                        RootUIManager.rootUIManager.unlockTriple.SetActive(false);
                        break;
                    case "Triple":                        
                        break;
                    case "Double":
                        chkUnlock = 1;
                        //unlockedObj.SetActive(true);
                        PlayerPrefs.SetInt("unlockTwins", 1);
                        PlayerPrefs.Save();
                        RootUIManager.rootUIManager.objTwins.SetActive(true);
                        RootUIManager.rootUIManager.unlockTwins.SetActive(false);
                        break;
                    case "Flip Horizon":
                        chkUnlock = 1;
                        //unlockedObj.SetActive(true);
                        PlayerPrefs.SetInt("unlockDouble", 1);
                        PlayerPrefs.Save();
                        RootUIManager.rootUIManager.objDouble.SetActive(true);
                        RootUIManager.rootUIManager.unlockDouble.SetActive(false);
                        break;
                }
                RootUIManager.rootUIManager.inGameUnlockObj.SetActive(true);
                RootUIManager.rootUIManager.ImageChanger(3); // unlock image를 바꿈
                unlockEvent = true;
            }
        }        
    }

    public void EventHandler()
    {
        if (goIdle != null)
        {
            goIdle();
        }
    }

    public void SpriteColorBackToOrigin()
    {
        if(backToOriginColor != null)
        {
            backToOriginColor();
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
}
