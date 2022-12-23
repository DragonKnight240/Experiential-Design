using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartDialogue : MonoBehaviour
{
    public int cutsceneID = 0;

    private void Update()
    {
        if(DialogueSystem.Instance)
        {
            CallDialogue();
            Destroy(this);
        }
    }

    void CallDialogue()
    {
        Time.timeScale = 0;
        DialogueSystem.Instance.CurrentDialogueMax = DialogueSystem.Instance.Cutscenes[cutsceneID].script.Count;
        DialogueSystem.Instance.CurrentDialogueID = 0;
        DialogueSystem.Instance.TWEffect.CurrentCutsceneID = cutsceneID;
        DialogueSystem.Instance.updateDialogue(cutsceneID);
    }
}
