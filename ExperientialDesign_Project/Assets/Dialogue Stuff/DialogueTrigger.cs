using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public int cutsceneID;
    public DialogueSystem.DialogueTreeTypes Type;

    private void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            Time.timeScale = 0;
            DialogueSystem.Instance.CurrentDialogueMax = DialogueSystem.Instance.Cutscenes[cutsceneID].script.Count;
            DialogueSystem.Instance.CurrentDialogueID = 0;
            DialogueSystem.Instance.TWEffect.CurrentCutsceneID = cutsceneID;
            DialogueSystem.Instance.updateDialogue(cutsceneID);
        }
    }
}
