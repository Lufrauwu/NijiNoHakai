using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponHolderSlot : MonoBehaviour
{
    [SerializeField] private Transform _parentOverride;
    public GameObject _currentWeaponModel;
    public bool _isLeftHandSlot;
    public bool _isRghtHandSlot;

    public void UnloadWeapon()
    {
        if( _currentWeaponModel != null )
        {
            _currentWeaponModel.SetActive(false);
        }
    }

    public void UnloadWeaponAndDestroy()
    {
        if(_currentWeaponModel != null)
        {
            Destroy(_currentWeaponModel);
        }
    }

    public void LoadWeaponModel(WeaponItem weaponItem)
    {
        UnloadWeaponAndDestroy();

        if(weaponItem == null)
        {
            UnloadWeapon();
            return;
        }
        GameObject model = Instantiate(weaponItem._weaponPrefab) as GameObject;
        if(model != null)
        {
            if(_parentOverride != null)
            {
                model.transform.parent = _parentOverride;
            }
            else
            {
                model.transform.parent = transform;
            }
            model.transform.localPosition = Vector3.zero;
            model.transform.localRotation = Quaternion.identity;
            model.transform.localScale = Vector3.one;
        }
        _currentWeaponModel = model;
    }
}
