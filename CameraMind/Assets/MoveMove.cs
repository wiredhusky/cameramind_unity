using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveMove : MonoBehaviour {
    
    public SpawnPrefab spawner;
    
    public List<Vector3> OppCenterPos = new List<Vector3>();
    
    public bool _move = false;
    public bool reverse = true;
    
    float speed, currentTime, lerpTime=1.5f;
        
	// Use this for initialization
	void Start () {

        _move = false;
        reverse = true;
        spawner = FindObjectOfType<SpawnPrefab>();

	}

    
    public void centerPosCalculator()
    {
        
        Vector3 temp;
        //float distanceTemp;
        temp.x = 0f;
        temp.y = 0f;
        temp.z = 0f;
        
                        
        for(int i=0; i < spawner.posList.Count; i++)
        {
            
            switch (spawner.objType[i])
            {
                case 0:
                    temp.x = spawner.posList[i].x * -1.0f - spawner.onScreenScale_20.x;
                    temp.y = spawner.posList[i].y;                    
                    /*distanceTemp = Vector3.Distance(spawner.posList[i], temp);

                    if(spawner.posList[i].x > 0f)
                    {
                        distance_counter.Add(distanceTemp);
                        distanceTemp = distanceTemp * -1.0f;
                        distance.Add(distanceTemp);
                    }
                    else
                    {
                        distance.Add(distanceTemp);
                        distanceTemp = distanceTemp * -1.0f;
                        distance_counter.Add(distanceTemp);
                    }*/
                    
                    OppCenterPos.Add(temp);
                    /*
                    Debug.Log(spawner.posList[i].x);
                    Debug.Log(temp.x);
                    Debug.Log(temp.y);*/
                    //Debug.Log(centerPos[i]);
                    //Debug.Log(OppCenterPos[i]);
                    break;
                case 1:
                    temp.x = spawner.posList[i].x * -1.0f - spawner.onScreenScale_25.x;
                    temp.y = spawner.posList[i].y;
                    /*distanceTemp = Vector3.Distance(spawner.posList[i], temp);
                    if (spawner.posList[i].x > 0f)
                    {
                        distance_counter.Add(distanceTemp);
                        distanceTemp = distanceTemp * -1.0f;
                        distance.Add(distanceTemp);
                    }
                    else
                    {
                        distance.Add(distanceTemp);
                        distanceTemp = distanceTemp * -1.0f;
                        distance_counter.Add(distanceTemp);
                    }
                    //Debug.Log(tempX);
                    /*
                    Debug.Log(spawner.posList[i].x);
                    Debug.Log(temp.x);
                    Debug.Log(temp.y);*/
                    OppCenterPos.Add(temp);
                    //Debug.Log(centerPos[i]);
                    //Debug.Log(OppCenterPos[i]);
                    break;
                case 2:
                    temp.x = spawner.posList[i].x * -1.0f - spawner.onScreenScale_30.x;
                    temp.y = spawner.posList[i].y;
                    /*distanceTemp = Vector3.Distance(spawner.posList[i], temp);
                    if (spawner.posList[i].x > 0f)
                    {
                        distance_counter.Add(distanceTemp);
                        distanceTemp = distanceTemp * -1.0f;
                        distance.Add(distanceTemp);
                    }
                    else
                    {
                        distance.Add(distanceTemp);
                        distanceTemp = distanceTemp * -1.0f;
                        distance_counter.Add(distanceTemp);
                    }*/
                    //Debug.Log(tempX);
                    /*
                    Debug.Log(spawner.posList[i].x);
                    Debug.Log(temp.x);
                    Debug.Log(temp.y);*/
                    OppCenterPos.Add(temp);
                    //Debug.Log(centerPos[i]);
                    //Debug.Log(OppCenterPos[i]);
                    break;
                case 3:
                    temp.x = spawner.posList[i].x * -1.0f - spawner.onScreenScale_35.x;
                    temp.y = spawner.posList[i].y;
                    /*distanceTemp = Vector3.Distance(spawner.posList[i], temp);
                    if (spawner.posList[i].x > 0f)
                    {
                        distance_counter.Add(distanceTemp);
                        distanceTemp = distanceTemp * -1.0f;
                        distance.Add(distanceTemp);
                    }
                    else
                    {
                        distance.Add(distanceTemp);
                        distanceTemp = distanceTemp * -1.0f;
                        distance_counter.Add(distanceTemp);
                    }*/
                    //Debug.Log(tempX);
                    /*
                    Debug.Log(spawner.posList[i].x);
                    Debug.Log(temp.x);
                    Debug.Log(temp.y);*/
                    OppCenterPos.Add(temp);
                    //Debug.Log(centerPos[i]);
                    //Debug.Log(OppCenterPos[i]);
                    break;
                case 4:
                    temp.x = spawner.posList[i].x * -1.0f - spawner.onScreenScale_40.x;
                    temp.y = spawner.posList[i].y;
                    /*distanceTemp = Vector3.Distance(spawner.posList[i], temp);
                    if (spawner.posList[i].x > 0f)
                    {
                        distance_counter.Add(distanceTemp);
                        distanceTemp = distanceTemp * -1.0f;
                        distance.Add(distanceTemp);
                    }
                    else
                    {
                        distance.Add(distanceTemp);
                        distanceTemp = distanceTemp * -1.0f;
                        distance_counter.Add(distanceTemp);
                    }*/
                    /*
                    Debug.Log(spawner.posList[i].x);
                    Debug.Log(temp.x);
                    Debug.Log(temp.y);*/
                    //Debug.Log(tempX);
                    OppCenterPos.Add(temp);
                    //Debug.Log(centerPos[i]);
                    //Debug.Log(OppCenterPos[i]);
                    break;
            }
            
        }
    }

    /*
    public void objTranslate()
    {  
        _move = true;                
    }*/

    public void TempMove()
    {
        currentTime += Time.deltaTime;
        speed = currentTime / lerpTime;
        speed = Mathf.Sin(speed * Mathf.PI * 0.33f);
        
        if (reverse)
        {
            for (int i = 0; i <= spawner.index; i++)
            {   
                spawner.obj[i].transform.position = Vector3.Lerp(spawner.obj[i].transform.position, OppCenterPos[i], speed);
                
                if (spawner.obj[spawner.index].transform.position == OppCenterPos[spawner.index])
                {   
                    _move = false;
                    reverse = false;
                    spawner.obj[spawner.index].GetComponent<PolygonCollider2D>().enabled = true;
                    currentTime = 0;
                }
            }
        }
        else
        {
            for (int i = 0; i <= spawner.index; i++)
            {
                spawner.obj[i].transform.position = Vector3.Lerp(spawner.obj[i].transform.position, spawner.posList[i], speed);
                
                if (spawner.obj[spawner.index].transform.position == spawner.posList[spawner.index])
                {   
                    _move = false;
                    reverse = true;
                    spawner.obj[spawner.index].GetComponent<PolygonCollider2D>().enabled = true;
                    currentTime = 0;
                }
            }
        }
    }

    private void Update()
    {   
        if(_move)
        {
            TempMove();
        }
    }
}
