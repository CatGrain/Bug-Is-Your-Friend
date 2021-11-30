using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetTriger : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        MoveCubeGameManager.events.PlayHasWonTheGame();
        Debug.Log("Spiel Gewnonnen");
    }


}
