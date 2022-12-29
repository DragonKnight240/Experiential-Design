using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public int StartingOpinion = 0;
    internal int OpinionOfPlayer = 0;
    internal int PlayersOpinion = 0;
    public Quest GivenQuest;
    internal bool isQuestCompleted = false;
    public int CutsceneID;
    internal int DefaultCutsceneID;
    internal bool QuestGiven = false;
    bool CanInteract = true;

    // Start is called before the first frame update
    void Start()
    {
        DefaultCutsceneID = CutsceneID;
        OpinionOfPlayer = StartingOpinion;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void InteractWith()
    {
        if(!CanInteract)
        {
            return;
        }

        if (GivenQuest)
        {
            if (QuestGiven)
            {
                if (isQuestComplete() && !isQuestCompleted)
                {
                    CutsceneID = GivenQuest.CompleteDialogueID;
                    PlayDialogue();
                    isQuestCompleted = true;
                    
                }
                else
                {
                    CutsceneID = GivenQuest.IncompleteID;
                    PlayDialogue();
                }
            }
            else
            {
                CutsceneID = DefaultCutsceneID;
                PlayDialogue();
                QuestGiven = true;
                StartQuest();
            }
        }
        else
        {
            CutsceneID = DefaultCutsceneID;
            PlayDialogue();
        }
    }

    void PlayDialogue()
    {
        Time.timeScale = 0;
        DialogueSystem.Instance.CurrentDialogueMax = DialogueSystem.Instance.Cutscenes[CutsceneID].script.Count;
        DialogueSystem.Instance.CurrentDialogueID = 0;
        DialogueSystem.Instance.TWEffect.CurrentCutsceneID = CutsceneID;
        DialogueSystem.Instance.CurrentNPC = this;
        DialogueSystem.Instance.updateDialogue(CutsceneID);
    }

    public int GetOpinionOfPlayer()
    {
        return OpinionOfPlayer;
    }

    public int GetPlayerOpinion()
    {
        return PlayersOpinion;
    }

    public bool isQuestComplete()
    {
        if (Inventory.Instance.isInInventory(GivenQuest.WantedItem))
        {
            Inventory.Instance.RemoveFromInventory(GivenQuest.WantedItem);
            QuestCompleted();
            return true;
        }

        return false;
    }

    public void StartQuest()
    {
        if(GivenQuest.GivenItem)
        {
            Inventory.Instance.AddToInventory(GivenQuest.GivenItem);
        }

        if (GivenQuest.AddedChoice)
        {
            DialogueSystem.Instance.Cutscenes[0].script[0].Choices.Add(GivenQuest.AddedChoice);
        }
    }

    public void QuestCompleted()
    {
        if (GivenQuest.RewardMoney != 0)
        {
            GameManager.Instance_.increaseMoney(GivenQuest.RewardMoney);
        }

        if (GivenQuest.RewardItem)
        {
            Inventory.Instance.AddToInventory(GivenQuest.RewardItem);
        }

        CutsceneID = GivenQuest.CompleteDialogueID;
    }
}
