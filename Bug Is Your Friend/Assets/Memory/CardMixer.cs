using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardMixer : MonoBehaviour
{

    public Transform carGrid;

    void Start()
    {
        MixCards();
    }

    void MixCards()
    {
        List<Transform> cards = new List<Transform>();

        for (int i = 0; i < carGrid.childCount; i++)
        {
            cards.Add(carGrid.GetChild(i));
        }

        foreach (var item in cards)
        {
            Transform curentCard = item;
            int newIndex = GetRandomIndex(cards.Count);
            curentCard.SetSiblingIndex(newIndex);
        }
    }

    int GetRandomIndex(int maxindex)
    {
        return  Random.Range(0,maxindex);
    }  
}
