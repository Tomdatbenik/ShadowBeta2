using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaunchConfetti : MonoBehaviour
{
    public List<ParticleSystem> particles;
    public Interactable interactable;

    public void ShootConfetti()
    {
        interactable.DisableInteractable();
        foreach(ParticleSystem system in particles)
        {
            system.Play();
        }
    }
}
