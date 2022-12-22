using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public int StartingOpinion = 0;
    internal int OpinionOfPlayer;
    internal int PlayersOpinion = 0;
    public Quest GivenQuest;
    public int IDCutscene;

    // Start is called before the first frame update
    void Start()
    {
        OpinionOfPlayer = StartingOpinion;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void InteractWith()
    {
        DialogueSystem.Instance.updateDialogue(IDCutscene, this);
    }

    public int GetOpinionOfPlayer()
    {
        return OpinionOfPlayer;
    }

    public int GetPlayerOpinion()
    {
        return PlayersOpinion;
    }
}
