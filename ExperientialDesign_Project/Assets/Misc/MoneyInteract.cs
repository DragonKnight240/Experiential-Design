using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyInteract : Interactable
{
    public int MoneyPickedUp;

    public override void interactWith()
    {
        GameManager.Instance_.increaseMoney(MoneyPickedUp);
    }
}
