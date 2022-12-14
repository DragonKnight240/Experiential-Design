using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using static DialogueSystem;

public class TypeWriterEffect : MonoBehaviour
{
    public GameObject UIPanel;
    TextMeshProUGUI textComponent;
    public float waitSecondsText = 0.2f;
    bool Finished = false;
    float timer = 0;
    string dialogue = "";
    int CharNum = 0;
    int CharNumMax;
    bool InUse = false;
    internal DialogueTrigger CurrentTrigger;
    public GameObject SelfSpeaker;
    public GameObject OtherSpeaker;
    public GameObject TextUIPanel;

    // Start is called before the first frame update
    void Start()
    {
        textComponent = TextUIPanel.GetComponentInChildren<TextMeshProUGUI>();
        textComponent.text = "";
    }

    private void Update()
    {
        if(InUse)
        {
            timer += Time.unscaledDeltaTime;
            if (!Finished)
            {
                NextLetter();
            }
            OnPress();
        }
    }

    public void NewDialogue()
    {
        textComponent.text = " ";

        switch (DialogueSystem.Instance.CurrentTreeStat)
        {
            case DialogueTree.High:
                dialogue = DialogueSystem.Instance.currentDialogue.ScriptHigh;
                break;
            case DialogueTree.Neutral:
                dialogue = DialogueSystem.Instance.currentDialogue.Script;
                break;
            case DialogueTree.Low:
                dialogue = DialogueSystem.Instance.currentDialogue.ScriptLow;
                break;
            case DialogueTree.None:
                dialogue = DialogueSystem.Instance.currentDialogue.Script;
                break;
            default:
                dialogue = DialogueSystem.Instance.currentDialogue.Script;
                break;
        }

        if(DialogueSystem.Instance.currentDialogue.Speaker != "Rin" || DialogueSystem.Instance.currentDialogue.Speaker != "Allen")
        {
            OtherSpeaker.GetComponentInChildren<TextMeshProUGUI>().text = DialogueSystem.Instance.currentDialogue.Speaker;
            OtherSpeaker.SetActive(true);
            SelfSpeaker.SetActive(false);
        }
        else
        {
            SelfSpeaker.GetComponentInChildren<TextMeshProUGUI>().text = DialogueSystem.Instance.currentDialogue.Speaker;
            OtherSpeaker.SetActive(false);
            SelfSpeaker.SetActive(true);
        }

        CharNumMax = dialogue.Length;
        CharNum = 0;
        InUse = true;
        UIPanel.SetActive(true);
    }

    void NextLetter()
    {
        if (timer >= waitSecondsText)
        {
            textComponent.text += dialogue[CharNum];
            CharNum++;
            if(CharNum >= CharNumMax)
            {
                Finished = true;
                CharNum = 0;
            }
            timer = 0;
        }
    }

    void OnPress()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            if (UIPanel.activeInHierarchy && InUse && Finished)
            {
                CheckDialogue();
            }
            else
            {
                for (int i = CharNum; i < CharNumMax; i++)
                {
                    textComponent.text += dialogue[i];
                }

                Finished = true;
                CharNum = 0;
                timer = 0;
            }
        }
    }

    void CheckDialogue()
    {
        if (DialogueSystem.Instance.CurrentDialogueID++ >= DialogueSystem.Instance.CurrentDialogueMax)
        {
            Finished = false;
            CharNum = 0;
            InUse = false;
            UIPanel.SetActive(false);
            Time.timeScale = 1;
        }
        else
        {
            Finished = false;
            CharNum = 0;
            timer = 0;
            DialogueSystem.Instance.updateDialogue(CurrentTrigger.cutsceneID, CurrentTrigger.Type);
        }
    }
}
