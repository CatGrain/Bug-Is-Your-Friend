using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PannelChanger : MonoBehaviour
{
    public UIManger uimanger;
    public Animator animator;
    public float transitionTime;

    public void SwitchPannell(int index)
    {
        StartCoroutine(ChangePannell(index));
    }

    IEnumerator ChangePannell(int index)
    {
        animator.SetTrigger("Start");
        yield return new WaitForSeconds(transitionTime);
        uimanger.ChangePannell(index);
        animator.SetTrigger("End");
    }
  
}
