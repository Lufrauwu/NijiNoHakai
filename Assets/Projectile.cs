using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public BossProjectile _boss;
    public int _projectileDamage = 150;
    
    public void OnTriggerEnter(Collider collision)
    {
        if (collision.tag == "Player")
        {
            Debug.Log("Player");
            Player player = collision.GetComponent<Player>();
            if (player != null)
            {
                player.TakeDamage(_projectileDamage);
                Debug.Log(_projectileDamage);
            }
        }
        else
        {
            Debug.Log("nothing");
        }
    }
}
