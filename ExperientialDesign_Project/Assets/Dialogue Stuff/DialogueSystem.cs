using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueSystem : MonoBehaviour
{
    [System.Serializable]
    public struct cutscene
    {
        public List<Dialogue> script;
    }

    [System.Serializable]
    public enum DialogueTree
    {
        High,
        Neutral,
        Low,
        None
    }

    [System.Serializable]
    public enum DialogueTreeTypes
    {
        Karma,
        CharacterOpinion,
        None
    }

    public static DialogueSystem Instance;

    public List<cutscene> Cutscenes;
    public GameObject ChoiceButtonPrefab;
    public GameObject ChoicePanel;
    internal Dialogue currentDialogue;
    internal int CurrentDialogueID;
    internal int CurrentDialogueMax = 0;
    int currentCutsceneID = 0;
    internal DialogueTree CurrentTreeStat;
    DialogueTreeTypes CurrentTreeType;
    internal TypeWriterEffect TWEffect;
    internal Character CurrentNPC;

    private void Start()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this);
        }

        TWEffect = GetComponent<TypeWriterEffect>();
    }

    public void updateDialogue(int cutsceneID, Character NPC = null)
    {
        CurrentTreeType = Cutscenes[currentCutsceneID].script[CurrentDialogueID].Type;
        CurrentNPC = NPC;
        WhichTreeToFollow(cutsceneID, NPC);
        currentCutsceneID = cutsceneID;

        currentDialogue = Cutscenes[currentCutsceneID].script[CurrentDialogueID];

        TWEffect.NewDialogue();
    }

    public void WhichTreeToFollow(int cutsceneID, Character NPC)
    {
        switch (CurrentTreeType)
        {
            case DialogueTreeTypes.Karma:
                {
                    if (Cutscenes[cutsceneID].script[CurrentDialogueID].LowValue > GameManager.Instance_.GetKarma())
                    {
                        CurrentTreeStat = DialogueTree.Low;
                    }
                    else if (Cutscenes[cutsceneID].script[CurrentDialogueID].HighValue < GameManager.Instance_.GetKarma())
                    {
                        CurrentTreeStat = DialogueTree.High;
                    }
                    else
                    {
                        CurrentTreeStat = DialogueTree.Neutral;
                    }

                    break;
                }
            case DialogueTreeTypes.CharacterOpinion:
                {
                    if (Cutscenes[cutsceneID].script[CurrentDialogueID].LowValue > NPC.GetOpinionOfPlayer())
                    {
                        CurrentTreeStat = DialogueTree.Low;
                    }
                    else if (Cutscenes[cutsceneID].script[CurrentDialogueID].HighValue < NPC.GetOpinionOfPlayer())
                    {
                        CurrentTreeStat = DialogueTree.High;
                    }
                    else
                    {
                        CurrentTreeStat = DialogueTree.Neutral;
                    }

                    break;
                }
            case DialogueTreeTypes.None:
                {
                    CurrentTreeType = DialogueTreeTypes.None;
                    break;
                }
        }
    }

    public void SetChoices()
    {
        foreach(Choice Choice in currentDialogue.Choices)
        {
            GameObject NewChoice = Instantiate(ChoiceButtonPrefab, ChoicePanel.transform.GetChild(0).transform);
            NewChoice.GetComponent<ChoiceButton>().choice = Choice;
            NewChoice.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = Choice.Description;
            NewChoice.GetComponent<ChoiceButton>().NPCTalkingTo = CurrentNPC;
        }

        ChoicePanel.SetActive(true);
    }

    public void Choosen()
    {
        ChoicePanel.SetActive(false);

        for (int i = 0; i < ChoicePanel.transform.GetChild(0).childCount; i++)
        {
            Destroy(ChoicePanel.transform.GetChild(0).GetChild(i));
        }
    }
}
