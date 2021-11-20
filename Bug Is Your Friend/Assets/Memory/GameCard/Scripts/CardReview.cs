using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardReview : MonoBehaviour
{
    public Transform allCards;
    public Card lastCardId;
    public Card SecondCard;
    public List<Card> cardscurrentlyRevealed;
    public List<Card> coupleCards;
    bool AiCheck;

    // Start is called before the first frame update
    void Start()
    {
        MemoryGameEvents.current.switchCheck += SwitchCheck;
        MemoryGameEvents.current.onCheckCard += checkCard;
        //GameEvents.current.removeCardFromList += RemoveCardFromList;
    }


    void SwitchCheck()
    {
        AiCheck = true;
    }

    void CheckCard(Card Id)
    {
        if(lastCardId != null)
        {
            SecondCard = Id;
            Invoke("CompareCardS", 0.7f);          
        }
        else
        {
            lastCardId = Id;
        }
    }  

    bool CompareCardS()
    {
        if (lastCardId.CardsPair == SecondCard || SecondCard.CardsPair == lastCardId)
        {
            Debug.Log("Es Ist ein Pärchen");
            lastCardId = null;
            MemoryGameEvents.current.AddPoint();
            MemoryGameEvents.current.StartReemoveAni();
            return true;
        }
        else
        {
            Debug.Log("Es Ist Kein Pärchen");
            lastCardId = null;
            //MemoryGameEvents.current.ChangePlayer();
            MemoryGameEvents.current.StartCoverUpAni();
            return false;
        }
    }

    public void checkCard(Card Id)
    {
        if (AiCheck)
        {
             CheckCard(Id);
        }
        else
        {
            if (cardscurrentlyRevealed.Count != 0)
            {
                StopCoroutine("CheckTimer");
                StartCoroutine("CheckTimer");
            }

            Debug.Log("BekomeKarte:" + Id.name);
            cardscurrentlyRevealed.Add(Id);
        }
    }

    void ResultEvaluation()
    {      
        if(cardscurrentlyRevealed.Count > 0)
        {
            Debug.Log("Ai wird gestartet");            
            MemoryGameEvents.current.ChangePlayer();          
        }      
        else
        {         
            MemoryGameEvents.current.StartPlayer();
            Debug.Log("Start Palyer");
        }
        cardscurrentlyRevealed.Clear();
    }

    void RemoveFalseCard()
    {
        MemoryGameEvents.current.StartCoverUpAni();
        ResultEvaluation();
    }

    void RemoveCardCoupels()
    {
        int index = 0;

        foreach (var item in coupleCards)
        {
            index++;
            
            if(index % 2 == 0)
            {
                Debug.Log("Index " + index);
                MemoryGameEvents.current.AddPoint();           
            }

            item.Remove();
            cardscurrentlyRevealed.Remove(item);
        }

        coupleCards.Clear();
        RemoveFalseCard();        
    }

    void FinalCheckCards()
    {
        Debug.Log("Final Überprüfung");
        foreach (var item in cardscurrentlyRevealed)
        {
            foreach (var card in cardscurrentlyRevealed)
            {
                if(item.CardsPair == card || card.CardsPair == item)
                {
                    Debug.Log("Est ist ein paar");
                    coupleCards.Add(card);                   
                }              
            }
        }

        RemoveCardCoupels();
    }


    IEnumerator CheckTimer()
    {
        yield return new WaitForSeconds(0.5f);
        Debug.Log("Finale Überprüfung");
        MemoryGameEvents.current.StopPlayer();
        FinalCheckCards();
    }
     
   

}



