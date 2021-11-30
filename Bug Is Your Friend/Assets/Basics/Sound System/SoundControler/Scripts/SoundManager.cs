using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class SoundManager : MonoBehaviour
{
    public SoundGroupInfo[] SoundControlerGroups;
    public int soundGroupCount;
    SoundControler[] soundControlers;

    public event Action<SoundGroup,float> OnSliderHasChanged;

    public static SoundManager Instance;
    private void Awake()
    {
        Instance = this;    
    }

    event UnityAction<string,SoundGroup> onPlaySound;
    public void OnPlaySound(string soundName,SoundGroup soundGroup)
    {
        if (Instance == null)   
            OnPlaySound(soundName,soundGroup);
    }

    private void Start()
    {
        OnSliderHasChanged += ChangeSoundVolume;

        onPlaySound += PlaySound;
        
        soundGroupCount = Enum.GetValues(typeof(SoundGroup)).Length;    
        SoundControlerGroups = new SoundGroupInfo[soundGroupCount];

        soundControlers = FindObjectsOfType<SoundControler>();


        CreateSoundControlerGroups();
        SetStartValue();
    }

    public void SwitchSound(string ChangesoundName,SoundGroup ChangesoundSoundGroup, string SoundName, SoundGroup soundSoundGroup,float transition)
    {
        StartCoroutine( ChangeSound(ChangesoundName,ChangesoundSoundGroup,SoundName,soundSoundGroup,transition) );
    }

    IEnumerator ChangeSound(string Changesound,SoundGroup ChangesoundSoundGroup, string SoundName, SoundGroup soundSoundGroup, float delay)
    {
        PlaySound(SoundName,soundSoundGroup);
        yield return new WaitForSeconds(delay);
        StoppPlay(Changesound,ChangesoundSoundGroup);               
    }

    public void PlaySound(string SoundName, SoundGroup soundGroup)
    {
        SoundGroupInfo soundGroupInfo = GetSoundGroupInfoOfSoundGroupTyp(soundGroup);
        Debug.Log("Spiele Sound");
        foreach (var item in soundGroupInfo.soundControler)
        {
            if (item.name == SoundName)
                item.PlaySound();
        }
    }

    public void StoppPlay(string SoundName, SoundGroup soundGroup)
    {
        SoundGroupInfo soundGroupInfo = GetSoundGroupInfoOfSoundGroupTyp(soundGroup);
        foreach (var item in soundGroupInfo.soundControler)
        {
            if (item.name == SoundName)
                item.StopPlay();
        }
    }



    //Zuweisung Der Geänderten SoundEinstelungen
    public void ChangeSoundVolume(SoundGroup soundGroup,float newVolume)
    {
        SoundGroupInfo soundGroupInfo = GetSoundGroupInfoOfSoundGroupTyp(soundGroup);
        foreach (var item in soundGroupInfo.soundControler)
        {
            item.ChangeSoundVolume(newVolume);          
        }
        SoundGroupVolumeSaver.SaveAudioVolume(soundGroup, newVolume);
    }



    public SoundGroupInfo GetSoundGroupInfoOfSoundGroupTyp(SoundGroup group)
    {
        foreach (var item in SoundControlerGroups)
        {
            if(item.soundGroup == group)
            {
                return item;
            }
        }
        return new SoundGroupInfo();
    }


    //Start Zuweisung der Sound Gruppenm
    void CreateSoundControlerGroups()
    {
        for (int i = 0; i < soundGroupCount; i++)
        {
            SoundGroup soundGroup = (SoundGroup)i;
            SoundControlerGroups[i] = CreateSoundGroupInfo(soundGroup);
        }
    }

    SoundGroupInfo CreateSoundGroupInfo(SoundGroup soundGroup)
    {      
        SoundGroup curentGroup = soundGroup;  
        SoundGroupInfo soundGroupInfo = new SoundGroupInfo(curentGroup);
        soundGroupInfo.soundControler = FindSoundControlerOfGroup(curentGroup);     
        return soundGroupInfo;
    }

    List<SoundControler> FindSoundControlerOfGroup(SoundGroup group)
    {
        List<SoundControler> controlers = new List<SoundControler>();

        foreach (var item in soundControlers)
        {
            SoundGroup soundGroup = item.soundGroup;
            if(soundGroup == group)
            {
                controlers.Add(item);
            }
        }

        return controlers;
    }

    void SetStartValue()
    {
        foreach (var item in SoundControlerGroups)
        {
            float curentSoundGroupVolume = item.SoundGroupVolume;
            foreach (var controler in item.soundControler)
            {
                controler.ChangeSoundVolume(curentSoundGroupVolume);
            }
        }
    }
}

[System.Serializable]
public struct SoundGroupInfo
{
    public SoundGroupInfo(SoundGroup group)
    {
        soundGroup = group;
        soundControler = new List<SoundControler>();
        SoundGroupVolume = SoundGroupVolumeSaver.GetSoundGroupVolume(group);
    }

    public SoundGroup soundGroup;
    public List<SoundControler> soundControler; 
    public float SoundGroupVolume;
}

public static class SoundGroupVolumeSaver
{
    public static float GetSoundGroupVolume(SoundGroup soundGroup)
    {
        string soundGroupAsString = soundGroup.ToString();
        if (PlayerPrefs.HasKey(soundGroupAsString))
        {
            return PlayerPrefs.GetFloat(soundGroupAsString);
        }
        return 1;
    }

    public static void SaveAudioVolume(SoundGroup soundGroup, float soundVolume)
    {
        string soundGroupAsString = soundGroup.ToString();
        PlayerPrefs.SetFloat(soundGroupAsString, soundVolume);
    }
}
   
