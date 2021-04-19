using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ThrowableObject : MonoBehaviour
{
    public Text score;
    public Text finalScore;
    private int scoreValue = 0;

    // Start is called before the first frame update
    void Start()
    {
        score.text = "Score: " + scoreValue.ToString();
    }

    
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Collectible")
        {
            scoreValue += 1;
            score.text = "Score: " + scoreValue.ToString();
            finalScore.text = scoreValue.ToString();
            Destroy(other.gameObject);
        }
    }
}
