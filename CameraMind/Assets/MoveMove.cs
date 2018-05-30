using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveMove : MonoBehaviour {

    public SpawnPrefab spawner;
    public List<Vector2> centerPos = new List<Vector2>();
    public List<Vector2> OppCenterPos = new List<Vector2>();

	// Use this for initialization
	void Start () {

        spawner = FindObjectOfType<SpawnPrefab>();
        
        		
	}

    public void centerPosCalculator()
    {
        
        Vector2 temp;
        float tempX;
        float tempY;
                
        for(int i=0; i < spawner.posList.Count; i++)
        {            
            switch (spawner.objType[i])
            {
                case 0:
                    tempX = spawner.obj[i].transform.position.x + (spawner.onScreenScale_20.x / 2);
                    tempY = spawner.obj[i].transform.position.y - (spawner.onScreenScale_20.y / 2);
                    temp.x = tempX;
                    temp.y = tempY;
                    //Debug.Log(tempX);
                    centerPos.Add(temp);
                    temp.x = tempX * -1.0f;
                    OppCenterPos.Add(temp);
                    Debug.Log(centerPos[i]);
                    Debug.Log(OppCenterPos[i]);
                    break;
                case 1:
                    tempX = spawner.obj[i].transform.position.x + (spawner.onScreenScale_25.x / 2);
                    tempY = spawner.obj[i].transform.position.y - (spawner.onScreenScale_25.y / 2);
                    temp.x = tempX;
                    temp.y = tempY;
                    //Debug.Log(tempX);
                    centerPos.Add(temp);
                    temp.x = tempX * -1.0f;
                    OppCenterPos.Add(temp);
                    Debug.Log(centerPos[i]);
                    Debug.Log(OppCenterPos[i]);
                    break;
                case 2:
                    tempX = spawner.obj[i].transform.position.x + (spawner.onScreenScale_30.x / 2);
                    tempY = spawner.obj[i].transform.position.y - (spawner.onScreenScale_30.y / 2);
                    temp.x = tempX;
                    temp.y = tempY;
                    //Debug.Log(tempX);
                    centerPos.Add(temp);
                    temp.x = tempX * -1.0f;
                    OppCenterPos.Add(temp);
                    Debug.Log(centerPos[i]);
                    Debug.Log(OppCenterPos[i]);
                    break;
                case 3:
                    tempX = spawner.obj[i].transform.position.x + (spawner.onScreenScale_35.x / 2);
                    tempY = spawner.obj[i].transform.position.y - (spawner.onScreenScale_35.y / 2);
                    temp.x = tempX;
                    temp.y = tempY;
                    //Debug.Log(tempX);
                    centerPos.Add(temp);
                    temp.x = tempX * -1.0f;
                    OppCenterPos.Add(temp);
                    Debug.Log(centerPos[i]);
                    Debug.Log(OppCenterPos[i]);
                    break;
                case 4:
                    tempX = spawner.obj[i].transform.position.x + (spawner.onScreenScale_40.x / 2);
                    tempY = spawner.obj[i].transform.position.y - (spawner.onScreenScale_40.y / 2);
                    temp.x = tempX;
                    temp.y = tempY;
                    //Debug.Log(tempX);
                    centerPos.Add(temp);
                    temp.x = tempX * -1.0f;
                    OppCenterPos.Add(temp);
                    Debug.Log(centerPos[i]);
                    Debug.Log(OppCenterPos[i]);
                    break;
            }
            
        }
    }

    public void objTranslate()
    {
        float speed = 1f;

        for(int i=0; i<spawner.index; i++)
        {
            spawner.obj[i].transform.Translate(OppCenterPos[i]*speed);
        }
    }
	
	
}
