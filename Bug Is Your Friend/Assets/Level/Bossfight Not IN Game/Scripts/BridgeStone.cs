using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BridgeStone : MonoBehaviour
{
    public ParticleSystem particleSystem;
    public SpriteRenderer spriteRenderer;

    private void Start()
    {
        spriteRenderer  = gameObject.GetComponent<SpriteRenderer>();
    }

    public void DestroyStone(float destroyTime)
    {
        StartCoroutine(Destroy(destroyTime));
    }

    IEnumerator Destroy(float destroyTime)
    {
        yield return new WaitForSeconds(destroyTime);
        spriteRenderer.enabled = false;
        if (particleSystem != null)
        {
            particleSystem.Play();
        }
    }

}
