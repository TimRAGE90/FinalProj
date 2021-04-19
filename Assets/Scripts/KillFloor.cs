using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KillFloor : MonoBehaviour
{
    //public Transform player;
    public Transform respawnPoint;

    public GameObject winLoseScreen;
    public GameObject gameUI;
    public GameObject player;

    //public Text gameOverText;

    private void Start()
    {
        //gameOverText.text = "";
    }

    private void OnTriggerEnter(Collider other)
    {
        player.transform.position = respawnPoint.transform.position;
        winLoseScreen.SetActive(true);
        player.SetActive(false);
        gameUI.SetActive(false);
        Cursor.visible = true;
        TimerController.instance.EndTimer();
        //gameOverText.text = "You lose";
    }
}
