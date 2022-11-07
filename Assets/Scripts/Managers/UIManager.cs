using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.OnScreen;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public GameObject _lightAttackButton;
    public GameObject _deactivatedLightAttackButton;
    public GameObject _heavyAttackButton;
    public GameObject _deactivatedHeavyAttackButton;
    public PlayerController _controller;

    private void Update()
    {
        DeactivateLightAttack();
        DeactivateHeavyAttack();
    }

    private void DeactivateLightAttack()
    {
        if (_controller._lightAttack)
        {
            StartCoroutine(DeactivateLigthAttackTimer());
        }
    }
    
    private void DeactivateHeavyAttack()
    {
        if (_controller._heavyAttack)
        {
            StartCoroutine(DeactivateHeavyAttackTimer());
        }
    }

    IEnumerator DeactivateLigthAttackTimer()
    {
        _lightAttackButton.SetActive(false);
        _deactivatedLightAttackButton.SetActive(true);
        yield return new WaitForSeconds(0.8f);
        _lightAttackButton.SetActive(true);
        _deactivatedLightAttackButton.SetActive(false);
    }
    

    IEnumerator DeactivateHeavyAttackTimer()
    {
        _heavyAttackButton.SetActive(false);
        _deactivatedHeavyAttackButton.SetActive(true);
        yield return new WaitForSeconds(4f);
        _heavyAttackButton.SetActive(true);
        _deactivatedHeavyAttackButton.SetActive(false);
    }
}
