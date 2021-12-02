using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundController : MonoBehaviour
{
    [SerializeField] private AudioSource audio = null;

    public void StartSound()
    {
        audio.Play();
        Debug.Log("Play");
    }

    public void PauseSound()
    {
        audio.Pause();
        Debug.Log("Pause");
    }

    public void ContinueSound()
    {
        audio.UnPause();
        Debug.Log("UnPause");
    }

    private void Awake()
    {
        audio = gameObject.GetComponent<AudioSource>();
        audio.playOnAwake = false;
        StartSound();
        PauseSound();
    }
}
