using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveMove : MonoBehaviour {

    public SpawnPrefab spawner;
    //public List<Vector2> centerPos = new List<Vector2>();
    public List<Vector3> OppCenterPos = new List<Vector3>();
    public List<float> distance = new List<float>();
    public List<float> distance_counter = new List<float>();
    //public Clicked TapController;
    public bool _flip = true;
    bool _move = false;
    public bool reverse = true;
    //Quaternion rotation = Quaternion.identity;
    

	// Use this for initialization
	void Start () {

        _move = false;
        reverse = true;
        spawner = FindObjectOfType<SpawnPrefab>();
        //rotation.eulerAngles = new Vector3(90, 0, 0);
        //TapController = FindObjectOfType<Clicked>();
        //Debug.Log(TapController.a);
        
        		
	}

    public void centerPosCalculator()
    {
        Vector3 temp;
        float distanceTemp;
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
                    distanceTemp = Vector3.Distance(spawner.posList[i], temp);

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
                    }
                    
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
                    distanceTemp = Vector3.Distance(spawner.posList[i], temp);
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
                    distanceTemp = Vector3.Distance(spawner.posList[i], temp);
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
                case 3:
                    temp.x = spawner.posList[i].x * -1.0f - spawner.onScreenScale_35.x;
                    temp.y = spawner.posList[i].y;
                    distanceTemp = Vector3.Distance(spawner.posList[i], temp);
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
                case 4:
                    temp.x = spawner.posList[i].x * -1.0f - spawner.onScreenScale_40.x;
                    temp.y = spawner.posList[i].y;
                    distanceTemp = Vector3.Distance(spawner.posList[i], temp);
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

    public void objTranslate()
    {
        //Debug.Log("GoGo");
        //float speed = 1f;
        //float distance = 0f;       
        _move = true;                
    }

    public void TempMove()
    {
        //float distance = 0f;
        //Quaternion right = Quaternion.identity;

        //right.eulerAngles = new Vector3(270, 0, 0);
        //float speed = 0.2f;

        if (reverse)
        {
            for (int i = 0; i < spawner.index; i++)
            {

                //spawner.obj[i].transform.Translate(new Vector3(distance[i] * Time.deltaTime * 10f, 0, 0));

                spawner.obj[i].transform.position = Vector3.Lerp(spawner.obj[i].transform.position, OppCenterPos[i], Time.deltaTime*7.5f);
                //spawner.obj[i].transform.Rotate(Vector3.up * Time.deltaTime);
                //spawner.obj[i].transform.rotation = Quaternion.Lerp(spawner.obj[i].transform.rotation, rotation, Time.deltaTime * 6.5f);
                //spawner.obj[i].transform.position = Vector3.MoveTowards(spawner.obj[i].transform.position, OppCenterPos[i], (Time.deltaTime + 2.0f) * 6.5f);

                if (spawner.obj[spawner.index - 1].transform.position == OppCenterPos[spawner.index - 1])
                {
                    _move = false;
                    //Debug.Log("Origin Pos: " + OppCenterPos[spawner.index - 1]);
                    reverse = false;
                    //spawner.obj[spawner.index - 1].GetComponent<Clicked>().enabled = true;
                    spawner.obj[spawner.index - 1].GetComponent<PolygonCollider2D>().enabled = true;
                    //Debug.Log(spawner.obj[spawner.index - 1].transform.rotation);
                    //spawner.obj[spawner.index - 1].
                }
            }
            //Debug.Log("Target Pos: " + spawner.obj[spawner.index - 1].transform.position.x);
            //Debug.Log("OppcenterPos: " + OppCenterPos[spawner.index - 1].x);
            //Debug.Log("Pos List: " + spawner.posList[spawner.index - 1]);
            //Debug.Log("Move: " + _move);
        }
        else
        {
            for (int i = 0; i < spawner.index; i++)
            {

                //spawner.obj[i].transform.Translate(new Vector3(distance_counter[i] * Time.deltaTime * 10f, 0, 0));

                spawner.obj[i].transform.position = Vector3.Lerp(spawner.obj[i].transform.position, spawner.posList[i], Time.deltaTime*7.5f);
                //spawner.obj[i].transform.position = Vector3.MoveTowards(spawner.obj[i].transform.position, spawner.posList[i], (Time.deltaTime+2.0f) * 6.5f);

                if (spawner.obj[spawner.index - 1].transform.position == spawner.posList[spawner.index - 1])
                {
                    _move = false;
                    //Debug.Log("Target Pos: " + spawner.obj[spawner.index - 1].transform.position);
                    //Debug.Log("Origin Pos: " + spawner.posList[spawner.index - 1]);
                    reverse = true;
                    //spawner.obj[spawner.index - 1].GetComponent<Clicked>().enabled = true;
                    spawner.obj[spawner.index - 1].GetComponent<PolygonCollider2D>().enabled = true;
                }
            }
            //Debug.Log("Target Pos: " + spawner.obj[spawner.index - 1].transform.position.x);
            //Debug.Log("OppcenterPos: " + OppCenterPos[spawner.index - 1].x);
            //Debug.Log("Pos List: " + spawner.posList[spawner.index - 1]);
            //Debug.Log("Move: " + _move);
        }

    
    }

    private void FixedUpdate()
    {
        
        if (_move)
        {
            TempMove();
            //Debug.Log("Target Pos: " + spawner.obj[spawner.index - 1].transform.position);
        }
        
        //float distance;
        /*if (_move)
        {
            spawner.obj[0].transform.Translate(new Vector3(distance[0]*Time.deltaTime*5f, 0, 0));
            //spawner.obj[0].transform.position = Vector3.MoveTowards(spawner.obj[0].transform.position, OppCenterPos[0], distance[0]*Time.deltaTime*1.0f);
            Debug.Log("Opp Pos x: " + OppCenterPos[0].x);
            Debug.Log("obj postion x: " + spawner.obj[0].transform.position.x);
            Debug.Log("distance: " + distance[0]);
            Debug.Log("distance_counter: " + distance_counter[0]);

            Debug.Log(spawner.posList[0].x);

            if(spawner.obj[0].transform.position.x == OppCenterPos[0].x)
            {
                _move = false;
            }
            
        }*/
    }


}
