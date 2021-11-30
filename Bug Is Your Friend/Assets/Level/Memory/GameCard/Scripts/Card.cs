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
    public Card CardsPair;
    public bool blockInput;
    CardAnimatorControler cardAnimatorControler;
    bool CardRevealed;
    public bool CardRemoved = false;

    private void Start()
    {
        Debug.Log("Card is :" + CardRemoved);
        StartPalyer();
        cardAnimatorControler = GetComponent<CardAnimatorControler>();
        MemoryGameEvents.current.startPlayer += StartPalyer;
        MemoryGameEvents.current.stopPlayer += stopPlayer;
        //cardId = backImage.name;
    }

    public void AiFlipTheCard()
    {
        //GameEvents.current 
        CardRevealed = true;
        GetComponent<CardAnimatorControler>().subscribeToGameEvents();
        MemoryGameEvents.current.StartFilpAni();
        MemoryGameEvents.current.CheckCard(this);
        SoundManager.Instance.PlaySound("TurnCardOver", SoundGroup.Sound);
    }

    public void FlipTheCard()
    {
        if (blockInput)
        {
            stopPlayer();
            CardRevealed = true;
            GetComponent<CardAnimatorControler>().subscribeToGameEvents();
            MemoryGameEvents.current.StartFilpAni();
            //GameEvents.current.PlayerFoundBug();
            MemoryGameEvents.current.changeImage += ChangeImage;
            MemoryGameEvents.current.changeImageBack += ChangeImageBack;
            MemoryGameEvents.current.StopAi();
            MemoryGameEvents.current.CheckCard(this);
            SoundManager.Instance.PlaySound("TurnCardOver",SoundGroup.Sound);
        }
    }

    /*
    public void CheckCard()
    {
        GameEvents.current.CheckCard(this);
    }
    */

    public void ChangeImage()
    {
        oldImage = Image.sprite;
        Image.sprite = backImage;
        MemoryGameEvents.current.changeImage -= ChangeImage;
    }

    public void ChangeImageBack()
    {       
        Image.sprite = oldImage;
        MemoryGameEvents.current.changeImageBack -= ChangeImageBack;
    }


    void stopPlayer()
    {
        blockInput = false;     
        Image.GetComponent<Button>().enabled = false;
    }

    public void StartPalyer()
    {
        blockInput = true;
        Debug.Log("Habe bis Hier zugrif");
        Image.GetComponent<Button>().enabled = true;
    }

    public void TurnCard()
    {
        cardAnimatorControler.CoverUpAni();
        Debug.Log("Drehe Karte Um");
        SoundManager.Instance.PlaySound("TurnCard", SoundGroup.Sound);
    }

    public void Remove()
    {
        CardRemoved = true;
        cardAnimatorControler.RemoveCardAni();
    }
}
