using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorTransition : MonoBehaviour
{
    public Animator transition;
    public float transitionTime = 1.5f;

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Door1")
        {
            StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
        }

        if(other.tag == "Door2")
        {
            StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 2));
        }

        if(other.tag == "Door3")
        {
            StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 3));
        }
    }



    IEnumerator LoadLevel(int levelIndex)
    {
        //play anim
        transition.SetTrigger("Start");
        //wait
        yield return new WaitForSeconds(transitionTime);
        //load next scene
        SceneManager.LoadScene(levelIndex);
    }
}
