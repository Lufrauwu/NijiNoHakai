using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonDash : MonoBehaviour
{
    private PlayerController _playerController;
    [SerializeField] private StaminaBar _staminaBar;
    [SerializeField] private float dashSpeed;
    [SerializeField] private float dashTime;

    private void Awake()
    {
        _playerController = GetComponent<PlayerController>();
    }

    public void TriggerDash()
    {
        if (_staminaBar._currentStamina >= 50)
        {
            StartCoroutine(Dash()); 
            StaminaBar.instance.UseStamina(50);
        }
        else
        {
            Debug.Log("Not Enough Stamina");
        }
    }
    
    IEnumerator Dash()
    {
        float startTime = Time.time;
        
        //_playerController._controller.Move(_playerController.move * (dashSpeed * Time.deltaTime));
        while (Time.time < (startTime + dashTime))
        {
            _playerController.controller.Move(_playerController.move * (dashSpeed * Time.deltaTime));
            yield return null;
        }

        //Other Method without dashTime 
        /*for (int i = 0; i < 50; i++)
        {
            _playerController._controller.Move(_playerController.move * (dashSpeed * Time.deltaTime));
            yield return null;
        }*/
       
    }
}
