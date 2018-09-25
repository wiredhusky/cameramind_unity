using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clicked : MonoBehaviour {
    
    public Animator animator;
    public CircleCollider2D _collider;
    public Renderer _renderer;
    
    private void Start()
    {
        
        TransitionControl.transitionControl.activeCollider += ActiveCol;
        TransitionControl.transitionControl.deactiveCollider += DeActiveCol;
        TransitionControl.transitionControl.goIdle += SetIdle;

        switch (SpawnPrefab.instance.scene)
        {            
            case "Track": // Track
                TransitionControl.transitionControl.goIdle += SetIdle;
                break;
            case "Alone": //Alone, renedere enabled = true;
                TransitionControl.transitionControl.enableRenderer += EnableRenderer;
                break;            
        }
    }

    private void OnMouseUp()
    {
        TransitionControl.transitionControl.ComPos(gameObject.transform.position, animator);
        Debug.Log("Clicked");
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
