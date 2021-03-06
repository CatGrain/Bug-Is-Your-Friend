using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public delegate void ActionEventHandler();
public delegate void ActionCardEventHandler(Card id);
public delegate void ActionStringEventHandler(string stringContennt);

public class MemoryGameEvents : MonoBehaviour
{
    public static MemoryGameEvents current;

    private void Awake()
    {
        current = this;
    }

    public event ActionCardEventHandler onCheckCard;
    public void CheckCard(Card Id)
    {
        if(onCheckCard != null)
        {
            onCheckCard(Id);
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


    public event ActionEventHandler changePlayer;
    public void ChangePlayer()
    {
        changePlayer();
    }

    public event ActionEventHandler playerFoundBug;
    public void PlayerFoundBug()
    {
        playerFoundBug();
    }


    public event ActionEventHandler strartAi;
    public void StartAi()
    {
        strartAi();
    }


    public event ActionStringEventHandler startInfoPanel;
    public void StartInfoPanel(string info)
    {
        startInfoPanel(info);
    }


    public event ActionEventHandler startInfoPanelAni;

    public void StartInfoPanelAni()
    {
        startInfoPanelAni();
    }

    public event ActionEventHandler changeImage;

    public void ChangeImage()
    {
        if(changeImage != null)
        changeImage();
    }   


    public event ActionEventHandler changeImageBack;

    public void ChangeImageBack()
    {
        if (changeImage != null)
            changeImageBack();
    }

    public event ActionCardEventHandler removeCardFromList;

    public void RemoveCardFromList(Card card)
    {
        removeCardFromList(card);
    }

    public event ActionEventHandler switchCheck;

    public void SwitchCheck()
    {
        switchCheck();
    }

    public event ActionEventHandler stopAi; 

    public void StopAi()
    {
        stopAi();
    }

}
