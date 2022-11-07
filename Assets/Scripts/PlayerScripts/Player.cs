using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    private PlayerController _controller;
    [SerializeField] private GameObject _gameOver = default;
    [SerializeField] private GameObject _pauseButton = default;
    
    [Header("Health Stats")]
    [SerializeField] private PlayerHealthBar _healthBar = default;
    [SerializeField] private int _healthLevel = 10;
    [SerializeField] private int _maxHealth;
    [SerializeField] private int _currentHealth;

    void Start()
    {
        _controller = GetComponent<PlayerController>();
        _maxHealth = SetMaxHealth();
        _currentHealth = _maxHealth;
        _healthBar.SetMaxHealth(_maxHealth);
    }

    void Update()
    {
        if (_currentHealth <= 0)
        {
            _controller._anim.SetBool("dead", true);
            _gameOver.SetActive(true);
            _pauseButton.SetActive(false);
        }
    }

    private int SetMaxHealth()
    {
        _maxHealth = _healthLevel * 10;
        return _maxHealth;
    }

    public void TakeDamage(int damage)
    {
        _currentHealth = _currentHealth - damage;
        _healthBar.SetCurrentHealt(_currentHealth);
    }
}
