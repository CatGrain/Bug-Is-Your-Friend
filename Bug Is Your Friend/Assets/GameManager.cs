using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    PlayerTyp curentPlayer;

    // Start is called before the first frame update
    void Start()
    {
        curentPlayer = PlayerTyp.Player;
        GameEvents.current.addPoint += AddCurentPlayerPoints;
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    void AddCurentPlayerPoints()
    {
        if(curentPlayer == PlayerTyp.Player)
        {
            GameEvents.current.AddPlayerPoints();
        }
        else if(curentPlayer == PlayerTyp.Ai)
        {
            GameEvents.current.AddAiPoints();
        }
    }

    void ChangeCurentPlayer()
    {
        if(curentPlayer == PlayerTyp.Ai)
        {
            curentPlayer = PlayerTyp.Player;
        }
        else if(curentPlayer == PlayerTyp.Player)
        {
            curentPlayer = PlayerTyp.Ai;
        }
    }

    enum PlayerTyp
    {
        Player = 0,
        Ai = 0,
    }
}
