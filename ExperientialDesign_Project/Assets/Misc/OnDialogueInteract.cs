using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnDialogueInteract : OnDialogueLine
{
    internal Interactable ActiveInteractable;

    // Start is called before the first frame update
    void Start()
    {
        ActiveInteractable = GetComponent<Interactable>();
    }

    public override void CorrectDialoguePlaying(bool Active)
    {
        ActiveInteractable.CanInteract = Active;
    }
}
