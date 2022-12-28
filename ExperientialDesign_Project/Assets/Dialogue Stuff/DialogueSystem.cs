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
        PlayerOpinion,
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
    internal Choice LastChoosen;

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
        currentCutsceneID = cutsceneID;
        CurrentTreeType = Cutscenes[currentCutsceneID].script[CurrentDialogueID].Type;
        CurrentNPC = NPC;
        WhichTreeToFollow(cutsceneID, NPC);

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
            case DialogueTreeTypes.PlayerOpinion:
                {
                    if (Cutscenes[currentCutsceneID].script[CurrentDialogueID].LowValue > NPC.GetPlayerOpinion())
                    {
                        CurrentTreeStat = DialogueTree.Low;
                    }
                    else if(Cutscenes[currentCutsceneID].script[CurrentDialogueID].HighValue < NPC.GetPlayerOpinion())
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
                    CurrentTreeStat = DialogueTree.Neutral;
                    break;
                }
        }
    }

    public void SetChoices()
    {
        GameObject NewChoice;

        foreach (Choice Choice in currentDialogue.Choices)
        {
            NewChoice = Instantiate(ChoiceButtonPrefab, ChoicePanel.transform);
            NewChoice.GetComponent<ChoiceButton>().choice = Choice;
            NewChoice.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = Choice.Description;
            NewChoice.GetComponent<ChoiceButton>().NPCTalkingTo = CurrentNPC;
        }

        ChoicePanel.SetActive(true);
    }

    public void Choosen()
    {
        ChoicePanel.SetActive(false);

        foreach (Transform Child in ChoicePanel.transform)
        {
            Destroy(Child.gameObject);
        }

        DialogueSystem.Instance.TWEffect.NextDialogue();
    }
}
