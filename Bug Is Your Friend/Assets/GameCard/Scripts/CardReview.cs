using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardReview : MonoBehaviour
{
    public string lastCardId;

    // Start is called before the first frame update
    void Start()
    {
        GameEvents.current.onCheckCard += CheckCard;
    }

    void CheckCard(string cardId)
    {
        if(lastCardId != "")
        {
            if (lastCardId == cardId)
            {
                Debug.Log(lastCardId + cardId);
                Debug.Log("Es Ist ein P�rchen");
                lastCardId = "";
                GameEvents.current.AddPoint();
                GameEvents.current.StartReemoveAni();              
            }
            else
            {
                Debug.Log("Es Ist Kein P�rchen");
                lastCardId = "";

                GameEvents.current.StartCoverUpAni();
            }
        }
        else
        {
            lastCardId = cardId;
        }
    }  
}
