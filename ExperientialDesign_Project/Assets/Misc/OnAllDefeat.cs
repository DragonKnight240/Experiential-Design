using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnAllDefeat : MonoBehaviour
{
    public List<Enemy> EnemiesToDefeat;
    public int CutsceneID;
    public Character NPC;
    public Choice NeededChoice;
    internal bool CanActivite = false;

    // Update is called once per frame
    void Update()
    {
        if(NeededChoice)
        {
            if(DialogueSystem.Instance.LastChoosen == NeededChoice)
            {
                CanActivite = true;
            }
            else
            {
                CanActivite = false;
            }
        }
        else
        {
            CanActivite = true;
        }

        if(EnemiesToDefeat.Count <= 0 && CanActivite && !DialogueSystem.Instance.TWEffect.InUse)
        {
            Time.timeScale = 0;
            DialogueSystem.Instance.CurrentDialogueMax = DialogueSystem.Instance.Cutscenes[CutsceneID].script.Count;
            DialogueSystem.Instance.CurrentDialogueID = 0;
            DialogueSystem.Instance.TWEffect.CurrentCutsceneID = CutsceneID;
            DialogueSystem.Instance.updateDialogue(CutsceneID, NPC);

            Destroy(this);
        }
    }
}
