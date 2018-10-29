using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clicked : MonoBehaviour {
    
    public Animator animator;
    public CircleCollider2D _collider;
    public Renderer _renderer;
    AnimatorStateInfo currentBaseState;
    int count = 0;
    
    private void Start()
    {        
        InGameManager.inGameManager.activeCollider += ActiveCol;
        InGameManager.inGameManager.deactiveCollider += DeActiveCol;
        InGameManager.inGameManager.goIdle += SetIdle;

        switch(RootUIManager.rootUIManager.sceneName){
            case "Alone":
                InGameManager.inGameManager.enableRenderer += EnableRenderer;
                break;
            case "DanceDance":
                InGameManager.inGameManager.goMove += SetMove;
                InGameManager.inGameManager.goRandomAni += SetRandomAni;
                break;
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

    public void SetMove(){
        if(gameObject.activeSelf == true){
            animator.SetTrigger("cat_move");
        }
    }

    public void SetRandomAni(){
        if (gameObject.activeSelf == true)
        {
            int rand;
            rand = Random.Range(0, 4);
            switch (rand)
            {
                case 0:
                    animator.SetTrigger("cat_idle");
                    break;
                case 1:
                    animator.SetTrigger("cat_leg_up");
                    break;
                case 2:
                    animator.SetTrigger("cat_tail_down");
                    break;
                case 3:
                    animator.SetTrigger("cat_sit");
                    break;
            }
        }
    }

    public void SetCatAni(){
        if(count == 3){
            SetRandomAni();
            count = 0;
        }
    }

    public void CountMove(){
        count++;
        Debug.Log("Count: " + count);
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
