using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageChanger : MonoBehaviour {

    public static ImageChanger imageChanger;

    private void Awake()
    {
        if(imageChanger == null)
        {
            imageChanger = this;
        }
    }

    public void ChangeImage()
    {
        gameObject.GetComponent<Image>().sprite = Resources.Load<Sprite>("img/boy");
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
