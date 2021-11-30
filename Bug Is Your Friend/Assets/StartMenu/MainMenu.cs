using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public void StartGame()
    {
        SoundManager.Instance.PlaySound("MainTheme",SoundGroup.Music);
    }
}
