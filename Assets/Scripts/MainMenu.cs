using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject mainPanel;
    public GameObject howtoPanel;
    public GameObject optionsPanel;
    public GameObject creditsPanel;

    public Animator transition;
    float transitionTime = 1.5f;

    public GameObject animCam;
    public GameObject menuCam;

    float timeRemaining = 16;
    public bool isStarted;

    public GameObject intro;

    PauseAction pauseAction;
    void Start()
    {
        animCam.SetActive(false);
        menuCam.SetActive(true);
        Cursor.visible = true;
        isStarted = false;
        intro.SetActive(false);
        creditsPanel.SetActive(false);
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

    private void OnEnable()
    {
        pauseAction = new PauseAction();
        pauseAction.UI.Pause.performed += _ => OnSkip();
        pauseAction.Enable();
    }

    private void OnDisable()
    {
        pauseAction.Disable();
    }

    public void OnSkip()
    {
        if (isStarted == true)
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
        intro.SetActive(true);
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

    public void Credits()
    {
        mainPanel.SetActive(false);
        creditsPanel.SetActive(true);
    }

    public void Back()
    {
        howtoPanel.SetActive(false);
        optionsPanel.SetActive(false);
        mainPanel.SetActive(true);
        creditsPanel.SetActive(false);
    }

    public void Quit()
    {
        Application.Quit();
        Debug.Log("You Exited the Game");
    }

    //disable main menu
    void DisableMM()
    {
        mainPanel.SetActive(false);
    }

    //begin intro; playercontrols are disabled during sequence
    void StartIntro()
    {
        animCam.SetActive(true);
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
