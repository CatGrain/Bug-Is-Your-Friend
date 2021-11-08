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


    private void Start()
    {
        StartPalyer();
        GameEvents.current.startPlayer += StartPalyer;
        GameEvents.current.stopPlayer += stopPlayer;
        //cardId = backImage.name;
    }

    public void AiFlipTheCard()
    {
        //GameEvents.current 
        GetComponent<CardAnimatorControler>().subscribeToGameEvents();
        GameEvents.current.StartFilpAni();        
    }

    public void FlipTheCard()
    {
        if (blockInput)
        {
            GetComponent<CardAnimatorControler>().subscribeToGameEvents();
            GameEvents.current.StartFilpAni();
            GameEvents.current.PlayerFoundBug();
        }
    }

    public void CheckCard()
    {
        GameEvents.current.CheckCard(CardsPair);
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
        blockInput = false;
        Image.GetComponent<Button>().enabled = false;
    }

    public void StartPalyer()
    {
        blockInput = true;
    }

    void Remove()
    {
        Destroy(gameObject);
    }
}
