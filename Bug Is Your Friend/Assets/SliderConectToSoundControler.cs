using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderConectToSoundControler : MonoBehaviour
{
    public SoundGroup soundGroup;
    public SoundManager soundManager;
    Slider slider;

    private void Start()
    {
       slider = GetComponent<Slider>(); 
       InitializeSliderValue();
    }

    public void ChangeVolume(Slider slider)
    {
        soundManager.ChangeSoundVolume(soundGroup,GetSliderValue(slider));
    }

    float GetSliderValue(Slider slider)
    {
        return slider.value;
    }
    
    void InitializeSliderValue()
    {
        float CurentSoundGroupValue = soundManager.GetSoundGroupInfoOfSoundGroupTyp(soundGroup).SoundGroupVolume; 
        slider.value = CurentSoundGroupValue;       
    }

}
