using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardAnimatorControler : MonoBehaviour
{
    public Animator animator;

    public void subscribeToGameEvents()
    {
       MemoryGameEvents.current.StratCardFlipAni += FlipAni;
       MemoryGameEvents.current.StratCardCoverUpAni += CoverUpAni;
       MemoryGameEvents.current.StartRemoveAni += RemoveCardAni;
    }


    void FlipAni()
    {
        Debug.Log("Flip");        
        animator.SetBool("Reval",true);
        animator.SetBool("CoverUp", false);
        MemoryGameEvents.current.StratCardFlipAni -= FlipAni;
    }

    public void CoverUpAni()
    {
        
        Debug.Log("Cover Up");
        animator.SetBool("CoverUp", true);
        animator.SetBool("Reval", false);
        MemoryGameEvents.current.StratCardCoverUpAni -= CoverUpAni;
        MemoryGameEvents.current.StartRemoveAni -= RemoveCardAni;      
    }

    public void RemoveCardAni()
    {
        animator.SetBool("Remove", true);
        MemoryGameEvents.current.StartRemoveAni -= RemoveCardAni;
    }

}
