using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyEventsHandler : MonoBehaviour
{
    private DamageCollider _weaponDamageCollider;

    private void Awake()
    {
        _weaponDamageCollider = GetComponentInChildren<DamageCollider>();
    }

    public void OpenEnemyDamageCollider()
    {
        _weaponDamageCollider.EnableDamageCollider();
    }

    public void CloseEnemyDamageCollider()
    {
        _weaponDamageCollider.DisableDamageCollider();
    }
}
