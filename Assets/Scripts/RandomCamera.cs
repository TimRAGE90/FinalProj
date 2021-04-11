using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomCamera : MonoBehaviour
{
   
   public int camNumber;

   public GameObject camOne;
   public GameObject camTwo;
   public GameObject camThree;


    void Start()
    {
        Reset();
        RandomGenerate();
    }


    void Update()
    {
        if (camNumber == 1)
        {
            camOne.SetActive(true);
        }
        if (camNumber == 2)
        {
            camTwo.SetActive(true);
        }
        if (camNumber == 3)
        {
            camThree.SetActive(true);
        }
    }

    public void RandomGenerate()
    {
        camNumber = Random.Range (1, 4);
    }

    public void Reset()
    {
        camOne.SetActive(false);
        camTwo.SetActive(false);
        camThree.SetActive(false);
    }
}
