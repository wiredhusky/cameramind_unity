using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clicked : MonoBehaviour {
    
    public Animator animator;
    public CircleCollider2D _collider;
    public Renderer _renderer;
    AnimatorStateInfo currentBaseState;
    int count = 0;

    IEnumerator WaitOneSecond(){
        Debug.Log("Enter");
        yield return new WaitForSeconds(1.0f);
        InGameManager.inGameManager.LevelTransitionPanel.SetActive(true);
    }
    
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
        SetRandomAni();
        count = 0;
        StartCoroutine("WaitOneSecond");
    }

    public void CountMove(){
        if(count != 2)
        {            
            count++;         
            Debug.Log("Count: " + count);
        }else
        {            
            animator.SetTrigger("cat_ready");
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
