using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ZombieCollider : MonoBehaviour
{
    public GameObject winLoseScreen;
    public GameObject gameUI;
    public GameObject player;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            winLoseScreen.SetActive(true);
            player.SetActive(false);
            gameUI.SetActive(false);
            Cursor.visible = true;
            TimerController.instance.EndTimer();
        }
    }
}
