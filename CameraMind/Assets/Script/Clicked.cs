using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clicked : MonoBehaviour {
    
    public Animator animator;
    public CircleCollider2D _collider;
    public Renderer _renderer;
    
    private void Start()
    {
        //_renderer.enabled = false;
        InGameManager.inGameManager.activeCollider += ActiveCol;
        InGameManager.inGameManager.deactiveCollider += DeActiveCol;
        InGameManager.inGameManager.goIdle += SetIdle;

        switch (RootUIManager.rootUIManager.sceneName)
        {            
            case "Track": // Track
                InGameManager.inGameManager.goIdle += SetIdle;
                break;
            case "Alone": //Alone, renedere enabled = true;
                InGameManager.inGameManager.enableRenderer += EnableRenderer;
                break;            
        }
        gameObject.SetActive(false);
    }

    private void OnMouseUp()
    {
        Debug.Log("Clicked");
        RootGameManager.rootGameManager.ComPos(gameObject.transform.position, animator);
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
