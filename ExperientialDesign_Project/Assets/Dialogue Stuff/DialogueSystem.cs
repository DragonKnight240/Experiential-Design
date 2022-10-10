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

    public static DialogueSystem Instance;

    public List<cutscene> Cutscenes;
    internal Dialogue currentDialogue;
    int currentCutsceneID = 0;
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

    public void updateDialogue(int cutsceneID)
    {
        currentCutsceneID = cutsceneID;
    }
}
