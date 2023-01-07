using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestTracker : MonoBehaviour
{
    internal List<Quest> AllQuestsinZone;
    public ItemInteract NewItem;

    // Start is called before the first frame update
    void Start()
    {
        Character[] characters =FindObjectsOfType<Character>();
        AllQuestsinZone = new List<Quest>();

        foreach(Character Chara in characters)
        {
            if(Chara.GivenQuest)
            {
                AllQuestsinZone.Add(Chara.GivenQuest);
            }
        }
    }

    private void Update()
    {
        if(AllQuestsinZone.Count == 0)
        {
            NewItem.CanInteract = true;
            Destroy(this);
        }
    }

    public void CompletedQuest(Quest Quest)
    {
        AllQuestsinZone.Remove(Quest);
    }
}
