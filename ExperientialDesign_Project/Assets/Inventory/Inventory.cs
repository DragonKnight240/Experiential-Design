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
    public GameObject ItemLocationsParent;
    public Dictionary<Item, GameObject> ItemDictionary;
    public GameObject MoneyUI;
    public TextMeshProUGUI MoneyDisplay;
    float MoneyTimer = 0;
    public float MoneyMax = 5;
    public GameObject NewItemUI;
    public TextMeshProUGUI NewItemText;
    float ItemTimer = 0;
    public float ItemMax = 2;
    public AudioClip OpenBag;
    public AudioClip AddInventory;
    public AudioClip MoneyObtained;

    static internal Inventory Instance;

    // Start is called before the first frame update
    void Start()
    {
        if (Inventory.Instance != null)
        {
            ItemDictionary = new Dictionary<Item, GameObject>();
            foreach(Item items in Inventory.Instance.ItemDictionary.Keys)
            {
                AddToInventory(items, false);
            }

            Inventory.Instance = this;
            Destroy(Inventory.Instance);
        }
        else
        {
            Inventory.Instance = this;
            ItemDictionary = new Dictionary<Item, GameObject>();
        }

        InventoryPanel.SetActive(false);
        

        //DontDestroyOnLoad(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.I))
        {
            ToggleInventory();
        }

        if(MoneyUI.activeInHierarchy && !InventoryPanel.activeInHierarchy)
        {
            MoneyTimer += Time.unscaledDeltaTime;

            if(MoneyTimer >= MoneyMax)
            {
                MoneyUI.SetActive(false);
                MoneyTimer = 0;
            }
        }

        if(NewItemUI.activeInHierarchy)
        {
            ItemTimer += Time.unscaledDeltaTime;

            if(ItemTimer >= ItemMax)
            {
                NewItemUI.SetActive(false);
                ItemTimer = 0;
            }
        }
    }

    public void ChangeMoney()
    {
        SoundManager.Instance.SpawnSFX(MoneyObtained);
        MoneyDisplay.text = GameManager.Instance_.GetMoney().ToString();
        MoneyUI.gameObject.SetActive(true);
    }

    public void AddToInventory(Item newItem, bool PlaySound = true)
    {
        if(ItemDictionary.ContainsKey(newItem))
        {
            return;
        }

        if (PlaySound)
        {
            SoundManager.Instance.SpawnSFX(AddInventory);
        }

        NewItemText.text = newItem.Name;
        NewItemUI.SetActive(true);

        Transform NewPosition = InventoryPanel.transform.GetChild(0);
        GameObject NewSection = Instantiate(ItemSectionPrefab, NewPosition.transform);

        ItemDictionary.Add(newItem, NewSection);

        NewPosition = ItemLocationsParent.transform.GetChild(ItemDictionary.Count - 1);

        NewSection.transform.position = NewPosition.position;

        NewSection.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = newItem.Name;
        NewSection.GetComponent<ItemSection>().item = newItem;
    }

    public void RemoveFromInventory(Item oldItem)
    {
        Destroy(ItemDictionary[oldItem]);
        ItemDictionary.Remove(oldItem);

        int DictionaryPairNo = 0;

        foreach (KeyValuePair<Item, GameObject> ItemPair in ItemDictionary)
        {
            ItemPair.Value.transform.position = ItemLocationsParent.transform.GetChild(DictionaryPairNo).position;
            DictionaryPairNo++;
        }
    }

    void ToggleInventory()
    {
        SoundManager.Instance.SpawnSFX(OpenBag);

        if (!InventoryPanel.activeInHierarchy)
        {
            Time.timeScale = 0;
            DescriptionPanel.SetActive(false);
            InventoryPanel.SetActive(true);
            MoneyUI.SetActive(true);
        }
        else
        {
            Time.timeScale = 1;
            InventoryPanel.SetActive(false);
            MoneyUI.SetActive(false);
        }
    }

    public bool isInInventory(Item checkItem)
    {
        return ItemDictionary.ContainsKey(checkItem);
    }
}
