using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Items/Weapon Item")]
public class WeaponItem : Item
{
    public GameObject _weaponPrefab = default;
    public bool _isUnarmed;

    [Header("One handed attack animations")]
    public string OH_LightAttack;

    public string OH_HeavyAttack;
}
