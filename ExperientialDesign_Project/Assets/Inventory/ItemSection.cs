using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

public class ItemSection : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
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
        if(ItemNameText.text != item.Name)
        {
            ItemNameText.text = item.Name;
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        Inventory.DescriptionText.text = item.Description;
        Inventory.DescriptionPanel.SetActive(true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Inventory.DescriptionPanel.SetActive(false);
    }

    void UseItem()
    {
        
    }
}
