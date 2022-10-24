using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Dialogue")]
public class Dialogue : ScriptableObject
{
    public string Speaker;
    [TextArea()]
    public string Script;
    public bool Repeatable;
    public int branch;

}
