using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardReview : MonoBehaviour
{
    public Card lastCardId;

    public List<Card> cardscurrentlyRevealed;


    // Start is called before the first frame update
    void Start()
    {
        GameEvents.current.onCheckCard += CheckCard;
    }




    void CheckCard(Card Id)
    {
        if(lastCardId != null)
        {
            if (lastCardId.CardsPair == Id || Id.CardsPair == lastCardId)
            {
                //Debug.Log(lastCardId + cardId);
                Debug.Log("Es Ist ein Pärchen");
                lastCardId = null;
                GameEvents.current.AddPoint();
                GameEvents.current.StartReemoveAni();                
            }
            else
            {
                Debug.Log("Es Ist Kein Pärchen");
                lastCardId = null;
                GameEvents.current.ChangePlayer();
                GameEvents.current.StartCoverUpAni();              
            }
        }
        else
        {
            lastCardId = Id;
        }
    }  


    void checkCard(Card Id)
    {
        if(CheckRevealedCards(Id))
        {

        }
        else
        {
            cardscurrentlyRevealed.Add(Id);
        }
    }

    bool CheckRevealedCards(Card card)
    {
        foreach (var item in cardscurrentlyRevealed)
        {
            if(item.CardsPair == card || card.CardsPair == item)
            {
                return true;
            }
        }
     
        return false;
    }

}
