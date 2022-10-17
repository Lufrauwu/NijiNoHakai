using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    private WeaponSlotManager _weaponSlotManager;

    public WeaponItem _rightWeapon;
    public WeaponItem _leftWeapon;

    private void Awake()
    {
        _weaponSlotManager = GetComponent<WeaponSlotManager>();
    }

    private void Start()
    {
        _weaponSlotManager.LoadWeaponOnSlot(_rightWeapon, false);
        _weaponSlotManager.LoadWeaponOnSlot(_leftWeapon, true);
    }
}
