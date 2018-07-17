﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpawnPrefab : MonoBehaviour {
    
    public GameObject soomong_15;
    public GameObject soomong_colored;
    public List<Vector3> posList = new List<Vector3>();
    public List<int> objType = new List<int>();
    public List<GameObject> obj = new List<GameObject>();
    //public LevelCounter level;
    public GameObject levelTransition;

    private MoveMove move;
    //Animator animator;

    float margin = 0.2f;

    public int scene;
    public int index_track = 0;
    public int index_twins = 0;
    public int index_alone = 50;

    public bool colored = true;

    float limitTop, limitBottom, limitLeft, limitRight;

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

    public Vector2 onScreenScale_20;
    public Vector2 onScreenScale_25;
    public Vector2 onScreenScale_30;
    public Vector2 onScreenScale_35;
    public Vector2 onScreenScale_40;

    //objects' boundaries
    /*
    Vector2 xLimit_20;
    Vector2 yLimit_20;
    Vector2 xLimit_25;
    Vector2 yLimit_25;
    Vector2 xLimit_30;
    Vector2 yLimit_30;
    Vector2 xLimit_35;
    Vector2 yLimit_35;
    Vector2 xLimit_40;
    Vector2 yLimit_40;
    */

    Vector3 worldPos;

    private void Start()
    {
        GameObject _obj;

        scene = SceneManager.GetActiveScene().buildIndex;

        setScale();

        while (!allThingsDone)
        {
            PosSearch();
        }

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
                for (int i = 0; i < 50; i++)
                {
                    switch (objType[i])
                    {
                        case 0:
                            _obj = Instantiate(soomong_colored) as GameObject;
                            _obj.GetComponent<Renderer>().enabled = false;
                            _obj.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
                            _obj.transform.position = posList[i];
                            break;
                        case 1:
                            _obj = Instantiate(soomong_colored) as GameObject;
                            _obj.GetComponent<Renderer>().enabled = false;
                            _obj.transform.localScale = new Vector3(0.25f, 0.25f, 0.25f);
                            _obj.transform.position = posList[i];
                            break;
                        case 2:
                            _obj = Instantiate(soomong_colored) as GameObject;
                            _obj.GetComponent<Renderer>().enabled = false;
                            _obj.transform.localScale = new Vector3(0.3f, 0.3f, 0.3f);
                            _obj.transform.position = posList[i];
                            break;
                        case 3:
                            _obj = Instantiate(soomong_colored) as GameObject;
                            _obj.GetComponent<Renderer>().enabled = false;
                            _obj.transform.localScale = new Vector3(0.35f, 0.35f, 0.35f);
                            _obj.transform.position = posList[i];
                            break;
                        case 4:
                            _obj = Instantiate(soomong_colored) as GameObject;
                            _obj.GetComponent<Renderer>().enabled = false;
                            _obj.transform.localScale = new Vector3(0.4f, 0.4f, 0.4f);
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
                            _obj.transform.localScale = new Vector3(0.3f, 0.3f, 0.3f);
                            _obj.transform.position = posList[i];                            
                            break;
                        case 3:
                            _obj = Instantiate(soomong_colored) as GameObject;
                            _obj.GetComponent<Renderer>().enabled = false;
                            _obj.transform.localScale = new Vector3(0.35f, 0.35f, 0.35f);
                            _obj.transform.position = posList[i];                            
                            break;
                        case 4:
                            _obj = Instantiate(soomong_colored) as GameObject;
                            _obj.GetComponent<Renderer>().enabled = false;
                            _obj.transform.localScale = new Vector3(0.4f, 0.4f, 0.4f);
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
                break;
                //double, triple, mix
        }
        levelTransition.SetActive(true);
                
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
        Debug.Log("15: " + case0);
        Debug.Log("20: " + case1);
        Debug.Log("25: " + case2);
        Debug.Log("30: " + case3);
        Debug.Log("40: " + case4);
    }

    public void SpawnObj()
    {
        GameObject _obj;
        //Vector2 spawnPos;
        
        switch (objType[index])
        {
            case 0:
                _obj = Instantiate(soomong_15) as GameObject;                
                _obj.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
                //spawnPos = new Vector2(posList[index].x, posList[index].y);
                //_obj.transform.position = spawnPos;
                _obj.transform.position = posList[index];
                //_obj.GetComponent<PolygonCollider2D>().enabled = true;                             
                obj.Add(_obj);
                
                break;
            case 1:                
                _obj = Instantiate(soomong_15) as GameObject;
                
                _obj.transform.localScale = new Vector3(0.25f, 0.25f, 0.25f);
                //spawnPos = new Vector2(posList[index].x, posList[index].y);
                //_obj.transform.position = spawnPos;
                _obj.transform.position = posList[index];
                //_obj.GetComponent<PolygonCollider2D>().enabled = true;
                obj.Add(_obj);
                
                break;
            case 2:
                _obj = Instantiate(soomong_15) as GameObject;
                
                _obj.transform.localScale = new Vector3(0.3f, 0.3f, 0.3f);
                //spawnPos = new Vector2(posList[index].x, posList[index].y);
                //_obj.transform.position = spawnPos;
                //_obj.GetComponent<PolygonCollider2D>().enabled = true;
                _obj.transform.position = posList[index];
                obj.Add(_obj);
                
                break;
            case 3:
                _obj = Instantiate(soomong_15) as GameObject;
                
                _obj.transform.localScale = new Vector3(0.35f, 0.35f, 0.35f);
                //spawnPos = new Vector2(posList[index].x, posList[index].y);
                //_obj.transform.position = spawnPos;
                _obj.transform.position = posList[index];
                //_obj.GetComponent<PolygonCollider2D>().enabled = true;
                obj.Add(_obj);
                
                break;
            case 4:
                _obj = Instantiate(soomong_15) as GameObject;
                
                _obj.transform.localScale = new Vector3(0.4f, 0.4f, 0.4f);
                //spawnPos = new Vector2(posList[index].x, posList[index].y);
                //_obj.transform.position = spawnPos;
                _obj.transform.position = posList[index];
                //_obj.GetComponent<PolygonCollider2D>().enabled = true;
                obj.Add(_obj);
                
                break;
        }
    }

    public void SpawnObj_Alone()
    {
        GameObject _obj;
        //Vector2 spawnPos;        
        
        switch (objType[index_alone])
        {
            case 0:
                _obj = Instantiate(soomong_15) as GameObject;
                _obj.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
                //spawnPos = new Vector2(posList[index].x, posList[index].y);
                //_obj.transform.position = spawnPos;
                _obj.transform.position = posList[index_alone];
                //_obj.GetComponent<PolygonCollider2D>().enabled = true;                             
                obj.Add(_obj);
                break;
            case 1:
                _obj = Instantiate(soomong_15) as GameObject;

                _obj.transform.localScale = new Vector3(0.25f, 0.25f, 0.25f);
                //spawnPos = new Vector2(posList[index].x, posList[index].y);
                //_obj.transform.position = spawnPos;
                _obj.transform.position = posList[index_alone];
                //_obj.GetComponent<PolygonCollider2D>().enabled = true;
                obj.Add(_obj);
                break;
            case 2:
                _obj = Instantiate(soomong_15) as GameObject;

                _obj.transform.localScale = new Vector3(0.3f, 0.3f, 0.3f);
                //spawnPos = new Vector2(posList[index].x, posList[index].y);
                //_obj.transform.position = spawnPos;
                //_obj.GetComponent<PolygonCollider2D>().enabled = true;
                _obj.transform.position = posList[index_alone];
                obj.Add(_obj);

                break;
            case 3:
                _obj = Instantiate(soomong_15) as GameObject;

                _obj.transform.localScale = new Vector3(0.35f, 0.35f, 0.35f);
                //spawnPos = new Vector2(posList[index].x, posList[index].y);
                //_obj.transform.position = spawnPos;
                _obj.transform.position = posList[index_alone];
                //_obj.GetComponent<PolygonCollider2D>().enabled = true;
                obj.Add(_obj);

                break;
            case 4:
                _obj = Instantiate(soomong_15) as GameObject;

                _obj.transform.localScale = new Vector3(0.4f, 0.4f, 0.4f);
                //spawnPos = new Vector2(posList[index].x, posList[index].y);
                //_obj.transform.position = spawnPos;
                _obj.transform.position = posList[index_alone];
                //_obj.GetComponent<PolygonCollider2D>().enabled = true;
                obj.Add(_obj);

                break;
        }        
    }

    public void SpawnObj_Flip()
    {
        GameObject _obj;
        Vector2 spawnPos;

        switch (objType[index])
        {
            case 0:
                _obj = Instantiate(soomong_15) as GameObject;
                _obj.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);

                if (move.reverse)
                {
                    spawnPos = new Vector2(posList[index].x, posList[index].y);
                    _obj.transform.position = spawnPos;                    
                }
                else
                {
                    spawnPos = new Vector2(move.OppCenterPos[index].x, move.OppCenterPos[index].y);
                    _obj.transform.position = spawnPos;
                }
                obj.Add(_obj);
                break;
            case 1:
                _obj = Instantiate(soomong_15) as GameObject;
                _obj.transform.localScale = new Vector3(0.25f, 0.25f, 0.25f);

                if (move.reverse)
                {
                    spawnPos = new Vector2(posList[index].x, posList[index].y);
                    _obj.transform.position = spawnPos;                    
                }
                else
                {
                    spawnPos = new Vector2(move.OppCenterPos[index].x, move.OppCenterPos[index].y);
                    _obj.transform.position = spawnPos;
                }
                obj.Add(_obj);
                break;
            case 2:
                _obj = Instantiate(soomong_15) as GameObject;
                _obj.transform.localScale = new Vector3(0.3f, 0.3f, 0.3f);
                if (move.reverse)
                {
                    spawnPos = new Vector2(posList[index].x, posList[index].y);
                    _obj.transform.position = spawnPos;                    
                }
                else
                {
                    spawnPos = new Vector2(move.OppCenterPos[index].x, move.OppCenterPos[index].y);
                    _obj.transform.position = spawnPos;
                }
                obj.Add(_obj);
                break;
            case 3:
                _obj = Instantiate(soomong_15) as GameObject;
                _obj.transform.localScale = new Vector3(0.35f, 0.35f, 0.35f);
                if (move.reverse)
                {
                    spawnPos = new Vector2(posList[index].x, posList[index].y);
                    _obj.transform.position = spawnPos;                    
                }
                else
                {
                    spawnPos = new Vector2(move.OppCenterPos[index].x, move.OppCenterPos[index].y);
                    _obj.transform.position = spawnPos;
                }
                obj.Add(_obj);
                break;
            case 4:
                _obj = Instantiate(soomong_15) as GameObject;
                _obj.transform.localScale = new Vector3(0.4f, 0.4f, 0.4f);
                if (move.reverse)
                {
                    spawnPos = new Vector2(posList[index].x, posList[index].y);
                    _obj.transform.position = spawnPos;
                }
                else
                {
                    spawnPos = new Vector2(move.OppCenterPos[index].x, move.OppCenterPos[index].y);
                    _obj.transform.position = spawnPos;
                }
                obj.Add(_obj);
                break;
        }
        
    }

    public void SpawnObj_Twins()
    {
        GameObject _obj;

        switch (objType[index_twins])
        {
            case 0:
                _obj = Instantiate(soomong_colored) as GameObject;
                _obj.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);                
                _obj.transform.position = posList[index_twins];
                
                obj.Add(_obj);                
                break;
            case 1:
                _obj = Instantiate(soomong_colored) as GameObject;
                _obj.transform.localScale = new Vector3(0.25f, 0.25f, 0.25f);
                _obj.transform.position = posList[index_twins];

                obj.Add(_obj);
                break;
            case 2:
                _obj = Instantiate(soomong_colored) as GameObject;
                _obj.transform.localScale = new Vector3(0.3f, 0.3f, 0.3f);
                _obj.transform.position = posList[index_twins];

                obj.Add(_obj);
                break;
            case 3:
                _obj = Instantiate(soomong_colored) as GameObject;
                _obj.transform.localScale = new Vector3(0.35f, 0.35f, 0.35f);
                _obj.transform.position = posList[index_twins];

                obj.Add(_obj);
                break;
            case 4:
                _obj = Instantiate(soomong_colored) as GameObject;
                _obj.transform.localScale = new Vector3(0.4f, 0.4f, 0.4f);
                _obj.transform.position = posList[index_twins];

                obj.Add(_obj);
                break;
        }

        switch (objType[index_twins+1])
        {
            case 0:
                _obj = Instantiate(soomong_15) as GameObject;
                _obj.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
                _obj.transform.position = posList[index_twins+1];

                obj.Add(_obj);
                break;
            case 1:
                _obj = Instantiate(soomong_15) as GameObject;
                _obj.transform.localScale = new Vector3(0.25f, 0.25f, 0.25f);
                _obj.transform.position = posList[index_twins+1];

                obj.Add(_obj);
                break;
            case 2:
                _obj = Instantiate(soomong_15) as GameObject;
                _obj.transform.localScale = new Vector3(0.3f, 0.3f, 0.3f);
                _obj.transform.position = posList[index_twins+1];

                obj.Add(_obj);
                break;
            case 3:
                _obj = Instantiate(soomong_15) as GameObject;
                _obj.transform.localScale = new Vector3(0.35f, 0.35f, 0.35f);
                _obj.transform.position = posList[index_twins+1];

                obj.Add(_obj);
                break;
            case 4:
                _obj = Instantiate(soomong_15) as GameObject;
                _obj.transform.localScale = new Vector3(0.4f, 0.4f, 0.4f);
                _obj.transform.position = posList[index_twins+1];

                obj.Add(_obj);
                break;
        }
    }

    public void PosSearch()
    {
        bool isSearched = false;
        float randPosX = 0f;
        float randPosY = 0f;

        float distance;

        Vector2 preTriangle = new Vector2(0, 0);
        Vector2 newTriangle = new Vector2(0, 0);
        Vector2 triangleSquare = new Vector2(0, 0);
        Vector2 posListTemp;

        /*
        Vector2 newPosLeftTop = new Vector2(0, 0);
        Vector2 newPosRightBottom = new Vector2(0, 0);
        Vector2 prePosLeftTop = new Vector2(0, 0);
        Vector2 prePosRightBottom = new Vector2(0, 0);
        */

        bool overraped = false;
        int randObj=4;
        
        Vector2 _objPos = new Vector2(0, 0);

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
                randPosX = Random.Range(limitLeft + onScreenScale_20.x * 0.5f, limitRight - onScreenScale_20.x * 0.5f);
                randPosY = Random.Range(limitTop - onScreenScale_20.y * 0.5f, limitBottom + onScreenScale_20.y * 0.5f);
                _objPos = new Vector2(randPosX, randPosY);
                newTriangle.x = onScreenScale_20.x * 0.5f;
                newTriangle.y = onScreenScale_20.y * 0.5f;
                break;
            case 1: //soomong 25
                randPosX = Random.Range(limitLeft + onScreenScale_25.x * 0.5f, limitRight - onScreenScale_25.x * 0.5f);
                randPosY = Random.Range(limitTop - onScreenScale_25.y * 0.5f, limitBottom + onScreenScale_25.y * 0.5f);
                _objPos = new Vector2(randPosX, randPosY);
                newTriangle.x = onScreenScale_25.x * 0.5f;
                newTriangle.y = onScreenScale_25.y * 0.5f;
                /*
                newPosLeftTop.x = randPosX - onScreenScale_25.x * 0.5f;
                newPosLeftTop.y = randPosY + onScreenScale_25.y * 0.5f;
                newPosRightBottom.x = randPosX + onScreenScale_25.x * 0.5f;
                newPosRightBottom.y = randPosY - onScreenScale_25.y * 0.5f;
                */
                break;
            case 2: //soomong 30
                randPosX = Random.Range(limitLeft + onScreenScale_30.x * 0.5f, limitRight - onScreenScale_30.x * 0.5f);
                randPosY = Random.Range(limitTop - onScreenScale_30.y * 0.5f, limitBottom + onScreenScale_30.y * 0.5f);
                _objPos = new Vector2(randPosX, randPosY);
                newTriangle.x = onScreenScale_30.x * 0.5f;
                newTriangle.y = onScreenScale_30.y * 0.5f;
                /*
                newPosLeftTop.x = randPosX - onScreenScale_30.x * 0.5f;
                newPosLeftTop.y = randPosY + onScreenScale_30.y * 0.5f;
                newPosRightBottom.x = randPosX + onScreenScale_30.x * 0.5f;
                newPosRightBottom.y = randPosY - onScreenScale_30.y * 0.5f;
                */
                break;
            case 3: //soomong 35
                randPosX = Random.Range(limitLeft + onScreenScale_35.x * 0.5f, limitRight - onScreenScale_35.x * 0.5f);
                randPosY = Random.Range(limitTop - onScreenScale_35.y * 0.5f, limitBottom + onScreenScale_35.y * 0.5f);
                _objPos = new Vector2(randPosX, randPosY);
                newTriangle.x = onScreenScale_35.x * 0.5f;
                newTriangle.y = onScreenScale_35.y * 0.5f;
                /*
                newPosLeftTop.x = randPosX - onScreenScale_35.x * 0.5f;
                newPosLeftTop.y = randPosY + onScreenScale_35.y * 0.5f;
                newPosRightBottom.x = randPosX + onScreenScale_35.x * 0.5f;
                newPosRightBottom.y = randPosY - onScreenScale_35.y * 0.5f;
                */
                break;
            case 4: //soomong 40
                randPosX = Random.Range(limitLeft + onScreenScale_40.x * 0.5f, limitRight - onScreenScale_40.x * 0.5f);
                randPosY = Random.Range(limitTop - onScreenScale_40.y * 0.5f, limitBottom + onScreenScale_40.y * 0.5f);
                _objPos = new Vector2(randPosX, randPosY);
                newTriangle.x = onScreenScale_40.x * 0.5f;
                newTriangle.y = onScreenScale_40.y * 0.5f;
                /*
                newPosLeftTop.x = randPosX - onScreenScale_40.x * 0.5f;
                newPosLeftTop.y = randPosY + onScreenScale_40.y * 0.5f;
                newPosRightBottom.x = randPosX + onScreenScale_40.x * 0.5f;
                newPosRightBottom.y = randPosY - onScreenScale_40.y * 0.5f;
                */
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
            for(int i = 0; i<300; i++)
            {
                switch (randObj)
                {
                    case 0:
                        if (overraped)
                        {
                            randPosX = Random.Range(limitLeft + onScreenScale_20.x * 0.5f, limitRight - onScreenScale_20.x * 0.5f);
                            randPosY = Random.Range(limitTop - onScreenScale_20.y * 0.5f, limitBottom + onScreenScale_20.y * 0.5f);
                            _objPos = new Vector2(randPosX, randPosY);
                            newTriangle.x = onScreenScale_20.x * 0.5f;
                            newTriangle.y = onScreenScale_20.y * 0.5f;
                            /*
                            newPosLeftTop.x = randPosX - onScreenScale_20.x * 0.5f;
                            newPosLeftTop.y = randPosY + onScreenScale_20.y * 0.5f;
                            newPosRightBottom.x = randPosX + onScreenScale_20.x * 0.5f;
                            newPosRightBottom.y = randPosY - onScreenScale_20.y * 0.5f;
                            */
                            overraped = false;
                        }
                        break;
                    case 1:
                        if (overraped)
                        {
                            randPosX = Random.Range(limitLeft + onScreenScale_25.x * 0.5f, limitRight - onScreenScale_25.x * 0.5f);
                            randPosY = Random.Range(limitTop - onScreenScale_25.y * 0.5f, limitBottom + onScreenScale_25.y * 0.5f);
                            _objPos = new Vector2(randPosX, randPosY);
                            newTriangle.x = onScreenScale_25.x * 0.5f;
                            newTriangle.y = onScreenScale_25.y * 0.5f;
                            /*
                            newPosLeftTop.x = randPosX - onScreenScale_25.x * 0.5f;
                            newPosLeftTop.y = randPosY + onScreenScale_25.y * 0.5f;
                            newPosRightBottom.x = randPosX + onScreenScale_25.x * 0.5f;
                            newPosRightBottom.y = randPosY - onScreenScale_25.y * 0.5f;
                            */
                            overraped = false;
                        }
                        break;
                    case 2:
                        if (overraped)
                        {
                            randPosX = Random.Range(limitLeft + onScreenScale_30.x * 0.5f, limitRight - onScreenScale_30.x * 0.5f);
                            randPosY = Random.Range(limitTop - onScreenScale_30.y * 0.5f, limitBottom + onScreenScale_30.y * 0.5f);
                            _objPos = new Vector2(randPosX, randPosY);
                            newTriangle.x = onScreenScale_30.x * 0.5f;
                            newTriangle.y = onScreenScale_30.y * 0.5f;
                            /*
                            newPosLeftTop.x = randPosX - onScreenScale_30.x * 0.5f;
                            newPosLeftTop.y = randPosY + onScreenScale_30.y * 0.5f;
                            newPosRightBottom.x = randPosX + onScreenScale_30.x * 0.5f;
                            newPosRightBottom.y = randPosY - onScreenScale_30.y * 0.5f;
                            */
                        }
                        break;
                    case 3:
                        if (overraped)
                        {
                            randPosX = Random.Range(limitLeft + onScreenScale_35.x * 0.5f, limitRight - onScreenScale_35.x * 0.5f);
                            randPosY = Random.Range(limitTop - onScreenScale_35.y * 0.5f, limitBottom + onScreenScale_35.y * 0.5f);
                            _objPos = new Vector2(randPosX, randPosY);
                            newTriangle.x = onScreenScale_35.x * 0.5f;
                            newTriangle.y = onScreenScale_35.y * 0.5f;
                            /*
                            newPosLeftTop.x = randPosX - onScreenScale_35.x * 0.5f;
                            newPosLeftTop.y = randPosY + onScreenScale_35.y * 0.5f;
                            newPosRightBottom.x = randPosX + onScreenScale_35.x * 0.5f;
                            newPosRightBottom.y = randPosY - onScreenScale_35.y * 0.5f;
                            */
                            overraped = false;
                        }
                        break;
                    case 4:
                        if (overraped)
                        {
                            randPosX = Random.Range(limitLeft + onScreenScale_40.x * 0.5f, limitRight - onScreenScale_40.x * 0.5f);
                            randPosY = Random.Range(limitTop - onScreenScale_40.y * 0.5f, limitBottom + onScreenScale_40.y * 0.5f);
                            _objPos = new Vector2(randPosX, randPosY);
                            newTriangle.x = onScreenScale_40.x * 0.5f;
                            newTriangle.y = onScreenScale_40.y * 0.5f;
                            /*
                            newPosLeftTop.x = randPosX - onScreenScale_40.x * 0.5f;
                            newPosLeftTop.y = randPosY + onScreenScale_40.y * 0.5f;
                            newPosRightBottom.x = randPosX + onScreenScale_40.x * 0.5f;
                            newPosRightBottom.y = randPosY - onScreenScale_40.y * 0.5f;
                            */
                            overraped = false;
                        }
                        break;
                }              

                for (int i2 = 0; i2 < posList.Count; i2++)
                {                    
                    switch (objType[i2])
                    {
                        case 0:
                            preTriangle.x = onScreenScale_20.x * 0.5f;
                            preTriangle.y = onScreenScale_20.y * 0.5f;
                            /*
                            prePosLeftTop.x = posList[i2].x - onScreenScale_20.x * 0.5f;
                            prePosLeftTop.y = posList[i2].y + onScreenScale_20.y * 0.5f;
                            prePosRightBottom.x = posList[i2].x + onScreenScale_20.x * 0.5f;
                            prePosRightBottom.y = posList[i2].y - onScreenScale_20.y * 0.5f;
                            */
                            break;
                        case 1:
                            preTriangle.x = onScreenScale_25.x * 0.5f;
                            preTriangle.y = onScreenScale_25.y * 0.5f;
                            /*
                            prePosLeftTop.x = posList[i2].x - onScreenScale_25.x * 0.5f;
                            prePosLeftTop.y = posList[i2].y + onScreenScale_25.y * 0.5f;
                            prePosRightBottom.x = posList[i2].x + onScreenScale_25.x * 0.5f;
                            prePosRightBottom.y = posList[i2].y - onScreenScale_25.y * 0.5f;
                            */
                            break;
                        case 2:
                            preTriangle.x = onScreenScale_30.x * 0.5f;
                            preTriangle.y = onScreenScale_30.y * 0.5f;
                            /*
                            prePosLeftTop.x = posList[i2].x - onScreenScale_30.x * 0.5f;
                            prePosLeftTop.y = posList[i2].y + onScreenScale_30.y * 0.5f;
                            prePosRightBottom.x = posList[i2].x + onScreenScale_30.x * 0.5f;
                            prePosRightBottom.y = posList[i2].y - onScreenScale_30.y * 0.5f;
                            */
                            break;
                        case 3:
                            preTriangle.x = onScreenScale_35.x * 0.5f;
                            preTriangle.y = onScreenScale_35.y * 0.5f;
                            /*
                            prePosLeftTop.x = posList[i2].x - onScreenScale_35.x * 0.5f;
                            prePosLeftTop.y = posList[i2].y + onScreenScale_35.y * 0.5f;
                            prePosRightBottom.x = posList[i2].x + onScreenScale_35.x * 0.5f;
                            prePosRightBottom.y = posList[i2].y - onScreenScale_35.y * 0.5f;
                            */
                            break;
                        case 4:
                            preTriangle.x = onScreenScale_40.x * 0.5f;
                            preTriangle.y = onScreenScale_40.y * 0.5f;
                            /*
                            prePosLeftTop.x = posList[i2].x - onScreenScale_40.x * 0.5f;
                            prePosLeftTop.y = posList[i2].y + onScreenScale_40.y * 0.5f;
                            prePosRightBottom.x = posList[i2].x + onScreenScale_40.x * 0.5f;
                            prePosRightBottom.y = posList[i2].y - onScreenScale_40.y * 0.5f;
                            */
                            break;
                    }
                    posListTemp = new Vector2(posList[i2].x, posList[i2].y);
                    distance = Vector2.Distance(posListTemp, _objPos);
                    triangleSquare.x = (preTriangle.x + newTriangle.x) * (preTriangle.x + newTriangle.x);
                    triangleSquare.y = (preTriangle.y + newTriangle.y) * (preTriangle.y + newTriangle.y);

                    if(distance <= triangleSquare.x + triangleSquare.y)
                    {
                        overraped = true;
                    }

                    /*
                    //if the left-top pos of new obj is in the current obj
                    if (newPosLeftTop.x >= prePosLeftTop.x && newPosLeftTop.x <= prePosRightBottom.x && newPosLeftTop.y <= prePosLeftTop.y && newPosLeftTop.y >= prePosRightBottom.y) // left-top
                    {
                        overraped = true;
                        //Debug.Log("Left Top Overraped");
                        break;
                    } 
                    else if (newPosRightBottom.x >= prePosLeftTop.x && newPosRightBottom.x <= prePosRightBottom.x && newPosLeftTop.y <= prePosLeftTop.y && newPosLeftTop.y >= prePosRightBottom.y) // right-top
                    {
                        overraped = true;
                        //Debug.Log("Right Top Overraped");
                        break;
                    }
                    else if (newPosLeftTop.x >= prePosLeftTop.x && newPosLeftTop.x <= prePosRightBottom.x && newPosRightBottom.y <= prePosLeftTop.y && newPosRightBottom.y >= prePosRightBottom.y) // left-bottom
                    {
                        overraped = true;
                        //Debug.Log("left bottom Overraped");
                        break;
                    }
                    else if (newPosRightBottom.x >= prePosLeftTop.x && newPosRightBottom.x <= prePosRightBottom.x && newPosRightBottom.y <= prePosLeftTop.y && newPosRightBottom.y >= prePosRightBottom.y) // right-bottom
                    {
                        overraped = true;
                        //Debug.Log("right bottom Overraped");
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
                    */
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
        
        float localscale_20 = 0.2f;
        float localscale_25 = 0.25f;
        float localscale_30 = 0.3f;
        float localscale_35 = 0.35f;
        float localscale_40 = 0.4f;

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
