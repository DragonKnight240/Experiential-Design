using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemInteract : Interactable
{
    public Item ItemPickup;
    public Item RemoveItem;

    public override void interactWith()
    {
        if(RemoveItem)
        {
            if(!Inventory.Instance.isInInventory(RemoveItem))
            {
                return;
            }
        }

        if (CanInteract)
        {
            Inventory.Instance.AddToInventory(ItemPickup);
        }
    }
}
