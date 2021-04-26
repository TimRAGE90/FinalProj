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

    public GameObject winLoseScreen;
    public GameObject gameUI;
    public GameObject player;
    public GameObject gameOverScreen;

    void Start()
    {
        DontDestroyOnLoad(gameObject);
    }
    
    void Update()
    {
        GameObject temp = GameObject.FindWithTag("FinishLevel1");
        GameObject tempa = GameObject.FindWithTag("FinishLevel2");
        GameObject tempb = GameObject.FindWithTag("FinishLevel3");

        if (temp == null)
        {
            if (SceneManager.GetActiveScene().name == "Level 1")
            {
                levelOneWin = true;
            }
        }

        if (tempa == null)
        {
            if (SceneManager.GetActiveScene().name == "Level 2")
            {
                levelTwoWin = true;
            }
        }

        if (tempb == null)
        {
            if (SceneManager.GetActiveScene().name == "level 3")
            {
                levelThreeWin = true;
            }
        }

        if (levelOneWin && levelTwoWin && levelThreeWin == true)
        {
            gameOver = true;
        }

        if (gameOver == true)
        {
            gameOverScreen.SetActive(true);
            winLoseScreen.SetActive(false);
            player.SetActive(false);
            gameUI.SetActive(false);
            Cursor.visible = true;
        }
    }
}
