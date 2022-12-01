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
            DialogueSystem.Instance.updateDialogue(cutsceneID,Type);
        }
    }
}
