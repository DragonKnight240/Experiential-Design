using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{

    public bool CanInteract = true;
    public ParticleSystem Particles;

    private void Start()
    {
        Particles = GetComponentInChildren<ParticleSystem>();
    }

    private void Update()
    {
        if(CanInteract && !Particles.isPlaying)
        {
            Particles.Play();
        }
        else if(!CanInteract)
        {
            Particles.Stop();
        }
        
    }

    private void OnMouseEnter()
    {
        if (CanInteract)
        {
            DialogueSystem.Instance.TWEffect.Mouse.SetActive(true);
        }
    }

    private void OnMouseExit()
    {
        if (CanInteract)
        {
            DialogueSystem.Instance.TWEffect.Mouse.SetActive(false);
        }
    }

    public virtual void interactWith()
    {

    }
}
