using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickUp : MonoBehaviour
{
    public Item _item;

    public void PickUp()
    {
        InventoryManager.Instance.Add(_item);
        Destroy(gameObject);
    }


}
