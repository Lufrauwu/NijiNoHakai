using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonDash : MonoBehaviour
{
    
    private PlayerController _playerController;
    [SerializeField] private float dashSpeed;
    [SerializeField] private float dashTime;

    private void Awake()
    {
        _playerController = GetComponent<PlayerController>();
    }

    public void TriggerDash()
    {
        StartCoroutine(Dash());
    }
    
    IEnumerator Dash()
    {
        float startTime = Time.time;
        
        //_playerController._controller.Move(_playerController.move * (dashSpeed * Time.deltaTime));
        while (Time.time < (startTime + dashTime))
        {
            _playerController.controller.Move(_playerController.move * (dashSpeed * Time.deltaTime));
        }

        //Other Method without dashTime 
        /*for (int i = 0; i < 50; i++)
        {
            _playerController._controller.Move(_playerController.move * (dashSpeed * Time.deltaTime));
            yield return null;
        }*/
       
    }
}
