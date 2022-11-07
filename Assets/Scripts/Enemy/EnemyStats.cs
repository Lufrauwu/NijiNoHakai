using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    private AIController _ai;
    [SerializeField] private bool _enemyIsDead;
    
    [Header("Health Stats")]
    [SerializeField] private int _healthLevel = 10;
    [SerializeField] private int _maxHealth;
    [SerializeField] private int _currentHealth;

    private void Awake()
    {
        _enemyIsDead = false;
        _ai = GetComponent<AIController>();
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
        _currentHealth -= damage;
    }

    public void EnemyDie()
    {
        if (_currentHealth <= 0 && !_enemyIsDead)
        {
            _enemyIsDead = true;
            _ai._enemyAnim.SetBool("die", true);
            _ai._enemyAnim.SetBool("walk", false);
            _ai._enemyAnim.SetBool("run", false);
            _ai._enemyAnim.SetBool("attack", false);
            _ai._enemyAnim.SetBool("damaged", false);
            _ai.speedRun = 0;
            _ai.speedWalk = 0;
            Destroy(gameObject, 1.69f);
        }
    }
}
