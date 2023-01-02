using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroy : MonoBehaviour
{
    internal static DontDestroy UIMain;
    internal DialogueSystem DialogueLog;
    internal GameObject Inventory;
    internal GameObject OutofRangeUI;

    // Start is called before the first frame update
    void Start()
    {
        if(UIMain != null)
        {

            DialogueSystem.Instance.Cutscenes = GetComponentInChildren<DialogueSystem>().Cutscenes;

            Destroy(this.gameObject);
        }
        else
        {
            UIMain = this;
            OutofRangeUI = FindObjectOfType<Interact>().OutOfRangeUI;
        }

        DontDestroyOnLoad(this.gameObject);
    }
}
