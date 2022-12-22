using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Quest")]
public class Quest : ScriptableObject
{
    [TextArea()]
    public string Description;
    public Item WantedItem;
    public Item RewardItem;
    public int RewardMoney;
}
