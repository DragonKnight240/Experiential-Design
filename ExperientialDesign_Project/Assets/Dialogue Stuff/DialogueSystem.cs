using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    internal Dialogue currentDialogue;
    internal int CurrentDialogueID;
    internal int CurrentDialogueMax = 0;
    int currentCutsceneID = 0;
    internal DialogueTree CurrentTreeStat;
    DialogueTreeTypes CurrentTreeType;
    internal TypeWriterEffect TWEffect;

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

    public void updateDialogue(int cutsceneID, DialogueTreeTypes TreeType, Character NPC = null)
    {
        CurrentTreeType = Cutscenes[currentCutsceneID].script[CurrentDialogueID].Type;
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
}
