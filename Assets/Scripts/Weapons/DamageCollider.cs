using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class DamageCollider : MonoBehaviour
{
    Collider _damageCollider;
    public int _currentWeaponDamage = 25;
    public int _heavyDamage = 35;
    public PlayerController _player;
    private void Awake()
    {
        _damageCollider = GetComponent<Collider>();
        _damageCollider.gameObject.SetActive(true);
        _damageCollider.isTrigger = true;
        _damageCollider.enabled = false;
        //_player = GetComponentInParent<PlayerController>();
    }

    private void Update()
    {
        _currentWeaponDamage = Random.Range(25, 40);
    }

    public void EnableDamageCollider()
    {
        this._damageCollider.enabled = true;
    }

    public void DisableDamageCollider()
    {
        this._damageCollider.enabled = false;
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.tag == "Player")
        {
            Player player = collision.GetComponent<Player>();
            if (player != null)
            {
                player.TakeDamage(_currentWeaponDamage);
            }
        }

        if (collision.tag == "Enemy")
        {
            EnemyStats enemyStats = collision.GetComponent<EnemyStats>();
            if (enemyStats != null)
            {
                enemyStats.TakeDamage(_currentWeaponDamage);
                if (_currentWeaponDamage > 38)
                {
                    Debug.Log("Critical");
                }
            }
            else if (enemyStats != null && _player._heavyAttack)
            {
                enemyStats.TakeDamage(_heavyDamage);
            }
        }
    }
}
