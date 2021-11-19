using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionChecker : MonoBehaviour
{



    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.tag == "Obstacle")
        {
            Debug.Log("SpielVorbei");
            MoveCubeGameManager.events.PLayerIStDeath();
        }
        else
        {
            Debug.Log("Funcktioniert");
        }
    }
}
