using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionChecker : MonoBehaviour
{

    bool hasColision = true;
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (hasColision && collision.collider.tag == "Obstacle")
        {
            hasColision = false;
            Debug.Log("SpielVorbei");
            MoveCubeGameManager.events.PLayerIStDeath();
        }      
    }
}
