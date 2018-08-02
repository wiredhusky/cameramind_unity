using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpawnPrefab : MonoBehaviour {
    
    public GameObject soomong_15;
    public GameObject soomong_colored;
    public List<Vector3> posList = new List<Vector3>();
    public List<int> objType = new List<int>();
    public List<GameObject> obj = new List<GameObject>();
    public GameObject levelTransition;
    private GameObject _obj;
    private MoveMove move;
    //private MainMenu mainMenu;

    Animator animator;

    float margin = 0.2f;
    float radious = 0.55f;
    float objRadious = 0.5f;

    float localScale_20 = 0.2f;
    float localScale_25 = 0.25f;
    float localScale_30 = 0.3f;
    float localScale_35 = 0.35f;
    float localScale_40 = 0.4f;

    public int scene;
    public int index_track = 0;
    public int index_twins = 0;
    public int index_alone = 50;

    public bool colored = true;

    float limitTop, limitBottom, limitLeft, limitRight;

    public bool allThingsDone = false;
    int exceptCase = 5;
    int case0, case1, case2, case3, case4;

    public int index = 0;

    public Vector2 onScreenScale_20;
    public Vector2 onScreenScale_25;
    public Vector2 onScreenScale_30;
    public Vector2 onScreenScale_35;
    public Vector2 onScreenScale_40;

    Vector3 worldPos;

    private void Start()
    {
        levelTransition.SetActive(true);
        scene = SceneManager.GetActiveScene().buildIndex;
        Debug.Log("Scene: " + scene);
        //mainMenu = GameObject.FindWithTag("MainMenu").GetComponent<MainMenu>();
        //Debug.Log(mainMenu.sceneName);
        
        setScale();
        PosSearch();

        switch (scene)
        {
            case 0: // main menu
                break;
            case 1: // normal
                break;
            case 2: // horizontal flip
                move = GameObject.FindWithTag("movement").GetComponent<MoveMove>();
                move.centerPosCalculator();
                break;
            case 3: // track
                break;
            case 4: // twins
                break;
            case 5: // alone
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
                /*for(int i = 0; i < posList.Count; i++)
                {
                    switch (objType[i])
                    {
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
                    for(int i2 = posList.Count - 1; i2>=0; i2--)
                    {
                        switch (objType[i])
                        {
                            case 2:
                                objType.Remove(objType[i]);
                                posList.Remove(posList[i]);
                                break;
                            case 3:
                                objType.Remove(objType[i]);
                                posList.Remove(posList[i]);
                                break;
                            case 4:
                                objType.Remove(objType[i]);
                                posList.Remove(posList[i]);
                                break;
                        }
                    }
                }*/
                break;
            case 6: //temptation
                break;
            case 7: //vertical flip
                move = GameObject.FindWithTag("movement").GetComponent<MoveMove>();
                move.centerPosCalculator();
                break;
            case 10: // chaos
                move = GameObject.FindWithTag("movement").GetComponent<MoveMove>();
                move.centerPosCalculator();
                break;
                //double, triple 
        }

        //LevelTransition Resume and Start spawning
        SpawnStart();

        //levelTransition.SetActive(true);
                
        Debug.Log("obj count: " + objType.Count);
        case0 = 0;
        case1 = 0;
        case2 = 0;
        case3 = 0;
        case4 = 0;
        for(int i = 0; i < objType.Count; i++)
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

    public void SpawnStart()
    {
        animator = levelTransition.GetComponent<Animator>();
        animator.speed = 1;
    }

    public void SpawnObj()
    {
        //Vector2 spawnPos;
        
        
        switch (objType[index])
        {
            case 0:
                _obj = Instantiate(soomong_15) as GameObject;                
                _obj.transform.localScale = new Vector3(localScale_20, localScale_20, localScale_20);
                break;
            case 1:                
                _obj = Instantiate(soomong_15) as GameObject;
                _obj.transform.localScale = new Vector3(localScale_25, localScale_25, localScale_25);
                break;
            case 2:
                _obj = Instantiate(soomong_15) as GameObject;
                _obj.transform.localScale = new Vector3(localScale_30, localScale_30, localScale_30);
                break;
            case 3:
                _obj = Instantiate(soomong_15) as GameObject;
                _obj.transform.localScale = new Vector3(localScale_35, localScale_35, localScale_35);
                break;
            case 4:
                _obj = Instantiate(soomong_15) as GameObject;
                _obj.transform.localScale = new Vector3(localScale_40, localScale_40, localScale_40);
                break;
        }
        _obj.transform.position = posList[index];
        obj.Add(_obj);
    }

    public void SpawnObj_Alone()
    {   
        switch (objType[index_alone])
        {
            case 0:
                _obj = Instantiate(soomong_15) as GameObject;
                _obj.transform.localScale = new Vector3(localScale_20, localScale_20, localScale_20);
                break;
            case 1:
                _obj = Instantiate(soomong_15) as GameObject;
                _obj.transform.localScale = new Vector3(localScale_25, localScale_25, localScale_25);
                break;
            case 2:
                _obj = Instantiate(soomong_15) as GameObject;
                _obj.transform.localScale = new Vector3(localScale_30, localScale_30, localScale_30);
                break;
            case 3:
                _obj = Instantiate(soomong_15) as GameObject;
                _obj.transform.localScale = new Vector3(localScale_35, localScale_35, localScale_35);
                break;
            case 4:
                _obj = Instantiate(soomong_15) as GameObject;
                _obj.transform.localScale = new Vector3(localScale_40, localScale_40, localScale_40);
                break;
        }
        _obj.transform.position = posList[index_alone];
        obj.Add(_obj);
    }

    public void SpawnObj_Flip()
    {
        switch (objType[index])
        {
            case 0:
                _obj = Instantiate(soomong_15) as GameObject;
                _obj.transform.localScale = new Vector3(localScale_20, localScale_20, localScale_20);
                break;
            case 1:
                _obj = Instantiate(soomong_15) as GameObject;
                _obj.transform.localScale = new Vector3(localScale_25, localScale_25, localScale_25);
                break;
            case 2:
                _obj = Instantiate(soomong_15) as GameObject;
                _obj.transform.localScale = new Vector3(localScale_30, localScale_30, localScale_30);
                break;
            case 3:
                _obj = Instantiate(soomong_15) as GameObject;
                _obj.transform.localScale = new Vector3(localScale_35, localScale_35, localScale_35);
                break;
            case 4:
                _obj = Instantiate(soomong_15) as GameObject;
                _obj.transform.localScale = new Vector3(localScale_40, localScale_40, localScale_40);
                break;
        }

        if (move.reverse)
        {
            _obj.transform.position = posList[index];
        }
        else
        {
            _obj.transform.position = move.OppCenterPos[index];
        }
        obj.Add(_obj);

    }

    public void SpawnObj_Twins()
    {
        switch (objType[index_twins])
        {
            case 0:
                _obj = Instantiate(soomong_colored) as GameObject;
                _obj.transform.localScale = new Vector3(localScale_20, localScale_20, localScale_20);                
                break;
            case 1:
                _obj = Instantiate(soomong_colored) as GameObject;
                _obj.transform.localScale = new Vector3(localScale_25, localScale_25, localScale_25);
                break;
            case 2:
                _obj = Instantiate(soomong_colored) as GameObject;
                _obj.transform.localScale = new Vector3(localScale_30, localScale_30, localScale_30);
                break;
            case 3:
                _obj = Instantiate(soomong_colored) as GameObject;
                _obj.transform.localScale = new Vector3(localScale_35, localScale_35, localScale_35);
                break;
            case 4:
                _obj = Instantiate(soomong_colored) as GameObject;
                _obj.transform.localScale = new Vector3(localScale_40, localScale_40, localScale_40);
                break;
        }

        _obj.transform.position = posList[index_twins];
        obj.Add(_obj);

        switch (objType[index_twins+1])
        {
            case 0:
                _obj = Instantiate(soomong_15) as GameObject;
                _obj.transform.localScale = new Vector3(localScale_20, localScale_20, localScale_20);
                break;
            case 1:
                _obj = Instantiate(soomong_15) as GameObject;
                _obj.transform.localScale = new Vector3(localScale_25, localScale_25, localScale_25);
                break;
            case 2:
                _obj = Instantiate(soomong_15) as GameObject;
                _obj.transform.localScale = new Vector3(localScale_30, localScale_30, localScale_30);
                break;
            case 3:
                _obj = Instantiate(soomong_15) as GameObject;
                _obj.transform.localScale = new Vector3(localScale_35, localScale_35, localScale_35);
                break;
            case 4:
                _obj = Instantiate(soomong_15) as GameObject;
                _obj.transform.localScale = new Vector3(localScale_40, localScale_40, localScale_40);
                break;
        }

        _obj.transform.position = posList[index_twins + 1];
        obj.Add(_obj);

    }

    public void PosSearch()
    {
        bool overraped = false;

        float randPosX = 0f;
        float randPosY = 0f;

        float distance;
        float newHalfWidth = 0;
        float preHalfWidth = 0;
        float sumOfHalfWidth = 0;
        Vector2 posListTemp;
        Vector2 _objPos = new Vector2(0, 0);

        int randObj;

        while (!allThingsDone)
        {

            randObj = Random.Range(0, exceptCase);            

            switch (randObj)
            {
                case 0: //soomong 20
                    randPosX = Random.Range(limitLeft + onScreenScale_20.x * objRadious, limitRight - onScreenScale_20.x * objRadious);
                    randPosY = Random.Range(limitTop - onScreenScale_20.y * objRadious, limitBottom + onScreenScale_20.y * objRadious);
                    _objPos = new Vector2(randPosX, randPosY);
                    newHalfWidth = onScreenScale_20.x * radious;
                    break;
                case 1: //soomong 25
                    randPosX = Random.Range(limitLeft + onScreenScale_25.x * objRadious, limitRight - onScreenScale_25.x * objRadious);
                    randPosY = Random.Range(limitTop - onScreenScale_25.y * objRadious, limitBottom + onScreenScale_25.y * objRadious);
                    _objPos = new Vector2(randPosX, randPosY);
                    newHalfWidth = onScreenScale_25.x * radious;
                    break;
                case 2: //soomong 30
                    randPosX = Random.Range(limitLeft + onScreenScale_30.x * objRadious, limitRight - onScreenScale_30.x * objRadious);
                    randPosY = Random.Range(limitTop - onScreenScale_30.y * objRadious, limitBottom + onScreenScale_30.y * objRadious);
                    _objPos = new Vector2(randPosX, randPosY);
                    newHalfWidth = onScreenScale_30.x * radious;
                    break;
                case 3: //soomong 35
                    randPosX = Random.Range(limitLeft + onScreenScale_35.x * objRadious, limitRight - onScreenScale_35.x * objRadious);
                    randPosY = Random.Range(limitTop - onScreenScale_35.y * objRadious, limitBottom + onScreenScale_35.y * objRadious);
                    _objPos = new Vector2(randPosX, randPosY);
                    newHalfWidth = onScreenScale_35.x * radious;
                    break;
                case 4: //soomong 40
                    randPosX = Random.Range(limitLeft + onScreenScale_40.x * objRadious, limitRight - onScreenScale_40.x * objRadious);
                    randPosY = Random.Range(limitTop - onScreenScale_40.y * objRadious, limitBottom + onScreenScale_40.y * objRadious);
                    _objPos = new Vector2(randPosX, randPosY);
                    newHalfWidth = onScreenScale_40.x * radious;
                    break;
            }

            if (posList.Count == 0)
            {
                _objPos = new Vector2(randPosX, randPosY);
                posList.Add(_objPos);
                objType.Add(randObj);
            }
            else
            {
                for (int i = 0; i < 300; i++)
                {
                    if (overraped)
                    {
                        switch (randObj)
                        {
                            case 0:
                                randPosX = Random.Range(limitLeft + onScreenScale_20.x * objRadious, limitRight - onScreenScale_20.x * objRadious);
                                randPosY = Random.Range(limitTop - onScreenScale_20.y * objRadious, limitBottom + onScreenScale_20.y * objRadious);
                                _objPos = new Vector2(randPosX, randPosY);
                                newHalfWidth = onScreenScale_20.x * radious;
                                overraped = false;
                                break;
                            case 1:
                                randPosX = Random.Range(limitLeft + onScreenScale_25.x * objRadious, limitRight - onScreenScale_25.x * objRadious);
                                randPosY = Random.Range(limitTop - onScreenScale_25.y * objRadious, limitBottom + onScreenScale_25.y * objRadious);
                                _objPos = new Vector2(randPosX, randPosY);
                                newHalfWidth = onScreenScale_25.x * radious;
                                overraped = false;
                                break;
                            case 2:
                                randPosX = Random.Range(limitLeft + onScreenScale_30.x * objRadious, limitRight - onScreenScale_30.x * objRadious);
                                randPosY = Random.Range(limitTop - onScreenScale_30.y * objRadious, limitBottom + onScreenScale_30.y * objRadious);
                                _objPos = new Vector2(randPosX, randPosY);
                                newHalfWidth = onScreenScale_30.x * radious;
                                overraped = false;
                                break;
                            case 3:
                                randPosX = Random.Range(limitLeft + onScreenScale_35.x * objRadious, limitRight - onScreenScale_35.x * objRadious);
                                randPosY = Random.Range(limitTop - onScreenScale_35.y * objRadious, limitBottom + onScreenScale_35.y * objRadious);
                                _objPos = new Vector2(randPosX, randPosY);
                                newHalfWidth = onScreenScale_35.x * radious;
                                overraped = false;
                                break;
                            case 4:
                                randPosX = Random.Range(limitLeft + onScreenScale_40.x * objRadious, limitRight - onScreenScale_40.x * objRadious);
                                randPosY = Random.Range(limitTop - onScreenScale_40.y * objRadious, limitBottom + onScreenScale_40.y * objRadious);
                                _objPos = new Vector2(randPosX, randPosY);
                                newHalfWidth = onScreenScale_40.x * radious;
                                overraped = false;
                                break;
                        }
                    }

                    for (int i2 = 0; i2 < posList.Count; i2++)
                    {
                        switch (objType[i2])
                        {
                            case 0:
                                preHalfWidth = onScreenScale_20.x * radious;
                                break;
                            case 1:
                                preHalfWidth = onScreenScale_25.x * radious;
                                break;
                            case 2:
                                preHalfWidth = onScreenScale_30.x * radious;
                                break;
                            case 3:
                                preHalfWidth = onScreenScale_35.x * radious;
                                break;
                            case 4:
                                preHalfWidth = onScreenScale_40.x * radious;
                                break;
                        }
                        posListTemp = new Vector2(posList[i2].x, posList[i2].y);
                        distance = (posListTemp - _objPos).sqrMagnitude;
                        sumOfHalfWidth = (preHalfWidth + newHalfWidth) * (preHalfWidth + newHalfWidth);

                        if (distance <= sumOfHalfWidth)
                        {
                            overraped = true;
                            break;
                        }
                    }

                    if(overraped == false)
                    {
                        _objPos = new Vector2(randPosX, randPosY);
                        posList.Add(_objPos);
                        objType.Add(randObj);                        
                        break;
                    }
                }

                //when loop is repeated 300 times
                if (overraped == true)
                {
                    switch (randObj)
                    {
                        case 0:                            
                            allThingsDone = true;
                            //isSearched = true;
                            Debug.Log("20 is removed");
                            /*
                            for(int i3=0;i3 < objType.Count; i3++)
                            {
                                Debug.Log(objType[i3]);
                            }*/
                            break;
                        case 1:
                            exceptCase = 1;
                            overraped = false;
                            Debug.Log("25 is removed");
                            break;
                        case 2:
                            exceptCase = 2;
                            overraped = false;
                            Debug.Log("30 is removed");
                            break;
                        case 3:
                            exceptCase = 3;
                            overraped = false;
                            Debug.Log("35 is removed");
                            break;
                        case 4:
                            exceptCase = 4;
                            overraped = false;
                            Debug.Log("40 is removed");
                            break;
                    }
                }
            }
        }
    }
    
    /*
    public Vector2 PosReturn()
    {
        return posList[index];        
    }

    public Vector2 PosReturn_Track(int _index)
    {
        return posList[_index];
    }*/

    public void setScale()
    {
        Vector3 temp;

        RectTransform rt;

        rt = (RectTransform)soomong_15.transform;
                
        temp.x = Screen.width;
        temp.y = Screen.height;
        temp.z = 0;

        worldPos = Camera.main.ScreenToWorldPoint(temp);

        //set boundaries
        limitTop = worldPos.y - margin;
        limitBottom = worldPos.y * -1.0f + margin;
        limitLeft = worldPos.x * -1.0f + margin;
        limitRight = worldPos.x - margin;
        
        onScreenScale_20.x = rt.rect.width * localScale_20;
        onScreenScale_20.y = rt.rect.height * localScale_20;

        onScreenScale_25.x = rt.rect.width * localScale_25;
        onScreenScale_25.y = rt.rect.height * localScale_25;

        onScreenScale_30.x = rt.rect.width * localScale_30;
        onScreenScale_30.y = rt.rect.height * localScale_30;

        onScreenScale_35.x = rt.rect.width * localScale_35;
        onScreenScale_35.y = rt.rect.height * localScale_35;

        onScreenScale_40.x = rt.rect.width * localScale_40;
        onScreenScale_40.y = rt.rect.height * localScale_40;

        //center orinted pos calculation
        /*
        xLimit_20.x = worldPos.x - onScreenScale_20.x;
        xLimit_20.y = worldPos.y * -1.0f + onScreenScale_20.y;

        xLimit_25.x = worldPos.x - onScreenScale_25.x;
        xLimit_25.y = worldPos.y * -1.0f + onScreenScale_25.y;

        xLimit_30.x = worldPos.x - onScreenScale_30.x;
        xLimit_30.y = worldPos.y * -1.0f + onScreenScale_30.y;

        xLimit_35.x = worldPos.x - onScreenScale_35.x;
        xLimit_35.y = worldPos.y * -1.0f + onScreenScale_35.y;

        xLimit_40.x = worldPos.x - onScreenScale_40.x;
        xLimit_40.y = worldPos.y * -1.0f + onScreenScale_40.y;
        */

        /*
        Debug.Log("Soomong localscale x: " + soomong_15.transform.localScale.x);
        Debug.Log("Rect rect x: " + rt.rect.width);
        Debug.Log(onScreenScale_20.x);
        Debug.Log(onScreenScale_20.y);
        Debug.Log(worldPos.x);
        Debug.Log(worldPos.y);
        Debug.Log(xLimit_20.x);
        Debug.Log(xLimit_20.y);
        */

        
    }

   

    /*
    private void RandomTest()
    {
        float randPosX;
        float randPosY;
        randPosX = Random.Range(-9.2f, 5.4f);
        randPosY = Random.Range(-2.5f, 4.6f);
        Debug.Log("X: " + randPosX);
        Debug.Log("Y: " + randPosY);
    }*/


    /*
        private void Update()
        {        
           if(Time.time > nextTime)
            {
                nextTime = Time.time + TimeLeft;

                if (!allThingsDone)
                {
                    SpawnObj();
                }            
                //RandomTest();
            }
        }
        */

}
