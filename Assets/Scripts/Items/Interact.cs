using System;
using UnityEngine;

public class Interact : MonoBehaviour
{
    [SerializeField] private GameObject _takeButton = default;
    private bool _hasInteracted = default;


    private void OnTriggerEnter(Collider other)
    {
        _takeButton.SetActive(true);
    }

    private void OnTriggerExit(Collider other)
    {
        _takeButton.SetActive(false);
    }
}
