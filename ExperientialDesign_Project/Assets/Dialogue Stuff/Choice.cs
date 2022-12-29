using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Choice")]
public class Choice : ScriptableObject
{

    public string Description;
    public int KarmaImpact;
    public int CharacterImpact;
    public Item ItemRecieved;
    public Item ItemTaken;
    public int MoneyRecieved;
    public int MoneyTaken;
    public int NewDialogueID = -1;
    public bool RemoveOnChoose = false;
}
