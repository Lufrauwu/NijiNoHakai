using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    [SerializeField] private bool _enemyIsDead;
    
    [Header("Health Stats")]
    [SerializeField] private int _healthLevel = 10;
    [SerializeField] private int _maxHealth;
    [SerializeField] private int _currentHealth;

    private void Awake()
    {
        _enemyIsDead = false;
    }

    void Start()
    {
        _maxHealth = SetMaxHealth();
        _currentHealth = _maxHealth;
    }

    private void Update()
    {
        EnemyDie();
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

    public void EnemyDie()
    {
        if (_currentHealth <= 0 && !_enemyIsDead)
        {
            Destroy(gameObject);
            _enemyIsDead = true;
        }
    }
}
