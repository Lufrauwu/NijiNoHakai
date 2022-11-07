using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigMikeBurger : MonoBehaviour
{

    [SerializeField] private Player _playerScript = default;



    private void Awake()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (_playerScript._burgerAmount < 5 && other.CompareTag("Player"))
        {
            IncreaseBurgers();
            Destroy(gameObject); 
        }
        else
        {
            Debug.Log("toi Llenao");
        }

    }

    public void IncreaseBurgers()
    {
        _playerScript._burgerAmount++;
    }


}
