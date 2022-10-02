using System;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    [SerializeField] private GameObject _interactButton = default;
    private bool _canInteract = default;
    private GameManager _gameManager = default;

    private void Start()
    {
        _gameManager = GameObject.FindGameObjectWithTag("GM").GetComponent<GameManager>();
    }

    private void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            _interactButton.SetActive(false);
            _canInteract = false;
        }
    }
    
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            _interactButton.SetActive(true);
            _canInteract = true;
        }
    }

    public void SavePosition()
    {
        _gameManager._lastCheckpointPos = transform.position;
    }
}
