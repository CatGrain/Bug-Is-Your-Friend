using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MemoryAi : MonoBehaviour
{
    public GameObject CardBoard;
    int pairsCount;
    public List<int> previousIndexes;
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

        Card revalCard;
        revalCard = GetCard();

        Card card = revalCard;
        Card cardPair = revalCard.CardsPair;

        RevealCards(card,cardPair);
    }

    Card GetCard()
    {
        int index;

        while (true)
        {
            bool breakLoop = false;
            index = Random.Range(0, CardBoard.transform.childCount);

            foreach (var item in previousIndexes)
            {
                if(item == index)
                {
                    break;
                }
                else
                {
                    breakLoop = true;
                }
            }

            if(breakLoop)
            {
                break;
            }
        }
               
        Card card = CardBoard.transform.GetChild(index).GetComponentInParent<Card>();
        return card;
    }

    void RevealCards(Card cardOne,Card cardTwo)
    {
        cardOne.AiFlipTheCard();
        cardTwo.AiFlipTheCard();
    }


}
