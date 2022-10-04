using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private GameObject _gameOver = default;
    [SerializeField] private GameObject _pauseButton = default;

    void Start()
    {
        
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            _gameOver.SetActive(true);
            _pauseButton.SetActive(false);
            Time.timeScale = 0;
        }
    }
}
