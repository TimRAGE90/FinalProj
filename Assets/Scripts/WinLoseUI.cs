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
        Debug.Log("You Reloaded the Current Scene");
    }

    //change name "SampleScene" to appropriate Hub scene name
    public void ReturnHub()
    {
        SceneManager.LoadScene("SampleScene");
        Debug.Log("You Returned to Hub");
    }
}
