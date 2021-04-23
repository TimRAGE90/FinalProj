using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class VolumeControl : MonoBehaviour
{
    public AudioMixer musicMixer;
    public AudioMixer soundMixer;


    InputManager a;

    //Collider playerColliderComponent;
    //public bool playerInvincibleCheat;

    void Start()
    {
        a = GameObject.FindGameObjectWithTag("Player").GetComponent<InputManager>();
        //playerColliderComponent = GetComponent<BoxCollider>();
        //playerInvincibleCheat = true;
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
        InputManager player = GetComponent<InputManager>();

        if (tog == true)
        {
            player.InvincibleCheat();
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
