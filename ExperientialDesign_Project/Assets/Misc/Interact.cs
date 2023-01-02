using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interact : MonoBehaviour
{
    internal bool Active = true;
    public GameObject OutOfRangeUI;
    float OutOfRangeTimer = 0;
    public float OutOfRangeMax = 2;
    public float MaxDistance = 20;

    private void Start()
    {
        //if (DontDestroy.UIMain != null)
        //{
        //    OutOfRangeUI = DontDestroy.UIMain.OutofRangeUI;
        //}
    }

    private void Update()
    {
        if (OutOfRangeUI.activeInHierarchy)
        {
            OutOfRangeTimer += Time.unscaledDeltaTime;

            if (OutOfRangeTimer >= OutOfRangeMax)
            {
                OutOfRangeTimer = 0;
                OutOfRangeUI.SetActive(false);
            }
        }

        if (DialogueSystem.Instance.TWEffect.UIPanel.activeInHierarchy || Inventory.Instance.InventoryPanel.activeInHierarchy)
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
                if (Hit.transform.CompareTag("Character"))
                {
                    if (TargetInRange(Hit))
                    {
                        Hit.transform.GetComponent<Character>().InteractWith();
                    }
                }
                else if (Hit.transform.CompareTag("Interactable"))
                {
                    if (TargetInRange(Hit))
                    {
                        Hit.transform.GetComponent<Interactable>().interactWith();
                    }
                }
            }

            print(Hit.collider.gameObject.name);
        }
    }

    bool TargetInRange(RaycastHit Hit)
    {
        if (Vector3.Distance(Hit.point, transform.position) >= MaxDistance)
        {
            
            OutOfRangeTimer = 0;
            OutOfRangeUI.SetActive(true);
            return false;
        }

        return true;
    }
}
