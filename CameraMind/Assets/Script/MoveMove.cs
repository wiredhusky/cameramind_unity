using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveMove : MonoBehaviour {
    
    public SpawnPrefab spawner;
    public TransitionControl colControl;
    
    public List<Vector3> OppCenterPos = new List<Vector3>();
    
    public bool _move = false;
    public bool reverse = true;
    
    float speed, currentTime, lerpTime=1.5f;
        
	// Use this for initialization
	void Start () {

        _move = false;
        reverse = true;        
        spawner = GameObject.FindWithTag("spawner").GetComponent<SpawnPrefab>();
        colControl = GameObject.FindWithTag("transitionControl").GetComponent<TransitionControl>();

	}
    
    public void centerPosCalculator()
    {   
        Vector3 temp;
        //float distanceTemp;
        temp.z = 0;

        switch (spawner.scene)
        {
            case 2:
                for (int i = 0; i < spawner.posList.Count; i++)
                {
                    temp.x = spawner.posList[i].x * -1.0f;
                    temp.y = spawner.posList[i].y;
                    OppCenterPos.Add(temp);
                }
                break;
            case 7:
                for (int i = 0; i < spawner.posList.Count; i++)
                {
                    temp.x = spawner.posList[i].x;
                    temp.y = spawner.posList[i].y * -1.0f;
                    OppCenterPos.Add(temp);
                }
                break;
        }
    }

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
                    //spawner.obj[spawner.index].GetComponent<PolygonCollider2D>().enabled = true;
                    colControl.ActiveHandler();
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
                    colControl.ActiveHandler();
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
