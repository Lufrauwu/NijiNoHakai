using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamageCollider : MonoBehaviour
{
    Collider _damageCollider;
    [Header("Enemy Damage")] 
    public int _enemyDamage = 40;
    private int _hiddenDamage = 0;
    
    private void Awake()
    {
        _damageCollider = GetComponent<Collider>();
        _damageCollider.gameObject.SetActive(true);
        _damageCollider.isTrigger = true;
        _damageCollider.enabled = false;
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
                player.TakeDamage(_enemyDamage);
            }
        }
    }
}
