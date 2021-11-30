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
        animator.SetTrigger("Start");    
    }



}
