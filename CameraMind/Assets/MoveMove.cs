using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveMove : MonoBehaviour {

    public SpawnPrefab spawner;
    //public List<Vector2> centerPos = new List<Vector2>();
    public List<Vector3> OppCenterPos = new List<Vector3>();
    bool _move = false;

	// Use this for initialization
	void Start () {

        spawner = FindObjectOfType<SpawnPrefab>();
        
        		
	}

    public void centerPosCalculator()
    {
        Vector3 temp;
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
        float distance = 0f;
        Quaternion right = Quaternion.identity;

        right.eulerAngles = new Vector3(270, 0, 0);
    
        for (int i = 0; i < spawner.index; i++)
        {
            //Debug.Log("Before moving: " + spawner.obj[i].transform.position.x);
            //Debug.Log("Before moving: " + spawner.obj[i].transform.position.z);
            //Vector3.MoveTowards(spawner.obj[i].transform.position, OppCenterPos[i], speed * Time.deltaTime);
            //translate is DISTANCE!!
            //temp2 = spawner.obj[i];
            //temp2.transform.position = Vector3.MoveTowards(temp2.transform.position, OppCenterPos[i], speed);
            //need to define direction
            distance = Vector3.Distance(spawner.obj[i].transform.position, OppCenterPos[i]);
            spawner.obj[i].transform.Translate(new Vector3(distance*Time.deltaTime*10f, 0, 0));
            spawner.obj[i].transform.rotation = Quaternion.Slerp(spawner.obj[i].transform.rotation, right, Time.deltaTime * 10f);

            //spawner.obj[i].transform.position = Vector3.Lerp(spawner.obj[i].transform.position, OppCenterPos[i], distance);

            //Debug.Log("Poslist x: " + spawner.posList[i].x);
            //Debug.Log("Poslist y: " + spawner.posList[i].y);
            Debug.Log("Opp Pos x: " + OppCenterPos[i].x);
            //Debug.Log("Opp Pos y: " + OppCenterPos[i].y);

            Debug.Log("obj postion x: " + spawner.obj[i].transform.position.x);
            //Debug.Log("obj postion y: " + spawner.obj[i].transform.position.y);
        }
        //_move = false;
    }

    private void FixedUpdate()
    {
        if (_move)
        {
            TempMove();
        }
        
        //float distance;
        /*if (_move)
        {
            distance = Vector3.Distance(spawner.obj[0].transform.position, OppCenterPos[0]);
            spawner.obj[0].transform.Translate(new Vector3(distance*Time.deltaTime*10f, 0, 0));
            Debug.Log("Opp Pos x: " + OppCenterPos[0].x);
            Debug.Log("obj postion x: " + spawner.obj[0].transform.position.x);
            if(spawner.obj[0].transform.position == OppCenterPos[0])
            {
                _move = false;
            }
            //_move = false;
        }*/
    }


}
