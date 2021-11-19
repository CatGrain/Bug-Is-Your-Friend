using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MemoryGameManager : MonoBehaviour
{
    public PlayerTyp curentPlayer;
    bool waitOnPlayer = false;

    // Start is called before the first frame update
    void Start()
    {
        curentPlayer = PlayerTyp.Player;
        MemoryGameEvents.current.addPoint += AddCurentPlayerPoints;
        MemoryGameEvents.current.changePlayer += ChangeCurentPlayer;
        MemoryGameEvents.current.playerFoundBug += StoppAiDelay;
        MemoryGameEvents.current.stopAi += StoppAiDelay;
    }

    void AddCurentPlayerPoints()
    {
        if(curentPlayer == PlayerTyp.Player)
        {                    
            MemoryGameEvents.current.AddPlayerPoints();
            
        }
        else if(curentPlayer == PlayerTyp.Ai)
        {            
            StartCoroutine("AiStartDelay");
            
            MemoryGameEvents.current.AddAiPoints();         
        }
    }

    void ChangeCurentPlayer()
    {
        //Debug.Log(curentPlayer);
        Debug.Log(curentPlayer == PlayerTyp.Ai);

        if (curentPlayer == PlayerTyp.Ai)
        {    
            if(curentPlayer == PlayerTyp.Player)
            curentPlayer = PlayerTyp.Player;
        }
        else if(curentPlayer == PlayerTyp.Player)
        {
            if(curentPlayer == PlayerTyp.Player)
                Debug.Log("Ai Startet glerich");
            StopCoroutine("aiDelay");
            StartCoroutine("aiDelay");
        }
    }



    public enum PlayerTyp
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
        yield return new WaitForSeconds(0.5f);
        MemoryGameEvents.current.StartAi();
    }

    IEnumerator aiDelay()
    {
        Debug.Log("Start Delay");
        waitOnPlayer = true;
        yield return new WaitForSeconds(0.9f);      
        waitOnPlayer = false;
        curentPlayer = PlayerTyp.Ai;
        MemoryGameEvents.current.StopPlayer();
        MemoryGameEvents.current.StartAi();        
        Debug.Log("zu Ai Gewechselt");
        MemoryGameEvents.current.StartInfoPanel("Ai's turn");
        MemoryGameEvents.current.SwitchCheck();
    }
}
