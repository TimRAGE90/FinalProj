using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public bool levelOneWin;
    public bool levelTwoWin;
    public bool levelThreeWin;
    public bool gameOver;

    void Start()
    {
        DontDestroyOnLoad(gameObject);
    }
    
    void Update()
    {
        GameObject temp = GameObject.FindWithTag("FinishLevel1");
        GameObject tempA = GameObject.FindWithTag("FinishLevel2");
        GameObject tempB = GameObject.FindWithTag("FinishLevel2");

        if (temp == null)
        {
            if (SceneManager.GetActiveScene().name == "Level 1")
            {
                levelOneWin = true;
            }
        }

        else if (tempA == null)
        {
            if (SceneManager.GetActiveScene().name == "Level 2")
            {
                levelTwoWin = true;
            }
        }

        else if (tempB == null)
        {
            if (SceneManager.GetActiveScene().name == "Level 3")
            {
                levelThreeWin = true;
            }
        }

        if (levelOneWin && levelTwoWin && levelThreeWin == true)
        {
            gameOver = true;
        }
    }
    
}
