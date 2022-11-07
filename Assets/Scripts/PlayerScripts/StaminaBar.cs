using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StaminaBar : MonoBehaviour
{
    [SerializeField] private Slider _staminaBar = default;

    public int _maxStamina = 100;
    public int _currentStamina;

    private WaitForSeconds regenTick = new WaitForSeconds(0.1f);
    private Coroutine regen;

    public static StaminaBar instance;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        _currentStamina = _maxStamina;
        _staminaBar.maxValue = _maxStamina;
        _staminaBar.value = _maxStamina;
    }

    public void UseStamina(int staminaUse)
    {
        if (_currentStamina - staminaUse >= 0)
        {
            _currentStamina -= staminaUse;
            _staminaBar.value = _currentStamina;

            if (regen != null)
            {
                StopCoroutine(regen);
            }

            regen = StartCoroutine(RegenStamina());
        }
        else
        {
            Debug.Log("Not Enough Stamina");
        }
    }

    private IEnumerator RegenStamina()
    {
        yield return new WaitForSeconds(2f);

        while (_currentStamina < _maxStamina)
        {
            _currentStamina += _maxStamina / 100;
            _staminaBar.value = _currentStamina;
            yield return regenTick;
        }

        regen = null;
    }
}