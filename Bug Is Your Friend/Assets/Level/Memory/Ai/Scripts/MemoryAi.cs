using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MemoryAi : MonoBehaviour
{
    public GameObject CardBoard;
    int pairsCount;
    public List<Card> cards;
    public bool test;
    bool RenewedCardDeck;


    private void Start()
    {
        pairsCount = CardBoard.transform.childCount;
        MemoryGameEvents.current.strartAi += StartAiTrain;
        cards = CreateCardList();
        RenewedCardDeck = true;
    }

    private void Update()
    {
        if (test)
        {
            test = false;
            StartAiTrain();
        }
    }

    void StartAiTrain()
    {
        if(RenewedCardDeck)
        {
            RenewedCardDeck = false;
            cards = CreateCardList();
        }

        Debug.Log("Ai Startet Züg");
        if (cards.Count > 0)
        {            
            Card[] revalCard;
            revalCard = GetCard();
            RevealCards(revalCard);
            RemoveCards(revalCard);
        }
    }

    Card[] GetCard()
    {
        Debug.Log("Get Card");

        Card[] cards = new Card[2];

        Card picketCard = PickRandomCard();
        cards[0] = picketCard;
        cards[1] = picketCard.CardsPair;

        Debug.Log("PickeztCard" + picketCard.name);

        return cards;
    }


    void RevealCards(Card[] cards)
    {
        foreach (var item in cards)
        {
            item.AiFlipTheCard();
        }
    }

    Card PickRandomCard()
    {
        int randomIndex = Random.Range(0,cards.Count);
        return cards[randomIndex];
    }


    void RemoveCards(Card[] cardsToRemove)
    {
        if (cards.Count > 0)
        {
            Debug.Log("Kommt es hier von");
            foreach (var item in cardsToRemove)
            {
                cards.Remove(item);
            }
        }
    }

    List<Card> CreateCardList()
    {
        List<Card> cards = new List<Card>();

        Debug.Log(CardBoard.transform.childCount - 1);

        for (int i = 0; i < CardBoard.transform.childCount; i++)
        {
            Debug.Log(i);
            Card CurentCard = CardBoard.transform.GetChild(i).GetComponent<Card>();

            if(!CurentCard.CardRemoved)
            cards.Add(CurentCard);
        }

        return cards;
    }



}
