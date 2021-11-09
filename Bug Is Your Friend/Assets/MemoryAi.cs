using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MemoryAi : MonoBehaviour
{
    public GameObject CardBoard;
    int pairsCount;
    public List<Card> cards;
    public bool test;

    private void Start()
    {
        pairsCount = CardBoard.transform.childCount;
        GameEvents.current.strartAi += StartAiTrain;
        cards = CreateCardList();
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
        Card[] cards = new Card[2];

        Card picketCard = PickRandomCard();
        cards[0] = picketCard;
        cards[1] = picketCard.CardsPair;

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
            Transform curentChild = CardBoard.transform.GetChild(i);
            cards.Add(curentChild.GetComponent<Card>());
        }

        return cards;
    }
}
