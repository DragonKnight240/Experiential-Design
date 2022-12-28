using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnDialogueLine : MonoBehaviour
{
    public Dialogue DialoguePlayingActive;
    public Dialogue DialogueDeactive;
    internal bool HasFaded = false;
    internal Fade fade;


    // Start is called before the first frame update
    void Start()
    {
        fade = FindObjectOfType<Fade>();
    }

    // Update is called once per frame
    public void Update()
    {
        if (DialoguePlayingActive)
        {
            if (DialogueSystem.Instance.currentDialogue == DialoguePlayingActive)
            {
                CorrectDialoguePlaying(true);
            }
        }

        if (DialogueDeactive)
        {
            if (DialogueSystem.Instance.currentDialogue == DialogueDeactive)
            {
                CorrectDialoguePlaying(false);
            }
        }
    }

    public virtual void CorrectDialoguePlaying(bool Active)
    {
    }
}
