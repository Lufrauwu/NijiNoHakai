using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private GameObject _gameOver = default;
    [SerializeField] private GameObject _pauseButton = default;
    [SerializeField] private PlayerHealthBar _healthBar = default;
    [SerializeField] private int _healthLevel = 10;
    [SerializeField] private int _maxHealth;
    [SerializeField] private int _currentHealth;

    void Start()
    {
        _maxHealth = SetMaxHealth();
        _currentHealth = _maxHealth;
        _healthBar.SetMaxHealth(_maxHealth);
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
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
    }
}
