using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RootSpawnManager : MonoBehaviour {

    public static RootSpawnManager rootSpawnManager;

    public GameObject soomong_15;
    public GameObject soomong_colored;

    float margin = 0.2f;
    float radious = 0.55f;
    float objRadious = 0.5f;

    float localScale_20 = 0.2f;
    float localScale_25 = 0.25f;
    float localScale_30 = 0.3f;
    float localScale_35 = 0.35f;
    float localScale_40 = 0.4f;

    float limitTop, limitBottom, limitLeft, limitRight;

    public bool allThingsDone = false;
    public int exceptCase = 5;

    public Vector2 onScreenScale_20;
    public Vector2 onScreenScale_25;
    public Vector2 onScreenScale_30;
    public Vector2 onScreenScale_35;
    public Vector2 onScreenScale_40;

    GameObject _obj;

    Animator animator;

    Vector3 worldPos;

    int randNum, randAni;

    private void Awake()
    {
        if(rootSpawnManager == null){
            rootSpawnManager = this;
        }
    }

    public void setScale()
    {
        Vector3 temp;

        RectTransform rt;

        rt = (RectTransform)soomong_15.transform;

        temp.x = Screen.width;
        temp.y = Screen.height;
        temp.z = 0;
        Debug.Log("Width: " + temp.x);
        Debug.Log("Height: " + temp.y);

        worldPos = Camera.main.ScreenToWorldPoint(temp);

        Debug.Log("WorldPos: " + worldPos);

        //set boundaries
        limitTop = worldPos.y - margin;
        limitBottom = worldPos.y * -1.0f + margin + 1.6f;
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
    }

    public void PosSearch(List<Vector3> posList, List<int> objType)
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

                    if (overraped == false)
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

    public void objCreator(List<int> objType, int index, List<GameObject> obj, 
                           List<Vector3> posList)
    {
        switch (RootUIManager.rootUIManager.sceneName)
        {
            case "MainMenu":
                break;
            case "Flip Horizon":
                SpawnObj_Flip(objType, index, obj, posList);
                break;
            case "Track": // track
                SpawnObj(objType, index, obj, posList);
                InGameManager.inGameManager.EventHandler();
                break;
            case "Twins": // twins
                SpawnObj_Twins(objType, InGameManager.inGameManager.index_twins, obj, posList);
                break;
            case "Alone": // alone
                SpawnObj_Alone(objType, InGameManager.inGameManager.index_alone, obj, posList);
                InGameManager.inGameManager.RendererHandler();
                break;
            case "Temptation": // temptation
                SpawnObj(objType, index, obj, posList);
                randNum = Random.Range(0, InGameManager.inGameManager.index);
                randAni = Random.Range(0, 3);
                switch (randAni)
                {
                    case 0:
                        animator = InGameManager.inGameManager.obj[randNum].GetComponent<Animator>();
                        animator.SetTrigger("rotation");
                        break;
                    case 1:
                        animator = InGameManager.inGameManager.obj[randNum].GetComponent<Animator>();
                        animator.SetTrigger("angry");
                        break;
                    case 2:
                        animator = InGameManager.inGameManager.obj[randNum].GetComponent<Animator>();
                        animator.SetTrigger("shaking");
                        break;
                }
                break;
            case "Flip Vertical": // vertical flip
                SpawnObj_Flip(objType, index, obj, posList);
                break;
            case "Chaos": // mix
                SpawnObj_Flip(objType, index, obj, posList);
                randNum = Random.Range(0, InGameManager.inGameManager.index);
                randAni = Random.Range(0, 3);
                switch (randAni)
                {
                    case 0:
                        animator = InGameManager.inGameManager.obj[randNum].GetComponent<Animator>();
                        animator.SetTrigger("rotation");
                        break;
                    case 1:
                        animator = InGameManager.inGameManager.obj[randNum].GetComponent<Animator>();
                        animator.SetTrigger("angry");
                        break;
                    case 2:
                        animator = InGameManager.inGameManager.obj[randNum].GetComponent<Animator>();
                        animator.SetTrigger("shaking");
                        break;
                }
                break;
            default: // normal, double, triple
                SpawnObj(objType, index, obj, posList);
                break;
        }
    }

    public void SpawnObj(List<int> objType, int index, List<GameObject> obj, List<Vector3> posList)
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
        _obj.transform.position = posList[index];
        obj.Add(_obj);
    }

    public void SpawnObj_Alone(List<int> objType, int index, List<GameObject> obj, List<Vector3> posList)
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
        _obj.transform.position = posList[index];
        obj.Add(_obj);
    }

    public void SpawnObj_Flip(List<int> objType, int index, List<GameObject> obj, List<Vector3> posList)
    {
        Vector3 tempPos;
        tempPos = CenterPosCalculator(posList[index]);
        InGameManager.inGameManager.oppCenterPos.Add(tempPos);
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

        if (InGameManager.inGameManager.turnChk)
        {
            _obj.transform.position = posList[index];
        }
        else
        {
            _obj.transform.position = tempPos;
        }
        obj.Add(_obj);
    }

    public void SpawnObj_Twins(List<int> objType, int index, List<GameObject> obj, List<Vector3> posList)
    {
        switch (objType[index])
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

        _obj.transform.position = posList[index];
        obj.Add(_obj);

        switch (objType[index + 1])
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
        _obj.transform.position = posList[index + 1];
        obj.Add(_obj);
    }

    public Vector3 CenterPosCalculator(Vector3 objPos)
    {
        Vector3 temp;
        //float distanceTemp;
        temp.z = 0;

        switch (RootUIManager.rootUIManager.sceneName)
        {
            case "Flip Horizon":
                temp.x = objPos.x * -1.0f;
                temp.y = objPos.y;
                break;
            default:
                temp.x = objPos.x;
                temp.y = objPos.y * -1.0f + margin + 1.6f;
                break;
        }
        return temp;
    }
}
