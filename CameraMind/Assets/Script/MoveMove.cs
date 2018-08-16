using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveMove : MonoBehaviour {
    
    //public SpawnPrefab spawner;
    public TransitionControl colControl;
    
    public List<Vector3> OppCenterPos = new List<Vector3>();
    
    public bool _move = false;
    public bool reverse = true;
    
    float speed, currentTime, lerpTime=1.5f;
        
	// Use this for initialization
	void Start () {

        _move = false;
        reverse = true;        
        //SpawnPrefab.instance = GameObject.FindWithTag("SpawnPrefab.instance").GetComponent<SpawnPrefab>();
        colControl = GameObject.FindWithTag("transitionControl").GetComponent<TransitionControl>();

	}
    
    public void centerPosCalculator()
    {   
        Vector3 temp;
        //float distanceTemp;
        temp.z = 0;

        switch(SpawnPrefab.instance.scene){
            case "Flip Vertical":
                for (int i = 0; i < SpawnPrefab.instance.posList.Count; i++)
                {
                    temp.x = SpawnPrefab.instance.posList[i].x;
                    temp.y = SpawnPrefab.instance.posList[i].y * -1.0f;
                    OppCenterPos.Add(temp);
                }
                break;
            default:
                for (int i = 0; i < SpawnPrefab.instance.posList.Count; i++)
                {
                    temp.x = SpawnPrefab.instance.posList[i].x * -1.0f;
                    temp.y = SpawnPrefab.instance.posList[i].y;
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
            for (int i = 0; i <= SpawnPrefab.instance.index; i++)
            {   
                SpawnPrefab.instance.obj[i].transform.position = Vector3.Lerp(SpawnPrefab.instance.obj[i].transform.position, OppCenterPos[i], speed);
                
                if (SpawnPrefab.instance.obj[SpawnPrefab.instance.index].transform.position == OppCenterPos[SpawnPrefab.instance.index])
                {   
                    _move = false;
                    reverse = false;
                    //SpawnPrefab.instance.obj[SpawnPrefab.instance.index].GetComponent<PolygonCollider2D>().enabled = true;
                    colControl.ActiveHandler();
                    currentTime = 0;
                }
            }
        }
        else
        {
            for (int i = 0; i <= SpawnPrefab.instance.index; i++)
            {
                SpawnPrefab.instance.obj[i].transform.position = Vector3.Lerp(SpawnPrefab.instance.obj[i].transform.position, SpawnPrefab.instance.posList[i], speed);
                
                if (SpawnPrefab.instance.obj[SpawnPrefab.instance.index].transform.position == SpawnPrefab.instance.posList[SpawnPrefab.instance.index])
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
