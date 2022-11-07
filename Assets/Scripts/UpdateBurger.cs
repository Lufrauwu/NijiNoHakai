using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UpdateBurger : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _burgertext;
    [SerializeField] private Player _playerScript;
    private string _burgerAmount;
    private string _maxBurgerAmount;

    private void Start()
    {
        _burgertext = GetComponent<TextMeshProUGUI>();
    }

    private void Update()
    {
        _burgerAmount = _playerScript._burgerAmount.ToString();
        _maxBurgerAmount = _playerScript._maxBurgers.ToString();
        _burgertext.text = _burgerAmount + "/" + _maxBurgerAmount; //!fuck @Miguel 
    }
}
