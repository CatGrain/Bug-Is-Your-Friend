using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MoveCubeGameManager : MonoBehaviour
{
    public PlayerParticelControler particelControler;
    public LowPassSetter lowPassSetter;

    public event UnityAction OnGameOver;
    public event UnityAction OnPLayerWonTheGame;
    public UnityEvent onOppenGameOverPannell;
    public UnityEvent onOppenWonPannell;

    public static MoveCubeGameManager events;
    private void Awake()
    {
        events = this;
    }

   
    public void PLayerIStDeath()
    {
        if(OnGameOver != null)
            OnGameOver();
    }

    public void PlayHasWonTheGame()
    {
        if(OnPLayerWonTheGame != null)
            OnPLayerWonTheGame();
    }


    private void Start()
    {
        OnGameOver += GameOver;
        OnPLayerWonTheGame += PlayerHasWonTheGame;
    }

    public void GameStart()
    {
        MoveCubeMoveMent.events.StartPlayer();
        SoundManager.Instance.PlaySound("MainTheme", SoundGroup.Music);

    }
  
    public void Paused()
    {
        ObstacleEvents.events.StoppObstcaleMove();
    }

    public void Resume()
    {
        ObstacleEvents.events.StartObstcaleMove();       
    }

    public void GameOver()
    {       
        MoveCubeMoveMent.events.StoppPlayer();
        SoundManager.Instance.PlaySound("Explosion",SoundGroup.Sound);
        particelControler.PlayParticle();
        lowPassSetter.CuttoffFrequency(315,1000001);
        MoveCubeMoveMent.events.gameObject.GetComponent<SpriteRenderer>().enabled = false;
        onOppenGameOverPannell?.Invoke();
    }

    public void PlayerHasWonTheGame()
    {
        onOppenWonPannell?.Invoke();
        MoveCubeMoveMent.events.StoppPlayer();
        SoundManager.Instance.SwitchSound("MainTheme",SoundGroup.Music,"WonTheme",SoundGroup.Music,1f);
    }
}
