using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
    public int unlockLevel;
    public bool unlockEvent = false;
    public int chkUnlock;

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
        ObjSpawning();
        RootUIManager.rootUIManager.uiNavigation.SetActive(true);

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

        switch (sceneName)
        {
            case "Double":
                StartCoroutine(RootUIManager.rootUIManager.StayTransition(1.0f));
                break;
            case "Chaos":
                StartCoroutine(RootUIManager.rootUIManager.StayTransition(1.0f));
                break;
            case "DanceDance":
                RootSpawnManager.rootSpawnManager.objCreator();
                StartCoroutine(RootUIManager.rootUIManager.StayTransition(0.5f));
                break;
            default:
                StartCoroutine(RootUIManager.rootUIManager.StayTransition(0.5f));
                break;
        }
    }

    void ObjSpawning()
    {
        //clicked = false;
        if (SceneManager.GetActiveScene().name == "SceneManager")
        {
            RootUIManager.rootUIManager.menus.SetActive(false);
            RootUIManager.rootUIManager.topBackground.SetActive(false);
            SceneManager.SetActiveScene(SceneManager.GetSceneByName(sceneName));
        }

        RootSpawnManager.rootSpawnManager.setScale(RootSpawnManager.rootSpawnManager.cats);

        switch (sceneName)
        {
            case "Twins":
                RootSpawnManager.rootSpawnManager.PosSearch(posList, objType);
                RootSpawnManager.rootSpawnManager.InstantiateObjTwins(posList.Count);
                break;
            case "Flip Vertical":
                RootSpawnManager.rootSpawnManager.PosSearch(posList, objType);
                RootSpawnManager.rootSpawnManager.InstantiateObj(RootSpawnManager.rootSpawnManager.flyingCat, posList.Count);
                break;
            case "DanceDance":
                RootSpawnManager.rootSpawnManager.PosSearchDance(posList, objType);
                RootSpawnManager.rootSpawnManager.InstantiateObj(RootSpawnManager.rootSpawnManager.cats, posList.Count);
                break;
            default:
                RootSpawnManager.rootSpawnManager.PosSearch(posList, objType);
                RootSpawnManager.rootSpawnManager.InstantiateObj(RootSpawnManager.rootSpawnManager.cats, posList.Count);
                break;
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
