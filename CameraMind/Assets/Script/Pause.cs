using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour {

    public Animator animator;

	void PauseTransition()
    {
        animator.speed = 0;
    }

    void PauseResume()
    {
        animator.speed = 1;
    }

    void PauseRestart()
    {
        SceneManager.LoadScene(SpawnPrefab.instance.scene, LoadSceneMode.Additive);
        //SceneManager.SetActiveScene(
    }

    void PauseMainMenu()
    {

    }

}
