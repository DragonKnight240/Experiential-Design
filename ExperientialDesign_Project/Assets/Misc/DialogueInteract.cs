using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueInteract : Interactable
{
    public int DialogueID;

    public override void interactWith()
    {
        Time.timeScale = 0;
        DialogueSystem.Instance.CurrentDialogueMax = DialogueSystem.Instance.Cutscenes[DialogueID].script.Count;
        DialogueSystem.Instance.CurrentDialogueID = 0;
        DialogueSystem.Instance.TWEffect.CurrentCutsceneID = DialogueID;
        DialogueSystem.Instance.updateDialogue(DialogueID);
        DialogueSystem.Instance.updateDialogue(DialogueID);
    }
}
