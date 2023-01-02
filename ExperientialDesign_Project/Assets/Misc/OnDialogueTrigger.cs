using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnDialogueTrigger : OnDialogueLine
{
    DialogueTrigger Trigger;

    private void Start()
    {
        Trigger = GetComponent<DialogueTrigger>();
    }

    public override void CorrectDialoguePlaying(bool Active)
    {
        Trigger.CanActive = Active;
    }
}
