using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundControler : MonoBehaviour
{
    public SoundGroup soundGroup;
    public AudioSource audioSource;

    public void ChangeSoundVolume(float newVolume)
    {
        if(audioSource != null)
        audioSource.volume = newVolume;
        Debug.Log("Audio Geändert Auf: " + newVolume);
    }
}
