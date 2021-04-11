using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pausePanel;
    public GameObject aboutPanel;


    PauseAction pauseAction;



    private void Awake()
    {
        
    }

    private void OnEnable()
    {
        pauseAction = new PauseAction();
        pauseAction.UI.Pause.performed += _ => OnPause();
        pauseAction.UI.Quit.performed += _ => OnQuit();
        pauseAction.Enable();
    }

    private void OnDisable()
    {
        pauseAction.Disable();
    }


    void Start()
    {
        TurnOff();
    }


    //pause function
    public void OnPause()
    {
        if (Time.timeScale == 1)
        {
            Time.timeScale = 0;
            pausePanel.SetActive(true);
            Cursor.visible = true;
        }

        else
        {
            Time.timeScale = 1;
            TurnOff();
        }   
    }

    public void OnQuit()
    {
        Application.Quit();
        Debug.Log("You Exited the Game");
    }

    //button navigation
    public void Continue()
    {
        Time.timeScale = 1;
        TurnOff();
    }

    public void About()
    {
        aboutPanel.SetActive(true);
        TurnOff();
        Debug.Log("You Opened 'About' panel");
    }

    public void Back()
    {
        pausePanel.SetActive(true);
        aboutPanel.SetActive(false);
    }

    public void ReturnHub()
    {
        SceneManager.LoadScene("SampleScene");
        Debug.Log("You Returned to Hub");        
    }

    //reset pause panel
    void TurnOff()
    {
        pausePanel.SetActive(false);
        Cursor.visible = false;
    }
}
