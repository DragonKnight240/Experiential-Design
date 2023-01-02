using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnDialogueAnim : OnDialogueLine
{
    internal Animator Anim;
    public string TriggerNameTo;

    // Start is called before the first frame update
    void Start()
    {
        Anim = GetComponent<Animator>();
    }

    public override void CorrectDialoguePlaying(bool Active)
    {
        Anim.SetTrigger(TriggerNameTo);
    }
}
