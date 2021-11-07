using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public delegate void CheckCardEventHandler();
public class Card : MonoBehaviour
{
    public Image Image;
    public Sprite backImage;
    Sprite oldImage;
    public string cardId;
    bool playerisNotOnIt;

    private void Start()
    {
        StartPalyer();
        GameEvents.current.startPlayer += StartPalyer;
        GameEvents.current.stopPlayer += stopPlayer;
        //cardId = backImage.name;
    }

    public void FlipTheCard()
    {
        if (playerisNotOnIt)
        {
            stopPlayer();
            GetComponent<CardAnimatorControler>().subscribeToGameEvents();
            GameEvents.current.StartFilpAni();
        }
    }

    public void CheckCard()
    {
        GameEvents.current.CheckCard(cardId);
    }

    public void ChangeImage()
    {
        oldImage = Image.sprite;
        Image.sprite = backImage;
    }

    public void ChangeImageBack()
    {
        Image.sprite = oldImage;
    }


    void stopPlayer()
    {
        playerisNotOnIt = false;
    }

    public void StartPalyer()
    {
        playerisNotOnIt = true;
    }
}
