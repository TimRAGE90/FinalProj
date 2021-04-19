using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HubNavigation : MonoBehaviour
{
    public static bool levelOneWin;

    public Animator transition;
    public float transitionTime = 1.5f;

    public GameObject forestPanel;
    public GameObject nightPanel;
    public GameObject warePanel;


    private void Awake()
    {
        levelOneWin = false;
        Disable();
    }

    void OnTriggerEnter(Collider other)
    {
        //transition to forest level
        if(other.tag == "Door1")
        {
            StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
        }

        //transition to town level
        if(other.tag == "Door2")
        {
            StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 2));
        }

        //transition to scary level
        if(other.tag == "Door3")
        {
            StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 3));
        }

        //Hub's "death pit"
        if(other.tag =="HubPit")
        {
            transform.position = new Vector3(0, 0, 0);
        }

        if (other.tag == "Forest")
        {
            forestPanel.SetActive(true);
        }

        if (other.tag == "NightTown")
        {
            nightPanel.SetActive(true);
        }

        if (other.tag == "Warehouse")
        {
            warePanel.SetActive(true);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Forest" || other.tag == "NightTown" || other.tag == "Warehouse")
        {
            Disable();
        }
    }

    void Disable()
    {
        forestPanel.SetActive(false);
        nightPanel.SetActive(false);
        warePanel.SetActive(false);
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
