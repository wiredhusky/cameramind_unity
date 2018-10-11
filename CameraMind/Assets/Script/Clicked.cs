using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clicked : MonoBehaviour {
    
    public Animator animator;
    public CircleCollider2D _collider;
    public Renderer _renderer;
    AnimatorStateInfo currentBaseState;
    
    private void Start()
    {        
        InGameManager.inGameManager.activeCollider += ActiveCol;
        InGameManager.inGameManager.deactiveCollider += DeActiveCol;
        InGameManager.inGameManager.goIdle += SetIdle;        

        if(RootUIManager.rootUIManager.sceneName == "Alone")
        {
            InGameManager.inGameManager.enableRenderer += EnableRenderer;
        }

        gameObject.SetActive(false);
    }

    private void OnMouseUp()
    {        
        RootGameManager.rootGameManager.ComPos(gameObject.transform.position, animator);
    }

    public void SetIdle()
    {
        if (gameObject.activeSelf == true)
        {
            currentBaseState = animator.GetCurrentAnimatorStateInfo(0);
            if (!currentBaseState.IsName("soomong20_idle"))
            {
                animator.SetTrigger("Origin");
            }
        }        
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
