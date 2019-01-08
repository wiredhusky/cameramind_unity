using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class Clicked : MonoBehaviour {
    
    public Animator animator;
    
    public PolygonCollider2D _collider;
    //public Renderer _renderer;
    //public SpriteRenderer spriteRenderer;
    AnimatorStateInfo currentBaseState;
    int count = 0;
    public Image objImg;

    IEnumerator WaitOneSecond(){
        yield return new WaitForSeconds(1.0f);
        //DoDanceLevelTransition is needed
        //InGameManager.inGameManager.LevelTransitionPanel.SetActive(true);
        RootUIManager.rootUIManager.DoDanceLevelTransition();
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
            case "Track":
                InGameManager.inGameManager.backToOriginColor += ColorChange;
                break;
            default:
                break;
        }
        gameObject.SetActive(false);
    }

    private void OnMouseUp()
    {
        if(RootUIManager.rootUIManager.TouchEffectController(gameObject, Input.mousePosition))
        {            
            RootGameManager.rootGameManager.ComPos(gameObject.transform.position, animator);
            objImg.DOColor(new Color(1, 1, 1), 0.1f);
        }
        else
        {
            objImg.DOColor(new Color(1, 1, 1), 0.1f);
        }
    }

    private void OnMouseDown()
    {
        objImg.DOColor(new Color(0.5f, 0.5f, 0.5f), 0.1f);
    }

    public void SetIdle()
    {
        if (gameObject.activeSelf == true)
        {
            currentBaseState = animator.GetCurrentAnimatorStateInfo(0);
            if (!currentBaseState.IsName("Origin"))
            {
                animator.SetTrigger("Origin");
            }
        }
    }

    public void ColorChange()
    {
        if(gameObject.activeSelf == true)
        {
            //spriteRenderer.color = new Color(1, 1, 1, 1);
            objImg.color = new Color(1, 1, 1, 1);
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
                    animator.SetTrigger("Origin");
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
    
    /*
    public void SetCatAni(){        
        SetRandomAni();
        count = 0;
        StartCoroutine("WaitOneSecond");
    }*/
    
    public void CountMove(){
        if(count != 2)
        {            
            count++;         
            Debug.Log("Count: " + count);
        }else
        {
            animator.SetTrigger("cat_ready");
            count = 0;
            SetRandomAni();
            StartCoroutine("WaitOneSecond");
            /*SetRandomAni();
            count = 0;
            StartCoroutine("WaitOneSecond");*/
        }
    }

    public void ActiveCol()
    {
        if(gameObject.activeSelf == true)
        {
            _collider.enabled = true;
        }
    }

    public void DeActiveCol()
    {
        if(gameObject.activeSelf == true)
        {
            _collider.enabled = false;
        }
    }

    public void EnableRenderer()
    {
        //_renderer.enabled = true;
    }
}
