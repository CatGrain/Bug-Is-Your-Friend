using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerParticelControler : MonoBehaviour
{
    public ParticleSystem particleSystem;
    public void PlayParticle()
    {
        particleSystem.Play();
    }
}
