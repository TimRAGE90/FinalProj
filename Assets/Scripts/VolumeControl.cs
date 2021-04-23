using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class VolumeControl : MonoBehaviour
{
    public AudioMixer musicMixer;
    public AudioMixer soundMixer;

    static bool isActive;

    InputManager a;

    //Collider playerColliderComponent;
    //public bool playerInvincibleCheat;

    void Start()
    {
        isActive = false;
        a = GameObject.FindGameObjectWithTag("Player").GetComponent<InputManager>();
        //playerColliderComponent = GetComponent<BoxCollider>();
        //playerInvincibleCheat = true;
    }

    void Update()
    {
        //InputManager player = GetComponent<InputManager>();

        if (isActive == true)
        {
            //InputManager player = GetComponent<InputManager>();
            a.InvincibleCheat();
        }
    }

    public void SetMusicLevel (float sliderValue)
    {
        musicMixer.SetFloat ("MusicVol", Mathf.Log10 (sliderValue) * 20);
    }

    public void SetSoundLevel (float sliderValue)
    {
        soundMixer.SetFloat ("SoundVol", Mathf.Log10 (sliderValue) * 10);
    }

    public void SetInvincibleMode(bool tog)
    {

        if (tog == true)
        {
            isActive = true;
        }
        if (tog == false)
        {
            isActive = false;
        }
    }


    /*public void InvincibleCheat()
    {
        playerColliderComponent.enabled = !playerColliderComponent.enabled;
        //if (playerInvincibleCheat == true)
        //{
            
        //}
    }*/
}
