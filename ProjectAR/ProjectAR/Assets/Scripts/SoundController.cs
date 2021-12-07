using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundController : MonoBehaviour
{
    [SerializeField] private AudioSource audio = null;

    public void StartSound()
    {
        //if (audio == null) audio = gameObject.GetComponent<AudioSource>();
        audio.Play();
        audio.volume = 1f;
    }

    public void PauseSound()
    {
        //if (audio == null) audio = gameObject.GetComponent<AudioSource>();
        audio.Pause();
    }

    public void ContinueSound()
    {
        //if (audio == null) audio = gameObject.GetComponent<AudioSource>();
        audio.UnPause();
    }

    public void SoundOn()
    {
        //if (audio == null) audio = gameObject.GetComponent<AudioSource>();
        audio.volume = 1f;
    }

    public void SoundOff()
    {
        //if (audio == null) audio = gameObject.GetComponent<AudioSource>();
        audio.volume = 0f;
    }

    private void Awake()
    {
        //if(audio == null) audio = gameObject.GetComponent<AudioSource>();
        audio.playOnAwake = false;
        StartSound();
        PauseSound();
    }
}
