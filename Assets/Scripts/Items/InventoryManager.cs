using System.Collections.Generic;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager Instance;
    public List<Item> Items = new List<Item>();
    public Transform _itemContent = default;
    public GameObject _inventoryItem = default;
    public Toggle _enableRemove = default;
    public InventoryItemController[] _inventoryItems = default;

    private void Awake()
    {
        Instance = this;
    }

    public void Add(Item item)
    {
        Items.Add(item);
    }

    public void Remove(Item item)
    {
        Items.Remove(item);
    }

    public void ListItems()
    {
        foreach (Transform item in _itemContent)
        {
            Destroy(item.gameObject);
        }
        foreach (var item in Items)
        {
            GameObject obj = Instantiate(_inventoryItem, _itemContent);
            var itemName = obj.transform.Find("ItemName").GetComponent<TextMeshProUGUI>();
            Debug.Log(itemName);
            var itemIcon = obj.transform.Find("Item icon").GetComponent<Image>();
            var removeButton = obj.transform.Find("CloseButton").GetComponent<Button>();

            itemName.text = item._itemName;
            itemIcon.sprite = item._itemIcon;

            if (_enableRemove.isOn)
            {
                removeButton.gameObject.SetActive(true);
            }
        }
        SetInventoryItems();
    }

    public void EnableItemsRemove()
    {
        if (_enableRemove.isOn)
        {
            foreach (Transform item in _itemContent)
            {
                item.Find("CloseButton").gameObject.SetActive(true);
            }
        }
        else
        {
            foreach (Transform item in _itemContent)
            {
                item.Find("CloseButton").gameObject.SetActive(false);
            }
        }
    }

    public void SetInventoryItems()
    {
        _inventoryItems = _itemContent.GetComponentsInChildren<InventoryItemController>();
        for (int i = 0; i < Items.Count; i++)
        {
            _inventoryItems[i].AddItem(Items[i]);
        }
    }
}
