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

        Card[] revalCard;
        revalCard = GetCard();       
        RevealCards(revalCard);
    }

    Card[] GetCard()
    {
        Card[] cards;

        

               
        Card card = CardBoard.transform.GetChild(0).GetComponentInParent<Card>();
        return new Card[0];
    }


    void RevealCards(Card[] cards)
    {
        foreach (var item in cards)
        {
            item.AiFlipTheCard();
        }
    }

    List<Card> CreateCardList()
    {
        List<Card> cards = new List<Card>();

        for (int i = 0; i < CardBoard.transform.childCount; i++)
        {
            Transform curentChild = transform.GetChild(i);
            cards.Add(curentChild.GetComponent<Card>());
        }


        return cards;
    }
}
