using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSlotManager : MonoBehaviour
{
    WeaponHolderSlot _leftHandSlot = default;
    WeaponHolderSlot _rightHandSlot = default;
    DamageCollider _leftDamageCollider = default;
    DamageCollider _rightDamageCollider = default;

    private void Awake()
    {
        WeaponHolderSlot[] weaponHolderSlots = GetComponentsInChildren<WeaponHolderSlot>();
        foreach (WeaponHolderSlot weaponSlot in weaponHolderSlots)
        {
            if (weaponSlot._isLeftHandSlot)
            {
                _leftHandSlot = weaponSlot;
            }
            else if (weaponSlot._isRghtHandSlot)
            {
                _rightHandSlot = weaponSlot;
            }
        }
    }

    public void LoadWeaponOnSlot(WeaponItem weaponItem, bool isLeft)
    {
        if (isLeft)
        {
            _leftHandSlot.LoadWeaponModel(weaponItem);
            LoadLeftWeaponDamageCollider();
        }
        else
        {
            _rightHandSlot.LoadWeaponModel(weaponItem);
            LoadRightWeaponDamageCollider();
        }
    }

    #region Handle Weapons Damage Collider

    private void LoadLeftWeaponDamageCollider()
    {
        _leftDamageCollider = _leftHandSlot._currentWeaponModel.GetComponentInChildren<DamageCollider>();
    }

    private void LoadRightWeaponDamageCollider()
    {
        _rightDamageCollider = _rightHandSlot._currentWeaponModel.GetComponentInChildren<DamageCollider>(); 
    }

    public void OpenRightDamageCollider()
    {
        LoadRightWeaponDamageCollider();
        _rightDamageCollider.EnableDamageCollider();
    }

    public void OpenLeftDamageCollider()
    {
        _leftDamageCollider.EnableDamageCollider();
    }

    public void CloseRightHandDamageCollider()
    {
        LoadRightWeaponDamageCollider();
        _rightDamageCollider.DisableDamageCollider();
    }

    public void CloseLeftHandDamageCollider()
    {
        _leftDamageCollider.DisableDamageCollider();
    }

    #endregion
}