using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaunchConfetti : MonoBehaviour
{
    public List<ParticleSystem> particles;
    public Interactable interactable;

    private void Update()
    {
        particles[0].transform.position = Camera.main.ViewportToWorldPoint(new Vector3(1f, 0f, 0f));
        particles[1].transform.position = Camera.main.ViewportToWorldPoint(new Vector3(0f, 0f, 0f));
    }

    public void ShootConfetti()
    {
        interactable.DisableInteractable();
        foreach(ParticleSystem system in particles)
        {
            system.Play();
        }
    }

    public void ShootConfettiLoose()
    {
        foreach (ParticleSystem system in particles)
        {
            system.Play();
        }
    }
}
