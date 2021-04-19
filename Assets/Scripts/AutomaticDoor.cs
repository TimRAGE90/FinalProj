using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutomaticDoor : MonoBehaviour
{
    public GameObject door;

    bool isOpened = false;

    private void OnTriggerEnter(Collider col)
    {
        if (isOpened == false)
        {
            isOpened = true;
            door.transform.position += new Vector3(-2, 0, 0);
        }
    }

    private void OnTriggerExit(Collider col)
    {
        if (isOpened == true)
        {
            isOpened = false;
            door.transform.position += new Vector3(2, 0, 0);
        }
    }
}
