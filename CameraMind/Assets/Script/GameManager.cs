using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour {

    public static GameManager gameManager;

    public List<Vector3> posList = new List<Vector3>();
    public List<Vector3> oppCenterPos = new List<Vector3>();
    public List<int> objType = new List<int>();
    public List<GameObject> obj = new List<GameObject>();
    public GameObject LevelTransitionPanel;
    private GameObject _obj;
    public MoveMove move;

    public delegate void GoToIdle();
    public event GoToIdle goIdle;
    public event GoToIdle activeCollider;
    public event GoToIdle deactiveCollider;
    public event GoToIdle enableRenderer;

    public TextMeshProUGUI currentLevelText;

    float localScale_20 = 0.2f;
    float localScale_25 = 0.25f;
    float localScale_30 = 0.3f;
    float localScale_35 = 0.35f;
    float localScale_40 = 0.4f;

    public string sceneName;
    public int index = 0;
    public int index_track = 0;
    public int index_twins = 0;
    public int index_alone = 50;

    public bool turnChk = true;

    public GameObject soomong_colored;

    int case0, case1, case2, case3, case4;

    private void Awake()
    {
        if(gameManager == null){
            gameManager = this;
        }
    }

    private void Start()
    {
        CountLevel();
        LevelTransitionPanel.SetActive(true);
    }

    public void CountLevel()
    {
        currentLevelText.text = "Level " + (index + 1).ToString();
    }

    public void SetStart()
    {
        switch (RootUIManager.rootUIManager.sceneName)
        {
            case "Alone": // alone have to change posList.count가 아니라 50까지만 해야
                for (int i = 0; i < posList.Count; i++)
                {
                    switch (objType[i])
                    {
                        case 0:
                            _obj = Instantiate(soomong_colored) as GameObject;
                            _obj.GetComponent<Renderer>().enabled = false;
                            _obj.transform.localScale = new Vector3(localScale_20, localScale_20, localScale_20);
                            _obj.transform.position = posList[i];
                            break;
                        case 1:
                            _obj = Instantiate(soomong_colored) as GameObject;
                            _obj.GetComponent<Renderer>().enabled = false;
                            _obj.transform.localScale = new Vector3(localScale_25, localScale_25, localScale_25);
                            _obj.transform.position = posList[i];
                            break;
                        case 2:
                            _obj = Instantiate(soomong_colored) as GameObject;
                            _obj.GetComponent<Renderer>().enabled = false;
                            _obj.transform.localScale = new Vector3(localScale_30, localScale_30, localScale_30);
                            _obj.transform.position = posList[i];
                            break;
                        case 3:
                            _obj = Instantiate(soomong_colored) as GameObject;
                            _obj.GetComponent<Renderer>().enabled = false;
                            _obj.transform.localScale = new Vector3(localScale_35, localScale_35, localScale_35);
                            _obj.transform.position = posList[i];
                            break;
                        case 4:
                            _obj = Instantiate(soomong_colored) as GameObject;
                            _obj.GetComponent<Renderer>().enabled = false;
                            _obj.transform.localScale = new Vector3(localScale_40, localScale_40, localScale_40);
                            _obj.transform.position = posList[i];
                            break;
                    }

                }
                break;
            default:
                break;
        }
        Debug.Log("obj count: " + objType.Count);
        case0 = 0;
        case1 = 0;
        case2 = 0;
        case3 = 0;
        case4 = 0;
        for (int i = 0; i < objType.Count; i++)
        {
            switch (objType[i])
            {
                case 0:
                    case0++;
                    break;
                case 1:
                    case1++;
                    break;
                case 2:
                    case2++;
                    break;
                case 3:
                    case3++;
                    break;
                case 4:
                    case4++;
                    break;
            }
        }
        Debug.Log("20: " + case0);
        Debug.Log("25: " + case1);
        Debug.Log("30: " + case2);
        Debug.Log("35: " + case3);
        Debug.Log("40: " + case4);
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

}
