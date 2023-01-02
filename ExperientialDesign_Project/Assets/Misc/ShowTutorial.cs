using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowTutorial : MonoBehaviour
{
    public GameObject UIPanel;

    private void Update()
    {
        if(Inventory.Instance.NewItemUI.activeInHierarchy)
        {
            UIPanel.SetActive(true);
        }
        else
        {
            UIPanel.SetActive(false);
        }
    }
}
