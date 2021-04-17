using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public bool levelOneWin;

    void Start()
    {
        DontDestroyOnLoad(gameObject);
    }
    
    void Update()
    {
        GameObject temp = GameObject.FindWithTag("FinishLevel1");

        if(temp == null)
        {
            if (SceneManager.GetActiveScene().name == "testing")
            {
                levelOneWin = true;
            }
        }
    }
    
}
