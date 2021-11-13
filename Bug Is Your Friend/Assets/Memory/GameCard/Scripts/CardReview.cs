using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardReview : MonoBehaviour
{
    public Transform allCards;
    public Card lastCardId;
    public List<Card> cardscurrentlyRevealed;
    public List<Card> coupleCards;
    bool AiCheck;

    // Start is called before the first frame update
    void Start()
    {
        GameEvents.current.switchCheck += SwitchCheck;
        GameEvents.current.onCheckCard += checkCard;
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
            if (lastCardId.CardsPair == Id || Id.CardsPair == lastCardId)
            {               
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
            RemoveFalseCard();
            GameEvents.current.ChangePlayer();
        }      
        else
        {
            if (FindObjectOfType<GameManager>().curentPlayer == GameManager.PlayerTyp.Player)
            {
                GameEvents.current.StartPlayer();
            }
        }

        cardscurrentlyRevealed.Clear();
    }

    void RemoveFalseCard()
    {
        foreach (var item in cardscurrentlyRevealed)
        {
            item.TurnCard();
        }    
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
                GameEvents.current.AddPoint();           
            }

            item.Remove();
            cardscurrentlyRevealed.Remove(item);
        }

        coupleCards.Clear();
        ResultEvaluation();
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
        yield return new WaitForSeconds(1f);
        Debug.Log("Finale Überprüfung");
        GameEvents.current.StopPlayer();
        FinalCheckCards();
    }
     
}



