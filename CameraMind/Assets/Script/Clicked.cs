﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clicked : MonoBehaviour {
    
    TransitionControl transitionType;
    
    public Animator animator;
    public CircleCollider2D _collider;
    public Renderer _renderer;
    
    private void Start()
    {
        transitionType = GameObject.FindWithTag("transitionControl").GetComponent<TransitionControl>();
        
        transitionType.activeCollider += ActiveCol;
        transitionType.deactiveCollider += DeActiveCol;
        transitionType.goIdle += SetIdle;

        switch (SpawnPrefab.instance.scene)
        {            
            case "Track": // Track
                transitionType.goIdle += SetIdle;
                break;
            case "Alone": //Alone, renedere enabled = true;
                transitionType.enableRenderer += EnableRenderer;
                break;            
        }
    }

    private void OnMouseUp()
    {
        transitionType.ComPos(gameObject.transform.position, animator);
    }

    public void SetIdle()
    {
        animator.SetTrigger("Origin");
    }

    public void ActiveCol()
    {
        _collider.enabled = true;
    }

    public void DeActiveCol()
    {
        _collider.enabled = false;
    }

    public void EnableRenderer()
    {
        _renderer.enabled = true;
    }
}
