using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnDialogueAnim : OnDialogueLine
{
    public Animator Anim;
    public string TriggerNameTo;

    // Start is called before the first frame update
    void Start()
    {
        if (!Anim)
        {
            Anim = GetComponent<Animator>();
        }
    }

    public override void CorrectDialoguePlaying(bool Active)
    {
        Anim.SetTrigger(TriggerNameTo);
    }
}
