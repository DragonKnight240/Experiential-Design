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
        if (!DialogueSystem.Instance.TWEffect.UIPanel.activeInHierarchy || !Inventory.Instance.InventoryPanel.activeInHierarchy || !FindObjectOfType<Options>().gameObject.activeInHierarchy)
        {
            if (CanInteract)
            {
                DialogueSystem.Instance.TWEffect.Mouse.SetActive(true);
            }
        }
    }

    private void OnMouseExit()
    {
        if (!DialogueSystem.Instance.TWEffect.UIPanel.activeInHierarchy)
        {
            DialogueSystem.Instance.TWEffect.Mouse.SetActive(false);
        }
    }

    public virtual void interactWith()
    {

    }
}
