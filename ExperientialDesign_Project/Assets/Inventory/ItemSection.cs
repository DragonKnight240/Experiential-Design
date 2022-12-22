using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ItemSection : MonoBehaviour
{
    Inventory Inventory;
    internal Item item;
    public TextMeshProUGUI ItemNameText;

    private void Start()
    {
        Inventory = FindObjectOfType<Inventory>();
    }

    private void Update()
    {
        if(ItemNameText.text != item.name)
        {
            ItemNameText.text = item.name;
        }
    }

    private void OnMouseEnter()
    {
        Inventory.DescriptionText.text = item.Description;
        Inventory.DescriptionPanel.SetActive(true);
    }

    private void OnMouseExit()
    {
        Inventory.DescriptionPanel.SetActive(false);
    }

    void UseItem()
    {
        
    }
}
