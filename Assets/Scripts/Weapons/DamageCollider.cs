using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageCollider : MonoBehaviour
{
    Collider _damageCollider;
    public int _currentWeaponDamage = 25;
    private void Awake()
    {
        _damageCollider = GetComponent<Collider>();
        _damageCollider.gameObject.SetActive(true);
        _damageCollider.isTrigger = true;
        _damageCollider.enabled = false;
    }

    public void EnableDamageCollider()
    {
        _damageCollider.enabled = true;
    }

    public void DisableDamageCollider()
    {
        _damageCollider.enabled = false;
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.tag == "Hittable")
        {
            Player player = collision.GetComponent<Player>();
            if (player != null)
            {
                player.TakeDamage(_currentWeaponDamage);
            }
        }
    }
}
