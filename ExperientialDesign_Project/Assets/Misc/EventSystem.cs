using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EventSystem : MonoBehaviour
{
    [Serializable]
    public struct Flags
    {
        public string Name;
        public bool Completed;
    }

    [Serializable]
    public struct DialogueFlags
    {
        public Dialogue Name;
        public bool Completed;
    }

    public static EventSystem Instance;

    public List<Flags> DialogueFlag;
    public List<DialogueFlags> DialogueSpoken;

    public List<Flags> BackstoryFlag;

    public List<Flags> MainQuestFlag;

    // Start is called before the first frame update
    void Start()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this);
        }    

    }

}
