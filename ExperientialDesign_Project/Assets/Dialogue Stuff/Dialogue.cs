using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Dialogue")]
public class Dialogue : ScriptableObject
{
    public DialogueSystem.DialogueTreeTypes Type;
    public string Speaker;
    [TextArea()]
    public string Script;
    [TextArea()]
    public string ScriptHigh;
    public int HighValue;
    [TextArea()]
    public string ScriptLow;
    public int LowValue;
    public bool Repeatable;
    public List<Choice> Choices;
}
