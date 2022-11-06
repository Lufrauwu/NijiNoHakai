using System;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    //[SerializeField] private GameObject _interactButton = default;
    [SerializeField] private GameObject _checkPointPrefab = default;
    private GameManager _gameManager = default;

    private void Start()
    {
        _gameManager = GameObject.FindGameObjectWithTag("GM").GetComponent<GameManager>();
        _checkPointPrefab.transform.position = transform.position;
    }

    /*private void OnTriggerExit(Collider collision)
    {
        if (collision.CompareTag("Player"))
        {
            _interactButton.SetActive(false);
        }
    }*/
    
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Player"))
        {
            //_interactButton.SetActive(true);
            _gameManager._lastCheckpointPos = _checkPointPrefab.transform.position;
        }
    }

    /*public void SavePosition()
    {
        _gameManager._lastCheckpointPos = _checkPointPrefab.transform.position;
    }*/
}
