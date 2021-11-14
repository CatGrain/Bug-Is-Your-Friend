using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CardAnimationEvents : MonoBehaviour
{

    public static CardAnimationEvents current;
    Card thisCard;

    private void Start()
    {
        thisCard = GetComponent<Card>();
    }

    private void Awake()
    {
        current = this;
    }

    
    public  void CheckCard()
    {
        Debug.Log("Überprüfe Karte");
        //MemoryGameEvents.current.CheckCard(thisCard);
    }

    public void ChangeImage()
    {
        MemoryGameEvents.current.ChangeImage();
    }

    public void ChangeImageBack()
    {
        Debug.Log("Hier komt ein event");
        MemoryGameEvents.current.ChangeImageBack();
    }

    public void NextPlayer()
    {
       MemoryGameEvents.current.ChangePlayer();
    }

}
