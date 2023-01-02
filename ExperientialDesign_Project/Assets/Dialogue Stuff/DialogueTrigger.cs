using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public int cutsceneID;
    public Character NPC;
    public bool destory = true;
    public bool CanActive = true;

    private void OnTriggerEnter(Collider other)
    {
        if(!CanActive)
        {
            return;
        }

        if (other.CompareTag("Player"))
        {
            Time.timeScale = 0;
            DialogueSystem.Instance.CurrentDialogueMax = DialogueSystem.Instance.Cutscenes[cutsceneID].script.Count;
            DialogueSystem.Instance.CurrentDialogueID = 0;
            DialogueSystem.Instance.TWEffect.CurrentCutsceneID = cutsceneID;
            DialogueSystem.Instance.updateDialogue(cutsceneID, NPC);

            if (GetComponent<OnRemove>())
            {
                GetComponent<OnRemove>().OnRemoveItem();
            }

            if (destory)
            {
                Destroy(this.gameObject);
            }
        }
    }
}
