using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameStarter : MonoBehaviour
{
    public float StartTime;
    public UnityEvent onStarted;
    public Animator animator;

    private void Start()
    {
        InputManger.instance.OnBlockInput();
        StartCoroutine(GameStart());
    }

    IEnumerator GameStart()
    {
        animator.SetTrigger("Start");
        yield return new WaitForSeconds(StartTime);
        StartGame();
    }

    public void StartGame()
    {
        Debug.Log("Spiel Kann Starten");
        InputManger.instance.OnUnlockInput();
        onStarted?.Invoke();
    }



}
