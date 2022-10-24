using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TypeWriterEffect : MonoBehaviour
{
    public GameObject UIPanel;
    Text textComponent;
    public float waitSecondsText = 0.2f;
    bool Finished = false;

    AudioSource clip;


    // Start is called before the first frame update
    void Start()
    {
        clip = GetComponent<AudioSource>();
        textComponent = GetComponentInChildren<Text>();
        textComponent.text = "";
    }

    public void playIenumerator()
    {
        if (!clip.isPlaying)
        {
            //clip.Play();
            StartCoroutine("Play");
        }
    }

    IEnumerator Play()
    {
        textComponent.text = " ";
        foreach (char i in DialogueSystem.Instance.currentDialogue.Script)
        {
            textComponent.text += i;
            yield return new WaitForSeconds(waitSecondsText);
        }

    }

    void OnPress()
    {
        if(Input.GetButtonDown("Fire1") && UIPanel.activeInHierarchy && !Finished)
        {
            textComponent.text = DialogueSystem.Instance.currentDialogue.Script;
        }
    }
}
