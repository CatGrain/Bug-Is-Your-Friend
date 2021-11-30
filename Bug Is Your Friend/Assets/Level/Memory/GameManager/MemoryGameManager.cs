using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MemoryGameManager : MonoBehaviour
{
    public PlayerTyp curentPlayer;
    bool waitOnPlayer = false;
    public int pairsOnFiled;

    public PointsManager pointsManager;
    public WinnerInfoDispaly winnerInfoDispaly;
    public PannelChanger pannelChanger;
    bool playerIsGameOver;

    public UnityEvent onPlayerIsGameOver;
    public UnityEvent onPlayerHasWinn;
    
    static public MemoryGameManager instance;
   

    private void Awake()
    {
        instance = this;
    }

   
    // Start is called before the first frame update
    void Start()
    {
        pairsOnFiled = GetPairsCount();
        curentPlayer = PlayerTyp.Player;
        MemoryGameEvents.current.addPoint += AddCurentPlayerPoints;
        MemoryGameEvents.current.changePlayer += ChangeCurentPlayer;
        MemoryGameEvents.current.playerFoundBug += StoppAiDelay;
        MemoryGameEvents.current.stopAi += StoppAiDelay;     
    }

 

    private void Update()
    {
        if(pairsOnFiled == 0)
        {
            ShowHoIsTheWinner();
        }       
    }

    public void LetsGameStart()
    {
        Debug.Log("StartESpiel");
        SoundManager.Instance.PlaySound("MainTheme", SoundGroup.Music);
        MemoryGameEvents.current.StartInfoPanel("It's your turn");      
    }

    public void PausedGame()
    {
        MemoryGameEvents.current.StopPlayer();
    }

    public void ResumeGame()
    {
        if (curentPlayer == PlayerTyp.Player)
            MemoryGameEvents.current.StartPlayer();
    }

    void AddCurentPlayerPoints()
    {
        if(curentPlayer == PlayerTyp.Player)
        {                    
            MemoryGameEvents.current.AddPlayerPoints();
            pairsOnFiled--;
        }
        else if(curentPlayer == PlayerTyp.Ai)
        {            
            StartCoroutine("AiStartDelay");   
            MemoryGameEvents.current.AddAiPoints();
            pairsOnFiled--;
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
        //MemoryGameEvents.current.StopPlayer();
        MemoryGameEvents.current.SwitchCheck();
        MemoryGameEvents.current.StartAi();        
        Debug.Log("zu Ai Gewechselt");
        MemoryGameEvents.current.StartInfoPanel("Ai's turn");        
    }


    int GetPairsCount()
    {
        GameObject cardGrid = GameObject.FindGameObjectWithTag("CardGrid");
        if(cardGrid == null)
            return 0;

        return cardGrid.transform.childCount / 2;
    }

    void ShowHoIsTheWinner()
    {
        if(pointsManager.aiPointsInfo >= pointsManager.playerPointsInfo)
        {
            pannelChanger.SwitchPannell(1);
            winnerInfoDispaly.StartInfoDispaly("AI");          
            playerIsGameOver = true;
        }
        else
        {
            pannelChanger.SwitchPannell(1);
            winnerInfoDispaly.StartInfoDispaly("Player");                                
        }
    }

    public void GiveGameResult()
    {
        if(playerIsGameOver)
        {
            onPlayerIsGameOver?.Invoke();
            StartCoroutine(ChangeSound("GameOverTheme",1.5f));
        }
        else
        {
            onPlayerHasWinn?.Invoke();
            StartCoroutine(ChangeSound("WonTheme", 1f));
        }
    }

    IEnumerator ChangeSound(string soundName,float delay)
    {
        SoundManager.Instance.PlaySound(soundName, SoundGroup.Music);
        yield return new WaitForSeconds(delay);
        SoundManager.Instance.StoppPlay("MainTheme", SoundGroup.Music);
    }
    
}
