using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HubResetPos : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if(other.tag =="HubPit")
        {
            transform.position = new Vector3(0, 0, 0);
        }
    }
}
