using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemInteract : Interactable
{
    public Item ItemPickup;

    public override void interactWith()
    {
        Inventory.Instance.AddToInventory(ItemPickup);
    }
}
