using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainTransition : MonoBehaviour {

    public GameObject soomong;
    Animator animator;

	private void SoomongShaker()
    {
        animator = soomong.GetComponent<Animator>();
        animator.SetTrigger("shaking");
    }

    private void GoToMain()
    {
        SceneManager.LoadScene(0);
    }
	
}
