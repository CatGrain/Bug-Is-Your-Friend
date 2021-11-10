using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    PlayerTyp curentPlayer;
    bool waitOnPlayer = false;

    // Start is called before the first frame update
    void Start()
    {
        curentPlayer = PlayerTyp.Player;
        GameEvents.current.addPoint += AddCurentPlayerPoints;
        GameEvents.current.changePlayer += ChangeCurentPlayer;
        GameEvents.current.playerFoundBug += StoppAiDelay;
    }

    void AddCurentPlayerPoints()
    {
        if(curentPlayer == PlayerTyp.Player)
        {           
            StoppAiDelay();
            GameEvents.current.AddPlayerPoints();
        }
        else if(curentPlayer == PlayerTyp.Ai)
        {
            StartCoroutine("AiStartDelay");            
            GameEvents.current.AddAiPoints();
           
        }
    }

    void ChangeCurentPlayer()
    {
        //Debug.Log(curentPlayer);
        Debug.Log(curentPlayer == PlayerTyp.Ai);

        if (curentPlayer == PlayerTyp.Ai)
        {            
            curentPlayer = PlayerTyp.Player;
        }
        else if(curentPlayer == PlayerTyp.Player)
        {
           StartCoroutine("aiDelay");
        }
    }



    enum PlayerTyp
    {
        Player = 0,
        Ai = 1,
    }

    void StoppAiDelay()
    {
        if(waitOnPlayer)
        {
            StopCoroutine("aiDelay");
        }
    }


    IEnumerator AiStartDelay()
    {
        yield return new WaitForSeconds(0.6f);
        GameEvents.current.StartAi();
    }

    IEnumerator aiDelay()
    {
        Debug.Log("Start Delay");
        waitOnPlayer = true;
        yield return new WaitForSeconds(0.9f);      
        waitOnPlayer = false;
        curentPlayer = PlayerTyp.Ai;
        GameEvents.current.StopPlayer();
        GameEvents.current.StartAi();        
        Debug.Log("zu Ai Gewechselt");
        GameEvents.current.StartInfoPanel("Ai's turn");
    }
}
