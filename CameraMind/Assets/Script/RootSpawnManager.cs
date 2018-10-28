using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RootSpawnManager : MonoBehaviour {

    public static RootSpawnManager rootSpawnManager;

    public GameObject soomong_15;
    public GameObject soomong_colored;
    public GameObject cat;
    public Animator animatorCat;

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
    //Renderer objRenderer;

    Vector3 worldPos;
    Vector3 tempPos;
    Vector3 temp;

    int randNum, randAni;
    int case0, case1, case2, case3, case4;

    private void Awake()
    {
        if(rootSpawnManager == null){
            rootSpawnManager = this;
        }
    }

    public void InstantiateObj(GameObject obj, int index)
    {
        for (int i = 0; i < index; i++)
        {
            switch (InGameManager.inGameManager.objType[i])
            {
                case 0:
                    _obj = Instantiate(obj) as GameObject;
                    _obj.transform.localScale = new Vector3(localScale_20, localScale_20, localScale_20);
                    _obj.transform.position = InGameManager.inGameManager.posList[i];
                    InGameManager.inGameManager.obj.Add(_obj);
                    animator = _obj.GetComponent<Animator>();                    
                    InGameManager.inGameManager.animatorList.Add(animator);
                    //objRenderer = _obj.GetComponent<Renderer>();
                    //InGameManager.inGameManager.rendererList.Add(objRenderer);
                    break;
                case 1:
                    _obj = Instantiate(obj) as GameObject;
                    _obj.transform.localScale = new Vector3(localScale_25, localScale_25, localScale_25);
                    _obj.transform.position = InGameManager.inGameManager.posList[i];
                    InGameManager.inGameManager.obj.Add(_obj);
                    animator = _obj.GetComponent<Animator>();
                    InGameManager.inGameManager.animatorList.Add(animator);
                    //objRenderer = _obj.GetComponent<Renderer>();
                    //InGameManager.inGameManager.rendererList.Add(objRenderer);
                    break;
                case 2:
                    _obj = Instantiate(obj) as GameObject;
                    _obj.transform.localScale = new Vector3(localScale_30, localScale_30, localScale_30);
                    _obj.transform.position = InGameManager.inGameManager.posList[i];
                    InGameManager.inGameManager.obj.Add(_obj);
                    animator = _obj.GetComponent<Animator>();
                    InGameManager.inGameManager.animatorList.Add(animator);
                    //objRenderer = _obj.GetComponent<Renderer>();
                    //InGameManager.inGameManager.rendererList.Add(objRenderer);
                    break;
                case 3:
                    _obj = Instantiate(obj) as GameObject;
                    _obj.transform.localScale = new Vector3(localScale_35, localScale_35, localScale_35);
                    _obj.transform.position = InGameManager.inGameManager.posList[i];
                    InGameManager.inGameManager.obj.Add(_obj);
                    animator = _obj.GetComponent<Animator>();
                    InGameManager.inGameManager.animatorList.Add(animator);
                    //objRenderer = _obj.GetComponent<Renderer>();
                    //InGameManager.inGameManager.rendererList.Add(objRenderer);
                    break;
                case 4:
                    _obj = Instantiate(obj) as GameObject;                    
                    _obj.transform.localScale = new Vector3(localScale_40, localScale_40, localScale_40);
                    _obj.transform.position = InGameManager.inGameManager.posList[i];
                    InGameManager.inGameManager.obj.Add(_obj);
                    animator = _obj.GetComponent<Animator>();
                    InGameManager.inGameManager.animatorList.Add(animator);
                    //objRenderer = _obj.GetComponent<Renderer>();
                    //InGameManager.inGameManager.rendererList.Add(objRenderer);
                    break;
            }
        }

        Debug.Log("obj count: " + InGameManager.inGameManager.objType.Count);
        case0 = 0;
        case1 = 0;
        case2 = 0;
        case3 = 0;
        case4 = 0;
        for (int i = 0; i < InGameManager.inGameManager.objType.Count; i++)
        {
            switch (InGameManager.inGameManager.objType[i])
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

    public void setScale(GameObject spawnObj)
    {
        Vector3 temp;

        RectTransform rt;

        rt = (RectTransform)spawnObj.transform;

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

    public void PosSearchDance(List<Vector3> posList, List<int> objType)
    {
        float marginWidth, marginHeight;
        Vector2 posListTemp;
        posListTemp.x = worldPos.x * -1.0f + margin;
        posListTemp.y = 1.6f;
        marginWidth = ((worldPos.x * 2 - (margin * 2)) - (onScreenScale_35.x * 5)) / 4;
        marginHeight = ((worldPos.y * 2 - (margin * 2) - 1.6f) - (onScreenScale_35.y * 7)) / 6;
        for (int i = 0; i < 5;i++){
            posListTemp.x += onScreenScale_35.x * 0.5f;
            posListTemp.y = 1.6f;
            posList.Add(posListTemp);
            objType.Add(3);
            posListTemp.x += onScreenScale_35.x * 0.5f + marginWidth;
        }

        for (int j = 0; j < 3;j++){
            posListTemp.y = 1.6f + ((onScreenScale_35.y + marginHeight) * (j + 1));

            for (int k = 0; k < 5;k++){
                //top 5
                posListTemp.x = posList[k].x;
                posList.Add(posListTemp);
                objType.Add(3);
            }

            posListTemp.y = 1.6f - ((onScreenScale_35.y + marginHeight) * (j + 1));

            for (int l = 0; l < 5;l++){
                //bottom 5
                posListTemp.x = posList[l].x;
                posList.Add(posListTemp);
                objType.Add(3);
            }
        }
        allThingsDone = true;
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

    public void objCreator()
    {
        switch (RootUIManager.rootUIManager.sceneName)
        {
            case "MainMenu":
                break;
            case "Flip Horizon":
                SpawnObj_Flip();
                break;
            case "Track": // track
                SpawnObj();
                InGameManager.inGameManager.EventHandler();
                break;
            case "Twins": // twins
                SpawnObj_Twins();
                break;
            case "Alone": // alone
                SpawnObj_Alone();
                InGameManager.inGameManager.RendererHandler();
                break;
            case "Temptation": // temptation
                SpawnObj();
                randNum = Random.Range(0, InGameManager.inGameManager.index);
                randAni = Random.Range(0, 3);
                switch (randAni)
                {
                    case 0:
                        InGameManager.inGameManager.animatorList[randNum].SetTrigger("rotation");                        
                        break;
                    case 1:
                        InGameManager.inGameManager.animatorList[randNum].SetTrigger("angry");
                        break;
                    case 2:
                        InGameManager.inGameManager.animatorList[randNum].SetTrigger("shaking");
                        break;
                }
                break;
            case "Flip Vertical": // vertical flip
                SpawnObj_Flip();
                break;
            case "Chaos": // mix
                SpawnObj_Flip();
                randNum = Random.Range(0, InGameManager.inGameManager.index);
                randAni = Random.Range(0, 3);
                switch (randAni)
                {
                    case 0:
                        InGameManager.inGameManager.animatorList[randNum].SetTrigger("rotation");
                        break;
                    case 1:
                        InGameManager.inGameManager.animatorList[randNum].SetTrigger("angry");
                        break;
                    case 2:
                        InGameManager.inGameManager.animatorList[randNum].SetTrigger("shaking");
                        break;
                }
                break;
            case "DanceDance":
                if (InGameManager.inGameManager.index == 0)
                {
                    for (int i = 0; i < 5; i++)
                    {
                        InGameManager.inGameManager.obj[i].SetActive(true);
                    }
                }
                SpawnObjDance();
                break;                    
            default: // normal, double, triple
                SpawnObj();
                break;
        }
    }

    public void SpawnObjDance()
    {
        //Change animator of Objs
        if(InGameManager.inGameManager.index != 0){
            
        }
    }

    public void SpawnObj()
    {
        //InGameManager.inGameManager.rendererList[InGameManager.inGameManager.index].enabled = true;
        InGameManager.inGameManager.obj[InGameManager.inGameManager.index].SetActive(true);
    }

    public void SpawnObj_Alone()
    {
        //InGameManager.inGameManager.rendererList[InGameManager.inGameManager.index].enabled = true;
        InGameManager.inGameManager.obj[InGameManager.inGameManager.index].SetActive(true);
    }

    public void SpawnObj_Flip()
    {        
        tempPos = CenterPosCalculator(InGameManager.inGameManager.posList[InGameManager.inGameManager.index]);
        InGameManager.inGameManager.oppCenterPos.Add(tempPos);

        if (InGameManager.inGameManager.turnChk)
        {
            InGameManager.inGameManager.obj[InGameManager.inGameManager.index].transform.position = 
                InGameManager.inGameManager.posList[InGameManager.inGameManager.index];
        }
        else
        {
            InGameManager.inGameManager.obj[InGameManager.inGameManager.index].transform.position = tempPos;
        }
        //InGameManager.inGameManager.rendererList[InGameManager.inGameManager.index].enabled = true;
        InGameManager.inGameManager.obj[InGameManager.inGameManager.index].SetActive(true);
    }

    public void SpawnObj_Twins()
    {
        //InGameManager.inGameManager.rendererList[InGameManager.inGameManager.index].enabled = true;
        //InGameManager.inGameManager.rendererList[InGameManager.inGameManager.index+1].enabled = true;
        InGameManager.inGameManager.obj[InGameManager.inGameManager.index].SetActive(true);
        InGameManager.inGameManager.obj[InGameManager.inGameManager.index + 1].SetActive(true);
    }

    public Vector3 CenterPosCalculator(Vector3 objPos)
    {        
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
