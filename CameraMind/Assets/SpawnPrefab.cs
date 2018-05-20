using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SpawnPrefab : MonoBehaviour {

      
    public GameObject soomong_15;
    public GameObject soomong_25;
    public GameObject soomong_35;
    public GameObject soomong_50;
    public GameObject soomong_70;
    public List<Vector2> posList = new List<Vector2>();
    public List<int> objType = new List<int>();
    //public LevelCounter level;
    public GameObject levelTransition;
    
    bool allThingsDone = false;
    //float objPosX;
    //float objPosY;
    //float TimeLeft = 1.0f;
    //float TimeLeftFinal = 5.0f;
    //float nextTime = 0.0f;

    //to remove randObj when some randOjb is failed to search position
    int case0 = 6;
    int case1 = 6;
    int case2 = 6;
    int case3 = 6;
    int case4 = 6;

    public int index = 0;

    Vector2 onScreenScale_20;
    Vector2 onScreenScale_25;
    Vector2 onScreenScale_30;
    Vector2 onScreenScale_35;
    Vector2 onScreenScale_40;

    Vector2 xLimit_20;
    Vector2 xLimit_25;
    Vector2 xLimit_30;
    Vector2 xLimit_35;
    Vector2 xLimit_40;

    Vector3 worldPos;
    
    //int count = 0;
    //int temp = 0;

    //public GameObject temp;
    //Vector3 mousePos;
    Vector3 originScale;

    //Vector3 screenPos;    

    public void SpawnObj()
    {
        GameObject _obj;
        Vector2 spawnPos;
        //int type = 4;

        /*if (allThingsDone)
        {

        }*/

        switch (objType[index])
        {
            case 0:
                _obj = Instantiate(soomong_15) as GameObject;
                originScale = soomong_15.transform.localScale;
                _obj.transform.localScale = originScale;

                spawnPos = new Vector2(posList[index].x, posList[index].y);

                _obj.transform.position = spawnPos;
                index++;
                //FindObjectOfType<LevelCounter>().counter.text = "Level " + (index + 1).ToString();
                //level.counter.text = "Level " + (index + 1).ToString();
                break;
            case 1:
                _obj = Instantiate(soomong_25) as GameObject;
                originScale = soomong_25.transform.localScale;
                _obj.transform.localScale = originScale;

                spawnPos = new Vector2(posList[index].x, posList[index].y);

                _obj.transform.position = spawnPos;
                index++;
                //FindObjectOfType<LevelCounter>().counter.text = "Level " + (index + 1).ToString();
                //level.counter.text = "Level " + (index + 1).ToString();
                break;
            case 2:
                _obj = Instantiate(soomong_35) as GameObject;
                originScale = soomong_35.transform.localScale;
                _obj.transform.localScale = originScale;

                spawnPos = new Vector2(posList[index].x, posList[index].y);

                _obj.transform.position = spawnPos;
                index++;
                //FindObjectOfType<LevelCounter>().counter.text = "Level " + (index + 1).ToString();
                //level.counter.text = "Level " + (index + 1).ToString();
                break;
            case 3:
                _obj = Instantiate(soomong_50) as GameObject;
                originScale = soomong_50.transform.localScale;
                _obj.transform.localScale = originScale;

                spawnPos = new Vector2(posList[index].x, posList[index].y);

                _obj.transform.position = spawnPos;
                index++;
                //FindObjectOfType<LevelCounter>().counter.text = "Level " + (index + 1).ToString();
                //level.counter.text = "Level " + (index + 1).ToString();
                break;
            case 4:
                _obj = Instantiate(soomong_70) as GameObject;
                originScale = soomong_70.transform.localScale;
                _obj.transform.localScale = originScale;

                spawnPos = new Vector2(posList[index].x, posList[index].y);

                _obj.transform.position = spawnPos;
                index++;
                //FindObjectOfType<LevelCounter>().counter.text = "Level " + (index + 1).ToString();
                //level.counter.text = "Level " + (index + 1).ToString();
                break;
        }

        /*
        while (!isSearched)
        {
            type = PosSearch();
        }

        /*
        if (isSearched && !allThingsDone)
        {
            switch (type)
            {
                case 0:
                    _obj = Instantiate(soomong_15) as GameObject;
                    originScale = soomong_15.transform.localScale;
                    _obj.transform.localScale = originScale;

                    spawnPos = new Vector2(objPosX, objPosY);

                    _obj.transform.position = spawnPos;
                    break;
                case 1:
                    _obj = Instantiate(soomong_25) as GameObject;
                    originScale = soomong_25.transform.localScale;
                    _obj.transform.localScale = originScale;

                    spawnPos = new Vector2(objPosX, objPosY);

                    _obj.transform.position = spawnPos;
                    break;
                case 2:
                    _obj = Instantiate(soomong_35) as GameObject;
                    originScale = soomong_35.transform.localScale;
                    _obj.transform.localScale = originScale;

                    spawnPos = new Vector2(objPosX, objPosY);

                    _obj.transform.position = spawnPos;
                    break;
                case 3:
                    _obj = Instantiate(soomong_50) as GameObject;
                    originScale = soomong_50.transform.localScale;
                    _obj.transform.localScale = originScale;

                    spawnPos = new Vector2(objPosX, objPosY);

                    _obj.transform.position = spawnPos;
                    break;
                case 4:
                    _obj = Instantiate(soomong_70) as GameObject;
                    originScale = soomong_70.transform.localScale;
                    _obj.transform.localScale = originScale;

                    spawnPos = new Vector2(objPosX, objPosY);

                    _obj.transform.position = spawnPos;
                    break;
            }
            count++;
            //Debug.Log("Count: " + count);
        }*/
        //isSearched = false;
    }

    public void PosSearch()
    {
        bool isSearched = false;
        float randPosX = 0f;
        float randPosY = 0f;
        float oriPosX = 0f;
        float oriPosY = 0f;
        float comPosX = 0f;
        float comPosY = 0f;
        bool overraped = false;
        int randObj=4;

        float wLimitLeft;
        float hLimitTop;
        float margin = 0.1f;

        Vector2 _objPos;

        wLimitLeft = worldPos.x * -1.0f + margin;
        hLimitTop = worldPos.y - margin;

        while (!allThingsDone)
        {
            randObj = Random.Range(0, 5);
            if (randObj == case0)
            {
                break;
            }else if(randObj == case1)
            {
                continue;
            }else if(randObj == case2)
            {
                continue;
            }else if(randObj == case3)
            {
                continue;
            }else if(randObj == case4)
            {
                continue;
            }
            else
            {
                break;
            }
                
        }        

        switch (randObj)
        {
            case 0: //soomong 20
                randPosX = Random.Range(wLimitLeft, xLimit_20.x-margin);
                randPosY = Random.Range(xLimit_20.y + margin, hLimitTop);
                comPosX = randPosX + onScreenScale_20.x;
                comPosY = randPosY - onScreenScale_20.y;
                break;
            case 1: //soomong 25
                randPosX = Random.Range(wLimitLeft, xLimit_25.x-margin);
                randPosY = Random.Range(xLimit_25.y + margin, hLimitTop);
                comPosX = randPosX + onScreenScale_25.x;
                comPosY = randPosY - onScreenScale_25.y;
                break;
            case 2: //soomong 30
                randPosX = Random.Range(wLimitLeft, xLimit_30.x-margin);
                randPosY = Random.Range(xLimit_30.y + margin, hLimitTop);
                comPosX = randPosX + onScreenScale_30.x;
                comPosY = randPosY - onScreenScale_30.y;
                break;
            case 3: //soomong 35
                randPosX = Random.Range(wLimitLeft, xLimit_35.x-margin);
                randPosY = Random.Range(xLimit_35.y + margin, hLimitTop);
                comPosX = randPosX + onScreenScale_35.x;
                comPosY = randPosY - onScreenScale_35.y;
                break;
            case 4: //soomong 40
                randPosX = Random.Range(wLimitLeft, xLimit_40.x-margin);
                randPosY = Random.Range(xLimit_40.y + margin, hLimitTop);
                comPosX = randPosX + onScreenScale_40.x;
                comPosY = randPosY - onScreenScale_40.y;
                break;
        }
        
        if (posList.Count == 0)
        {
            _objPos = new Vector2(randPosX, randPosY);
            posList.Add(_objPos);
            objType.Add(randObj); // Add obj Type
            //objPosX = randPosX;
            //objPosY = randPosY;

            isSearched = true;
        }
        else
        {
            for(int i = 0; i<200; i++)
            {
                switch (randObj)
                {
                    case 0:
                        if (overraped)
                        {
                            randPosX = Random.Range(wLimitLeft, xLimit_20.x - margin);
                            randPosY = Random.Range(xLimit_20.y + margin, hLimitTop);
                            comPosX = randPosX + onScreenScale_20.x;
                            comPosY = randPosY - onScreenScale_20.y;
                            overraped = false;
                        }
                        break;
                    case 1:
                        if (overraped)
                        {
                            randPosX = Random.Range(wLimitLeft, xLimit_25.x - margin);
                            randPosY = Random.Range(xLimit_25.y + margin, hLimitTop);
                            comPosX = randPosX + onScreenScale_25.x;
                            comPosY = randPosY - onScreenScale_25.y;
                            overraped = false;
                        }
                        break;
                    case 2:
                        if (overraped)
                        {
                            randPosX = Random.Range(wLimitLeft, xLimit_30.x - margin);
                            randPosY = Random.Range(xLimit_30.y + margin, hLimitTop);
                            comPosX = randPosX + onScreenScale_30.x;
                            comPosY = randPosY - onScreenScale_30.y;
                        }
                        break;
                    case 3:
                        if (overraped)
                        {
                            randPosX = Random.Range(wLimitLeft, xLimit_35.x - margin);
                            randPosY = Random.Range(xLimit_35.y + margin, hLimitTop);
                            comPosX = randPosX + onScreenScale_35.x;
                            comPosY = randPosY - onScreenScale_35.y;
                            overraped = false;
                        }
                        break;
                    case 4:
                        if (overraped)
                        {
                            randPosX = Random.Range(wLimitLeft, xLimit_40.x - margin);
                            randPosY = Random.Range(xLimit_40.y + margin, hLimitTop);
                            comPosX = randPosX + onScreenScale_40.x;
                            comPosY = randPosY - onScreenScale_40.y;
                            overraped = false;
                        }
                        break;
                }              

                for (int i2 = 0; i2 < posList.Count; i2++)
                {
                                        
                    switch (objType[i2])
                    {
                        case 0:
                            oriPosX = posList[i2].x + onScreenScale_20.x;
                            oriPosY = posList[i2].y - onScreenScale_20.y;
                            break;
                        case 1:
                            oriPosX = posList[i2].x + onScreenScale_25.x;
                            oriPosY = posList[i2].y - onScreenScale_25.y;
                            break;
                        case 2:
                            oriPosX = posList[i2].x + onScreenScale_30.x;
                            oriPosY = posList[i2].y - onScreenScale_30.y;
                            break;
                        case 3:
                            oriPosX = posList[i2].x + onScreenScale_35.x;
                            oriPosY = posList[i2].y - onScreenScale_35.y;
                            break;
                        case 4:
                            oriPosX = posList[i2].x + onScreenScale_40.x;
                            oriPosY = posList[i2].y - onScreenScale_40.y;
                            break;
                    }                    

                    //compared new obj to old obj
                    if (randPosX >= posList[i2].x && randPosX <= oriPosX && randPosY >= oriPosY && randPosY <= posList[i2].y) // left-top
                    {
                        overraped = true;
                        //Debug.Log("Overraped");
                        break;
                    }
                    else if (comPosX >= posList[i2].x && comPosX <= oriPosX && randPosY >= oriPosY && randPosY <= posList[i2].y) // right-top
                    {
                        overraped = true;
                        //Debug.Log("Overraped");
                        break;
                    }
                    else if (randPosX >= posList[i2].x && randPosX <= oriPosX && comPosY >= oriPosY && comPosY <= posList[i2].y) // left-bottom
                    {
                        overraped = true;
                        //Debug.Log("Overraped");
                        break;
                    }
                    else if (comPosX >= posList[i2].x && comPosX <= oriPosX && comPosY >= oriPosY && comPosY <= posList[i2].y) // right-bottom
                    {
                        overraped = true;
                        //Debug.Log("Overraped");
                        break;
                    }
                    
                    //compare old obj to new obj
                    if (posList[i2].x >= randPosX && posList[i2].x <= comPosX && posList[i2].y >= comPosY && posList[i2].y <= randPosY) // left-top
                    {
                        overraped = true;
                        //Debug.Log("Overraped");
                        break;
                    }else if(oriPosX >= randPosX && oriPosX <= comPosX && posList[i2].y >= comPosY && posList[i2].y <= randPosY) // right-top
                    {
                        overraped = true;
                        //Debug.Log("Overraped");
                        break;
                    }else if(posList[i2].x >= randPosX && posList[i2].x <= comPosX && oriPosY >= comPosY && oriPosY <= randPosY) // left-bottom
                    {
                        overraped = true;
                        //Debug.Log("Overraped");
                        break;
                    }else if(oriPosX >= randPosX && oriPosX <= comPosX && oriPosY >= comPosY && oriPosY <= randPosY) // right-bottom
                    {
                        overraped = true;
                       // Debug.Log("Overraped");
                        break;
                    }
                }

                //searched
                if (overraped == false)
                {
                    //Debug.Log("Searched");
                    _objPos = new Vector2(randPosX, randPosY);
                    posList.Add(_objPos);
                    objType.Add(randObj);

                    //objPosX = randPosX;
                    //objPosY = randPosY;

                    isSearched = true;
                    break;
                }
                
                
            }
            //when loop is repeated 200 times
            if (isSearched == false)
            {
                switch (randObj)
                {
                    case 0:
                        case0 = 0;
                        allThingsDone = true;
                        //isSearched = true;
                        Debug.Log("15 is removed");
                        /*
                        for(int i3=0;i3 < objType.Count; i3++)
                        {
                            Debug.Log(objType[i3]);
                        }*/
                        break;
                    case 1:
                        case1 = 1;
                        Debug.Log("25 is removed");
                        
                        break;
                    case 2:
                        case2 = 2;
                        Debug.Log("35 is removed");
                        
                        break;
                    case 3:
                        case3 = 3;
                        Debug.Log("50 is removed");
                        
                        break;
                    case 4:
                        case4 = 4;
                        Debug.Log("70 is removed");
                        
                        break;
                }
                /*
                if (case0 == 0 && case1 == 1 && case2 == 2 && case3 == 3 && case4 == 4)
                {
                    Debug.Log("All things Done!!!");
                    allThingsDone = true;
                    
                }*/
            }
        }
        //return randObj;
    } 

    private void Start()
    {
        setScale();
        levelTransition.SetActive(true);

        //level = FindObjectOfType<LevelCounter>();
        //level.counter.text = "Level " + (index + 1).ToString();

        //FindObjectOfType<LevelCounter>().counter.text = "Level " + (index + 1).ToString();




        while (!allThingsDone)
        {
            PosSearch();
        }
        // SpawnObj();
        //Invoke("SpawnObj", 1.0f);

        
    }

    public Vector2 PosReturn()
    {
        return posList[index-1];
    }

    public void setScale()
    {
        Vector3 temp;

        RectTransform rt;

        float localscale_20 = soomong_15.transform.localScale.x;
        float localscale_25 = soomong_25.transform.localScale.x;
        float localscale_30 = soomong_35.transform.localScale.x;
        float localscale_35 = soomong_50.transform.localScale.x;
        float localscale_40 = soomong_70.transform.localScale.x;        

        rt = (RectTransform)soomong_70.transform;
                
        temp.x = Screen.width;
        temp.y = Screen.height;
        temp.z = 0;

        worldPos = Camera.main.ScreenToWorldPoint(temp);

        
        onScreenScale_20.x = rt.rect.width * localscale_20;
        onScreenScale_20.y = rt.rect.height * localscale_20;

        onScreenScale_25.x = rt.rect.width * localscale_25;
        onScreenScale_25.y = rt.rect.height * localscale_25;

        onScreenScale_30.x = rt.rect.width * localscale_30;
        onScreenScale_30.y = rt.rect.height * localscale_30;

        onScreenScale_35.x = rt.rect.width * localscale_35;
        onScreenScale_35.y = rt.rect.height * localscale_35;

        onScreenScale_40.x = rt.rect.width * localscale_40;
        onScreenScale_40.y = rt.rect.height * localscale_40;

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

        Debug.Log("Soomong localscale x: " + soomong_15.transform.localScale.x);
        Debug.Log("Rect rect x: " + rt.rect.width);
        Debug.Log(onScreenScale_20.x);
        Debug.Log(onScreenScale_20.y);
        Debug.Log(worldPos.x);
        Debug.Log(worldPos.y);
        Debug.Log(xLimit_20.x);
        Debug.Log(xLimit_20.y);

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
