using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clicked : MonoBehaviour {
    
    public Animator animator;
    public CircleCollider2D _collider;
    public Renderer _renderer;
    
    private void Start()
    {
        
        GameManager.gameManager.activeCollider += ActiveCol;
        GameManager.gameManager.deactiveCollider += DeActiveCol;
        GameManager.gameManager.goIdle += SetIdle;

        switch (RootUIManager.rootUIManager.sceneName)
        {            
            case "Track": // Track
                GameManager.gameManager.goIdle += SetIdle;
                break;
            case "Alone": //Alone, renedere enabled = true;
                GameManager.gameManager.enableRenderer += EnableRenderer;
                break;            
        }
    }

    private void OnMouseUp()
    {
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
