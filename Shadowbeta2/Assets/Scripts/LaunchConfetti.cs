using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaunchConfetti : MonoBehaviour
{
    public List<ParticleSystem> particles;

    public void ShootConfetti()
    {
        foreach(ParticleSystem system in particles)
        {
            system.Play();
        }
    }
}
