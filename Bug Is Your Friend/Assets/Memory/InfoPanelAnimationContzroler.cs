using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfoPanelAnimationContzroler : MonoBehaviour
{
    public Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        MemoryGameEvents.current.startInfoPanelAni += StartInfoPanelAni;
    }

    void StartInfoPanelAni()
    {

        animator.SetBool("Start", true);

        /*
        bool curentAnimatorState = animator.GetBool("Start");

        if (curentAnimatorState)
        {
            animator.SetBool("Start", false);
            animator.SetBool("Start", true);
        }
        else
        {
            animator.SetBool("Start", true);
        }
        */
    }



}
