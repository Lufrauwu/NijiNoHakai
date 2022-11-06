using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    [Header("Health Stats")]
    [SerializeField] private int _healthLevel = 10;
    [SerializeField] private int _maxHealth;
    [SerializeField] private int _currentHealth;

    void Start()
    {
        _maxHealth = SetMaxHealth();
        _currentHealth = _maxHealth;
    }

    private int SetMaxHealth()
    {
        _maxHealth = _healthLevel * 10;
        return _maxHealth;
    }

    public void TakeDamage(int damage)
    {
        _currentHealth = _currentHealth - damage;
    }
}
