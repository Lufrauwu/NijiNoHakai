using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance = default;
    public Vector3 _lastCheckpointPos = default;

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(_instance);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        Debug.Log(_lastCheckpointPos);
    }
}
