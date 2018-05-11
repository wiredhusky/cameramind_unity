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
    public LevelCounter level;
    
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
                level.counter.text = "Level " + (index + 1).ToString();
                break;
            case 1:
                _obj = Instantiate(soomong_25) as GameObject;
                originScale = soomong_15.transform.localScale;
                _obj.transform.localScale = originScale;

                spawnPos = new Vector2(posList[index].x, posList[index].y);

                _obj.transform.position = spawnPos;
                index++;
                level.counter.text = "Level " + (index + 1).ToString();
                break;
            case 2:
                _obj = Instantiate(soomong_35) as GameObject;
                originScale = soomong_15.transform.localScale;
                _obj.transform.localScale = originScale;

                spawnPos = new Vector2(posList[index].x, posList[index].y);

                _obj.transform.position = spawnPos;
                index++;
                level.counter.text = "Level " + (index + 1).ToString();
                break;
            case 3:
                _obj = Instantiate(soomong_50) as GameObject;
                originScale = soomong_15.transform.localScale;
                _obj.transform.localScale = originScale;

                spawnPos = new Vector2(posList[index].x, posList[index].y);

                _obj.transform.position = spawnPos;
                index++;
                level.counter.text = "Level " + (index + 1).ToString();
                break;
            case 4:
                _obj = Instantiate(soomong_70) as GameObject;
                originScale = soomong_15.transform.localScale;
                _obj.transform.localScale = originScale;

                spawnPos = new Vector2(posList[index].x, posList[index].y);

                _obj.transform.position = spawnPos;
                index++;
                level.counter.text = "Level " + (index + 1).ToString();
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
        
        Vector2 _objPos;

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
            case 0:
                randPosX = Random.Range(-9.2f, 7.6f);
                randPosY = Random.Range(-4.4f, 4.6f);
                comPosX = randPosX + 0.6f;
                comPosY = randPosY - 0.52f;
                break;
            case 1:
                randPosX = Random.Range(-9.2f, 7.3f);
                randPosY = Random.Range(-4.1f, 4.6f);
                comPosX = randPosX + 1.0f;
                comPosY = randPosY - 0.9f;
                break;
            case 2:
                randPosX = Random.Range(-9.2f, 6.8f);
                randPosY = Random.Range(-3.8f, 4.6f);
                comPosX = randPosX + 1.4f;
                comPosY = randPosY - 1.3f;
                break;
            case 3:
                randPosX = Random.Range(-9.2f, 6.3f);
                randPosY = Random.Range(-3.3f, 4.6f);
                comPosX = randPosX + 1.9f;
                comPosY = randPosY - 1.8f;
                break;
            case 4:
                randPosX = Random.Range(-9.2f, 5.4f);
                randPosY = Random.Range(-2.5f, 4.6f);
                comPosX = randPosX + 2.7f;
                comPosY = randPosY - 2.5f;
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
                            randPosX = Random.Range(-9.2f, 7.6f);
                            randPosY = Random.Range(-4.4f, 4.6f);
                            comPosX = randPosX + 0.6f;
                            comPosY = randPosY - 0.52f;
                            overraped = false;
                        }
                        break;
                    case 1:
                        if (overraped)
                        {
                            randPosX = Random.Range(-9.2f, 7.3f);
                            randPosY = Random.Range(-4.1f, 4.6f);
                            comPosX = randPosX + 1.0f;
                            comPosY = randPosY - 0.9f;
                            overraped = false;
                        }
                        break;
                    case 2:
                        if (overraped)
                        {
                            randPosX = Random.Range(-9.2f, 6.8f);
                            randPosY = Random.Range(-3.8f, 4.6f);
                            comPosX = randPosX + 1.4f;
                            comPosY = randPosY - 1.3f;
                            overraped = false;
                        }
                        break;
                    case 3:
                        if (overraped)
                        {
                            randPosX = Random.Range(-9.2f, 6.3f);
                            randPosY = Random.Range(-3.3f, 4.6f);
                            comPosX = randPosX + 1.9f;
                            comPosY = randPosY - 1.8f;
                            overraped = false;
                        }
                        break;
                    case 4:
                        if (overraped)
                        {
                            randPosX = Random.Range(-9.2f, 5.4f);
                            randPosY = Random.Range(-2.5f, 4.6f);
                            comPosX = randPosX + 2.7f;
                            comPosY = randPosY - 2.5f;
                            overraped = false;
                        }
                        break;
                }              

                for (int i2 = 0; i2 < posList.Count; i2++)
                {
                                        
                    switch (objType[i2])
                    {
                        case 0:
                            oriPosX = posList[i2].x + 0.6f;
                            oriPosY = posList[i2].y - 0.52f;
                            break;
                        case 1:
                            oriPosX = posList[i2].x + 1.0f;
                            oriPosY = posList[i2].y - 0.9f;
                            break;
                        case 2:
                            oriPosX = posList[i2].x + 1.4f;
                            oriPosY = posList[i2].y - 1.3f;
                            break;
                        case 3:
                            oriPosX = posList[i2].x + 1.9f;
                            oriPosY = posList[i2].y - 1.8f;
                            break;
                        case 4:
                            oriPosX = posList[i2].x + 2.7f;
                            oriPosY = posList[i2].y - 2.5f;
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
        level = FindObjectOfType<LevelCounter>();
        level.counter.text = "Level " + (index + 1).ToString();
        while (!allThingsDone)
        {
            PosSearch();
        }
        // SpawnObj();
        //Invoke("SpawnObj", 1.0f);
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
