using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class VolumeControl : MonoBehaviour
{
    public AudioMixer mixer;

    //Collider playerColliderComponent;
    //public bool playerInvincibleCheat;

    void Start()
    {
        //playerColliderComponent = GetComponent<BoxCollider>();
        //playerInvincibleCheat = true;
    }

    public void SetLevel (float sliderValue)
    {
        mixer.SetFloat ("MusicVol", Mathf.Log10 (sliderValue) * 20);
    }

    /*public void InvincibleCheat()
    {
        playerColliderComponent.enabled = !playerColliderComponent.enabled;
        //if (playerInvincibleCheat == true)
        //{
            
        //}
    }*/
}
