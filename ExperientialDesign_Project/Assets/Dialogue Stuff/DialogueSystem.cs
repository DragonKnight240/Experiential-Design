using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueSystem : MonoBehaviour
{
    [System.Serializable]
    public struct cutsceneKarma
    {
        public List<Dialogue> script;
        public List<Dialogue> LowKarma;
        public int KarmaNeededLow;
        public List<Dialogue> HighKarma;
        public int KarmaNeededHigh;
        public List<Dialogue> NeutralKarma;
    }

    [System.Serializable]
    public struct cutsceneCharacterOpinion
    {
        public List<Dialogue> script;
        public List<Dialogue> LowOpinion;
        public int OpinionNeededLow;
        public List<Dialogue> HighOpinion;
        public int OpinionNeededHigh;
        public List<Dialogue> Neutral;
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

    public List<cutsceneKarma> CutscenesKarma;
    public List<cutsceneCharacterOpinion> CutscenesCharacter;
    internal Dialogue currentDialogue;
    int currentCutsceneID = 0;
    DialogueTree CurrentTreeStat;
    DialogueTreeTypes CurrentTreeType;
    //public AudioSource voiceOverSource;

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
    }

    public void updateDialogue(int cutsceneID, DialogueTreeTypes TreeType, Character NPC = null)
    {
        CurrentTreeType = TreeType;
        WhichTreeToFollow(cutsceneID, NPC);
        currentCutsceneID = cutsceneID;

    }

    public void WhichTreeToFollow(int cutsceneID, Character NPC)
    {
        switch (CurrentTreeType)
        {
            case DialogueTreeTypes.Karma:
                {
                    if (CutscenesKarma[cutsceneID].KarmaNeededLow > GameManager.Instance_.GetKarma())
                    {
                        CurrentTreeStat = DialogueTree.Low;
                    }
                    else if (CutscenesKarma[cutsceneID].KarmaNeededHigh < GameManager.Instance_.GetKarma())
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
                    if (CutscenesCharacter[cutsceneID].OpinionNeededLow > NPC.GetOpinionOfPlayer())
                    {
                        CurrentTreeStat = DialogueTree.Low;
                    }
                    else if (CutscenesCharacter[cutsceneID].OpinionNeededHigh < NPC.GetOpinionOfPlayer())
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
