using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyEventsHandler : MonoBehaviour
{
    private EnemyDamageCollider _weaponDamageCollider;
    private BossProjectile _projectile;

    private void Awake()
    {
        _weaponDamageCollider = GetComponentInChildren<EnemyDamageCollider>();
        _projectile = GetComponentInChildren<BossProjectile>();
    }

    public void OpenEnemyDamageCollider()
    {
        _weaponDamageCollider.EnableDamageCollider();
    }

    public void CloseEnemyDamageCollider()
    {
        _weaponDamageCollider.DisableDamageCollider();
    }

    public void InstantiateProjectile()
    {
        _projectile.Shoot();
    }
}
