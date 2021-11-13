using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardAnimatorControler : MonoBehaviour
{
    public Animator animator;

    public void subscribeToGameEvents()
    {
       GameEvents.current.StratCardFlipAni += FlipAni;
       GameEvents.current.StratCardCoverUpAni += CoverUpAni;
       GameEvents.current.StartRemoveAni += RemoveCardAni;
    }

    

    void FlipAni()
    {
        Debug.Log("Flip");        
        animator.SetBool("Reval",true);
        animator.SetBool("CoverUp", false);
        GameEvents.current.StratCardFlipAni -= FlipAni;
    }

    public void CoverUpAni()
    {      
        Debug.Log("Cover Up");
        animator.SetBool("CoverUp", true);
        animator.SetBool("Reval", false);
        GameEvents.current.StratCardCoverUpAni -= CoverUpAni;
        GameEvents.current.StartRemoveAni -= RemoveCardAni;
    }

    public void RemoveCardAni()
    {
        animator.SetBool("Remove", true);
        GameEvents.current.StartRemoveAni -= RemoveCardAni;
    }

}
