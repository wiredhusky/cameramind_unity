using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoomongCollider : MonoBehaviour
{
    public bool isCollision = false;


    private void Start()
    {
        /*float height;
        height = transform.gameObject.GetComponent<RectTransform>().rect.height;
        Debug.Log(height);*/
        
    }


    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.tag == "soomong")
        {
            //Debug.Log("Sooo");
            isCollision = true;            
            //Destroy(col.gameObject);
        }
    }

    private void FixedUpdate()
    {/*
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            transform.Translate(Vector3.right);
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            transform.Translate(Vector3.left);
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            transform.Translate(Vector3.up);
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            transform.Translate(Vector3.down);
        }*/
    }





}
