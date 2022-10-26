using UnityEngine;

[CreateAssetMenu(menuName = "Items/Weapon Item")]
public class WeaponItem : Item
{
    public GameObject _weaponPrefab = default;
    public bool _isUnarmed;
    public ItemType _itemType;

    public enum ItemType
    {
        Sword
    }
}
