using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interact : MonoBehaviour
{
    internal bool Active = true;

    private void Update()
    {
        if(DialogueSystem.Instance.TWEffect.UIPanel.activeInHierarchy || Inventory.Instance.InventoryPanel.activeInHierarchy)
        {
            Active = false;
        }
        else
        {
            Active = true;
        }

        if(Input.GetKeyDown(KeyCode.Mouse0) && Active)
        {
            RaycastHit Hit;

            if(Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out Hit))
            {
                if(Hit.transform.CompareTag("Character"))
                {
                    Hit.transform.GetComponent<Character>().InteractWith();
                }
                else if(Hit.transform.CompareTag("Interactable"))
                {
                    Hit.transform.GetComponent<Interactable>().interactWith();
                }
            }

            print(Hit.collider.gameObject.name);
        }
    }
}
