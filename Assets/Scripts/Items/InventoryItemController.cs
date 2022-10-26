using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryItemController : MonoBehaviour
{
    private Item item = default;
    private WeaponItem _weaponItem = default;
    [SerializeField] private Button _removeButton = default;
    public void RemoveItem()
    {
        InventoryManager.Instance.Remove(item);
        Destroy(gameObject);
    }

    public void AddItem(Item newItem)
    {
        item = newItem;
    }

    public void UseItem()
    {
        switch (_weaponItem._itemType)
        {
            case WeaponItem.ItemType.Sword:
                break;
            default:
                break;
        }
    }
}
