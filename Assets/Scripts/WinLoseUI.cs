using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class WinLoseUI : MonoBehaviour
{

    //reloads current scene
    public void Rerun()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void ReturnHub()
    {
        SceneManager.LoadScene("HubLevel");
    }
}
