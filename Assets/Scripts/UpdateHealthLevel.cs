using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UpdateHealthLevel : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _healthText;
    [SerializeField] private Player _playerScript;
    private string _healthLevel;
    
    private void Start()
    {
        _healthText = GetComponent<TextMeshProUGUI>();
    }

    private void Update()
    {
        _healthLevel = _playerScript._healthLevel.ToString();
        _healthText.text = "Health Level: " + _healthLevel;
    }
}
