using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class BossStats : MonoBehaviour
{
    private BossAIController _bossAI;
    [SerializeField] private bool _enemyIsDead;
    
    [Header("Health Stats")]
    [SerializeField] private int _healthLevel = 10;
    [SerializeField] private int _maxHealth;
    [SerializeField] private int _currentHealth;

    private void Awake()
    {
        _enemyIsDead = false;
        _bossAI = GetComponent<BossAIController>();
    }

    void Start()
    {
        _maxHealth = SetMaxHealth();
        _currentHealth = _maxHealth;
    }

    private void Update()
    {
        BossDie();
    }

    private int SetMaxHealth()
    {
        _maxHealth = _healthLevel * 10;
        return _maxHealth;
    }

    public void BossTakeDamage(int damage)
    {
        _currentHealth -= damage;
    }

    public void BossDie()
    {
        if (_currentHealth <= 0 && !_enemyIsDead)
        {
            _enemyIsDead = true;
            _bossAI._enemyAnim.SetBool("die", true);
            _bossAI._enemyAnim.SetBool("walk", false);
            _bossAI._enemyAnim.SetBool("run", false);
            _bossAI._enemyAnim.SetBool("attack", false);
            _bossAI._enemyAnim.SetBool("damaged", false);
            _bossAI.speedRun = 0;
            _bossAI.speedWalk = 0;
            Destroy(gameObject, 1.69f);
        }
    }
}