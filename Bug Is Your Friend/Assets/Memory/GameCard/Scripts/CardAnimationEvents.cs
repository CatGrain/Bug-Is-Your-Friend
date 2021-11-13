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
        GameEvents.current.CheckCard(thisCard);
    }

    public void ChangeImage()
    {
        GameEvents.current.ChangeImage();
    }

    public void ChangeImageBack()
    {
        Debug.Log("Hier komt ein event");
        GameEvents.current.ChangeImageBack();
    }

    public void NextPlayer()
    {
       // GameEvents.current.ChangePlayer();
    }

}
