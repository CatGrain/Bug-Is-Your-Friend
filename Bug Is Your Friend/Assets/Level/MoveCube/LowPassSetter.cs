using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LowPassSetter : MonoBehaviour
{
    public AudioLowPassFilter audioLow;

    public void CuttoffFrequency(int CuttoffFrequency, int Speed)
    {
        StartCoroutine(SetAudioLow(CuttoffFrequency,Speed));
    }

    IEnumerator SetAudioLow(int CuttoffFrequency,int Speed)
    {
        Debug.Log("Starte");
        int curentFrequency = (int)audioLow.cutoffFrequency;

        while (curentFrequency != CuttoffFrequency)
        {
            curentFrequency -=  (int)(Speed * Time.deltaTime);
            curentFrequency = Mathf.Clamp(curentFrequency,CuttoffFrequency,curentFrequency);
            audioLow.cutoffFrequency = curentFrequency;
            yield return new WaitForEndOfFrame();
        }

        Debug.Log("Fertig");
    }
}
