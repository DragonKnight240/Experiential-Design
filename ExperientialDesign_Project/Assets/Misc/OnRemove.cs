using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnRemove : MonoBehaviour
{
    public int CutsceneID = 0;
    public int DialogueID = 0;
    public Choice choice;
    public bool remove = true;

    // Start is called before the first frame update
    public void OnRemoveItem()
    {
        if (remove)
        {
            DialogueSystem.Instance.Cutscenes[CutsceneID].script[DialogueID].Choices.Remove(choice);
        }
        else
        {
            DialogueSystem.Instance.Cutscenes[CutsceneID].script[DialogueID].Choices.Add(choice);
        }
    }

    private void OnDestroy()
    {
        if (!remove)
        {
            DialogueSystem.Instance.Cutscenes[CutsceneID].script[DialogueID].Choices.Remove(choice);
        }
    }
}
