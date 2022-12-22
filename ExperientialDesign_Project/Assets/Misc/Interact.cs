using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interact : MonoBehaviour
{
    private void Update()
    {
        if(Input.GetKeyDown("Interact"))
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
        }
    }
}
