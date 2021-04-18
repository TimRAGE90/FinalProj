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
    float transitionTime = 1.5f;

    public GameObject playerCam;
    public GameObject player;
    public GameObject menuCam;

    float timeRemaining = 16;
    public bool isStarted;


    void Start()
    {
        playerCam.SetActive(false);
        player.SetActive(false);
        menuCam.SetActive(true);
        Cursor.visible = true;
        isStarted = false;
    }

    //camera animation; delay between MainMenu & HubLevel scenes
    void Update()
    {
        if (isStarted == true)
        {
            timeRemaining -= Time.deltaTime;
        }
        if (timeRemaining <= 0)
        {
            StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));            
        }
    }

    //button navigation
    public void Play()
    {
        isStarted = true;
        StartIntro();
        Cursor.visible = false;
    }

    public void HowtoPlay()
    {
        DisableMM();
        howtoPanel.SetActive(true);
    }

    public void Options()
    {
        DisableMM();
        optionsPanel.SetActive(true);
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
    }

    //disable main menu
    void DisableMM()
    {
        mainPanel.SetActive(false);
    }

    //begin intro; playercontrols are disabled during sequence
    void StartIntro()
    {
        playerCam.SetActive(true);
        player.SetActive(true);
        menuCam.SetActive(false);
    }

    //for scene transition
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
