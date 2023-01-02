using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnDialogueCamera : OnDialogueLine
{
    public GameObject NewLocation;
    public CameraFollow Follow;

    // Start is called before the first frame update
    void Start()
    {
        Follow = FindObjectOfType<CameraFollow>();
    }

    public override void CorrectDialoguePlaying(bool Active)
    {
        Follow.SetNewPosition(NewLocation);
        Follow.Follow = !Active;
    }
}
