using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemInteract : Interactable
{
    public Item ItemPickup;
    public Item RemoveItem;
    public bool HideOnInteract;

    public override void interactWith()
    {
        if(RemoveItem)
        {
            if(!Inventory.Instance.isInInventory(RemoveItem))
            {
                print("Return");
                return;
            }
        }

        if (CanInteract)
        {
            if(RemoveItem)
            {
                if(Inventory.Instance.isInInventory(RemoveItem))
                {
                    Inventory.Instance.RemoveFromInventory(RemoveItem);
                }
                else
                {
                    return;
                }
            }
            Inventory.Instance.AddToInventory(ItemPickup);

            if(HideOnInteract)
            {
                //fade
                gameObject.SetActive(false);
            }

            CanInteract = false;

            if(GetComponent<OnAddItem>())
            {
                GetComponent<OnAddItem>().OnAdd();
            }
        }
    }
}
