using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using TMPro;

public class Player : MonoBehaviour
{
    
    private PlayerController _controller;
    [SerializeField] private GameObject _gameOver = default;
    [SerializeField] private GameObject _pauseButton = default;
    [Header("Health Stats")]
    public int _healthLevel = 10;
    [SerializeField] private PlayerHealthBar _healthBar = default;
    [SerializeField] private int _maxHealth;
    [SerializeField] private int _currentHealth;
    [Header("Healing")]
    private PlayerMovement _playerInput = default;
    private BigMikeBurger _bigMikeBurger = default;
    public int _maxBurgers = 5;
    public int _burgerAmount = default;


    

    void OnEnable()
    {
        _playerInput.Enable();
    }

    void OnDisable()
    {
        _playerInput.Disable();
    }

    private void Awake()
    {
        _playerInput = new PlayerMovement();
    }

    void Start()
    {
        _controller = GetComponent<PlayerController>();
        _maxHealth = SetMaxHealth();
        _currentHealth = _maxHealth;
        _healthBar.SetMaxHealth(_maxHealth);
    }

    void Update()
    {
        SetMaxHealth();
        
        if (_currentHealth >= _maxHealth)
        {
            _currentHealth = _maxHealth;
        }
        if (_currentHealth <= 0)
        {
            _controller._anim.SetBool("dead", true);
            _gameOver.SetActive(true);
            _pauseButton.SetActive(false);
        }

        if (_playerInput.PlayerMain.Heal.triggered)
        {
            AddLife();
        }
        
    }

    private int SetMaxHealth()
    {
        _maxHealth = _healthLevel * 10;
        _currentHealth = _maxHealth;
        return _maxHealth;
    }

    public void TakeDamage(int damage)
    {
        _currentHealth = _currentHealth - damage;
        _healthBar.SetCurrentHealt(_currentHealth);
    }

    public void AddLife()
    {
        if (_currentHealth >= _maxHealth)
        {
            _currentHealth = _maxHealth;
        }
        if(_burgerAmount >= 1 && _currentHealth < _maxHealth)
        {
                _currentHealth += 30;
                _healthBar.SetCurrentHealt(_currentHealth);
                _burgerAmount--;
        }
        
        

        /*if (_burgerAmount <= 0)
        {
            _burgerAmount = 0;
        }*/


    }
    /*public void SavePlayer()
    {
        SaveSystem.SavePlayer(this);
    }

    public void LoadPlayer()
    {
        PlayerData data = SaveSystem.LoadPlayerData();
        Time.timeScale = 1;
        Vector3 position;
        position.x = data.position[0];
        position.y = data.position[1];
        position.z = data.position[2];
        transform.position = position;
    }*/
}
