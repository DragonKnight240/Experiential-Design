using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Inventory : MonoBehaviour
{
    public float YOffset = 50;
    bool InventoryOpen = false;
    public GameObject InventoryPanel;
    public GameObject ItemSectionPrefab;
    public GameObject DescriptionPanel;
    public TextMeshProUGUI DescriptionText;
    public Dictionary<Item, GameObject> ItemDictionary;

    static internal Inventory Instance;

    // Start is called before the first frame update
    void Start()
    {
        if (Inventory.Instance != null)
        {
            Destroy(this.gameObject);
        }
        else
        {
            Inventory.Instance = this;
        }

        InventoryPanel.SetActive(false);
        ItemDictionary = new Dictionary<Item, GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.I))
        {
            ToggleInventory();
        }
    }

    public void AddToInventory(Item newItem)
    {
        Transform NewPosition = InventoryPanel.transform.GetChild(0);
        GameObject NewSection = Instantiate(ItemSectionPrefab, NewPosition.transform);
        float Width = ItemSectionPrefab.GetComponent<RectTransform>().sizeDelta.y;
        NewSection.transform.position = new Vector3(NewPosition.transform.position.x, NewPosition.transform.position.y - (Width * (ItemDictionary.Count - 1)) - YOffset, NewPosition.transform.position.z);
        NewSection.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = newItem.Name;
        ItemDictionary.Add(newItem, NewSection);
        NewSection.GetComponent<ItemSection>().item = newItem;
    }

    public void RemoveFromInventory(Item oldItem)
    {
        Destroy(ItemDictionary[oldItem]);
        ItemDictionary.Remove(oldItem);

        Vector3 NewPosition = InventoryPanel.transform.GetChild(0).transform.position;
        NewPosition = new Vector3(NewPosition.x, 0, NewPosition.z);
        float Width = ItemSectionPrefab.GetComponent<RectTransform>().sizeDelta.y;
        int DictionaryPairNo = 0;

        foreach (KeyValuePair<Item, GameObject> ItemPair in ItemDictionary)
        {
            ItemPair.Value.transform.position = new Vector3(transform.position.x, transform.position.y - (DictionaryPairNo * Width) - YOffset, transform.position.z);
            DictionaryPairNo++;
        }
    }

    void ToggleInventory()
    {
        if (!InventoryPanel.activeInHierarchy)
        {
            Time.timeScale = 0;
            DescriptionPanel.SetActive(false);
            InventoryPanel.SetActive(true);
        }
        else
        {
            Time.timeScale = 1;
            InventoryPanel.SetActive(false);
        }
    }

    public bool isInInventory(Item checkItem)
    {
        return ItemDictionary.ContainsKey(checkItem);
    }
}
