using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnDialogueSound : OnDialogueLine
{
    public AudioClip SFXClip;
    public AudioSource SFXSource;

    public override void CorrectDialoguePlaying(bool Active)
    {
        if (Active)
        {
            SoundManager.Instance.SpawnSFX(SFXClip);
        }
        else
        {
            SFXSource.Stop();
        }
        Destroy(this);
    }
}
