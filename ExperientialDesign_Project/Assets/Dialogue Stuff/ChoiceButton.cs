using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChoiceButton : MonoBehaviour
{
    public Choice choice;
    internal Character NPCTalkingTo;

    public void OnChoose()
    {
        if(choice.ItemRecieved != null)
        {
            Inventory.Instance.AddToInventory(choice.ItemRecieved);
        }

        if(choice.ItemTaken != null)
        {
            Inventory.Instance.RemoveFromInventory(choice.ItemTaken);
        }

        if(choice.MoneyRecieved != 0)
        {
            GameManager.Instance_.increaseMoney(choice.MoneyRecieved);
        }

        if(choice.MoneyTaken != 0)
        {
            GameManager.Instance_.decreaseMoney(choice.MoneyTaken);
        }

        if(choice.CharacterImpact != 0)
        {
            NPCTalkingTo.OpinionOfPlayer += choice.CharacterImpact;
        }

        if(choice.KarmaImpact != 0)
        {
            GameManager.Instance_.increaseKarma(choice.KarmaImpact);
        }

        if(choice.NewDialogueID != -1)
        {
            Time.timeScale = 0;
            DialogueSystem.Instance.CurrentDialogueMax = DialogueSystem.Instance.Cutscenes[choice.NewDialogueID].script.Count;
            DialogueSystem.Instance.CurrentDialogueID = 0;
            DialogueSystem.Instance.TWEffect.CurrentCutsceneID = choice.NewDialogueID;
            DialogueSystem.Instance.updateDialogue(choice.NewDialogueID);
        }

        DialogueSystem.Instance.Choosen();
    }
}
