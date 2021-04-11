using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject mainPanel;
    public GameObject howtoPanel;
    public GameObject optionsPanel;

    public Animator transition;
    public float transitionTime = 1.5f;

    public GameObject playerCam;
    public GameObject player;
    public GameObject menuCam;


    void Start()
    {
        playerCam.SetActive(false);
        player.SetActive(false);
        menuCam.SetActive(true);
        Cursor.visible = true;
    }
    public void Play()
    {
        DisableMM();
        StartPlayer();
        Cursor.visible = false;
    }

    public void HowtoPlay()
    {
        DisableMM();
        howtoPanel.SetActive(true);
        Debug.Log("You Opened 'How to Play' panel");
    }

    public void Options()
    {
        DisableMM();
        optionsPanel.SetActive(true);
        Debug.Log("You Opened 'Options' panel");
    }

    public void Back()
    {
        howtoPanel.SetActive(false);
        optionsPanel.SetActive(false);
        mainPanel.SetActive(true);
    }

    public void Quit()
    {
        Application.Quit();
        Debug.Log("You Exited the Game");
    }


    void DisableMM()
    {
        mainPanel.SetActive(false);
    }

    void StartPlayer()
    {
        playerCam.SetActive(true);
        player.SetActive(true);
        menuCam.SetActive(false);
    }

    public void LoadNextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
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
