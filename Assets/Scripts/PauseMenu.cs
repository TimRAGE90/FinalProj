using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pausePanel;
    public GameObject aboutPanel;
    public GameObject optionsPanel;


    PauseAction pauseAction;

    //public Rigidbody c_Rigidbody;


    //disables pause menu at start
    void Start()
    {
        TurnOff();
    }

    //pause, quit, & cheat action maps
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


    //pause function
    public void OnPause()
    {
        if (Time.timeScale == 1)
        {
            Time.timeScale = 0;
            pausePanel.SetActive(true);
            Cursor.visible = true;
            //c_Rigidbody.constraints = RigidbodyConstraints.FreezePositionX;
        }
        else
        {
            Time.timeScale = 1;
            TurnOff();
            Cursor.visible = false;
            //c_Rigidbody.constraints = RigidbodyConstraints.None;
        }   
    }

    //exit game function
    public void OnQuit()
    {
        Application.Quit();
    }


    //button navigation
    public void Continue()
    {
        Time.timeScale = 1;
        TurnOff();
        Cursor.visible = false;

    }
    public void About()
    {
        aboutPanel.SetActive(true);
        pausePanel.SetActive(false);
    }
    public void Back()
    {
        pausePanel.SetActive(true);
        aboutPanel.SetActive(false);
        optionsPanel.SetActive(false);
    }
    public void Settings()
    {
        pausePanel.SetActive(false);
        optionsPanel.SetActive(true);
    }
    public void ReturnHub()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("HubLevel");
    }


    //reset pause panel
    void TurnOff()
    {
        pausePanel.SetActive(false);
        aboutPanel.SetActive(false);
        optionsPanel.SetActive(false);
    }
}
