using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HubNavigation : MonoBehaviour
{
    public static bool levelOneWin;

    public Animator transition;
    float transitionTime = 1.5f;

    public GameObject forestPanel;
    public GameObject nightPanel;
    public GameObject warePanel;

    public GameObject movePanel;
    public GameObject lookPanel;
    public GameObject wallrunPanel;
    public GameObject jumpPanel;
    public GameObject slidePanel;
    public GameObject zombiePanel;

    AudioSource audioSource;
    public AudioClip resetSound;
    public AudioClip transSound;


    private void Awake()
    {
        levelOneWin = false;
        Disable();
        RemovePanels();
        audioSource = GetComponent<AudioSource>();
    }

    void OnTriggerEnter(Collider other)
    {
        //transition to forest level
        if(other.tag == "Door1")
        {
            StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
            Transition();
        }

        //transition to town level
        if(other.tag == "Door2")
        {
            StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 2));
            Transition();
        }

        //transition to scary level
        if(other.tag == "Door3")
        {
            StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 3));
            Transition();
        }

        //Hub's "death pit"
        if(other.tag =="HubPit")
        {
            transform.position = new Vector3(0, 0, 0);
            PlaySound(resetSound);
        }

        //UI triggers
        if (other.tag == "Forest")
        {
            forestPanel.SetActive(true);
        }

        if (other.tag == "NightTown")
        {
            nightPanel.SetActive(true);
        }

        if (other.tag == "Warehouse")
        {
            warePanel.SetActive(true);
        }

        if (other.tag == "MoveLook")
        {
            movePanel.SetActive(true);
            lookPanel.SetActive(true);
        }

        if (other.tag == "WallRun")
        {
            wallrunPanel.SetActive(true);
        }

        if (other.tag == "Slide")
        {
            slidePanel.SetActive(true);
        }

        if (other.tag == "Jump")
        {
            jumpPanel.SetActive(true);
        }

        if (other.tag == "Zombie")
        {
            zombiePanel.SetActive(true);
        }
    }

    //sound effect management
    public void PlaySound(AudioClip clip)
    {
        audioSource.PlayOneShot(clip);
    }

    //disable UI instances
    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Forest" || other.tag == "NightTown" || other.tag == "Warehouse")
        {
            Disable();
        }

        if (other.tag == "MoveLook" || other.tag == "WallRun" || other.tag == "Slide" || other.tag == "Zombie" || other.tag == "Jump")
        {
            RemovePanels();
        }
    }

    void Disable()
    {
        forestPanel.SetActive(false);
        nightPanel.SetActive(false);
        warePanel.SetActive(false);
    }

    void RemovePanels()
   {
       movePanel.SetActive(false);
       lookPanel.SetActive(false);
       wallrunPanel.SetActive(false);
       jumpPanel.SetActive(false);
       slidePanel.SetActive(false);
       zombiePanel.SetActive(false);
   }

   void Transition()
  {
      PlaySound(transSound);
  }

    IEnumerator LoadLevel(int levelIndex)
    {
        //play anim
        transition.SetTrigger("Start");
        //wait
        yield return new WaitForSeconds(transitionTime);
        //load next scene
        SceneManager.LoadScene(levelIndex);
    }
}
