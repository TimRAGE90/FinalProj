using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class VolumeControl : MonoBehaviour
{
    public AudioMixer musicMixer;
    public AudioMixer soundMixer;



    //Collider playerColliderComponent;
    //public bool playerInvincibleCheat;

    void Start()
    {
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

    public void SetFullscreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
    }


    /*public void InvincibleCheat()
    {
        playerColliderComponent.enabled = !playerColliderComponent.enabled;
        //if (playerInvincibleCheat == true)
        //{
            
        //}
    }*/
}
