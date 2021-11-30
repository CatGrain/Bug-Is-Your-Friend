using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundControler : MonoBehaviour
{
    public string name;
    public SoundGroup soundGroup;
    public AudioSource audioSource;
    public bool IsPlaying;

    private void Update()
    {
       
    }

    public void ChangeSoundVolume(float newVolume)
    {
        if(audioSource != null)
        audioSource.volume = newVolume;
        Debug.Log("Audio Geändert Auf: " + newVolume);
    }

    public void PlaySound()
    {
        audioSource.Play();
    }

    public void StopPlay()
    {
        audioSource.Stop();
    }
}
