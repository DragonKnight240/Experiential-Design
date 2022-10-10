using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Weapon")]
public class Weapons : ScriptableObject
{
    public string Name;
    public int Damage;
    public float AttackSpeed;

    [TextArea()]
    public string Description;

}
