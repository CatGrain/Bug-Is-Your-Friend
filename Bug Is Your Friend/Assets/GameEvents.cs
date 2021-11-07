using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public delegate void ActionEventHandler();
public delegate void ActionStringEventHandler(string String);

public class GameEvents : MonoBehaviour
{
    public static GameEvents current;

    private void Awake()
    {
        current = this;
    }

    public event ActionStringEventHandler onCheckCard;
    public void CheckCard(string cardId)
    {
        if(onCheckCard != null)
        {
            onCheckCard(cardId);
        }
    }


    public event ActionEventHandler StratCardFlipAni;
    public void StartFilpAni()
    {
        if (StratCardFlipAni != null)
        {
            StratCardFlipAni();
        }
    }


    public event ActionEventHandler StratCardCoverUpAni;
    public void StartCoverUpAni()
    {
        if (StratCardCoverUpAni != null)
        {
            StratCardCoverUpAni();
        }
    }


    public event ActionEventHandler startPlayer;
    public void StartPlayer()
    {
        startPlayer();
    }

    public event ActionEventHandler stopPlayer;
    public void StopPlayer()
    {
        stopPlayer();
    }


    public event ActionEventHandler StartRemoveAni;
    public void StartReemoveAni()
    {
        StartRemoveAni();
    }

    public event ActionEventHandler addPlayerPoints;
    public void AddPlayerPoints()
    {
        addPlayerPoints();
    }

    public event ActionEventHandler addAiPoints;
    public void AddAiPoints()
    {
        addAiPoints();
    }

    public event ActionEventHandler addPoint;
    public void AddPoint()
    {
        addPoint();
    }

}
