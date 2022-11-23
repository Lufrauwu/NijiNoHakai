using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance = default;
    public Vector3 _lastCheckpointPos = new Vector3(610, 8.75f, 295);
    //[SerializeField] private GameObject _Player = default;

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

    private void Start()
    {
        GameObject.FindGameObjectWithTag("Player").transform.position = _lastCheckpointPos;
    }

    private void Update()
    {
        //Debug.Log(_lastCheckpointPos);
    }
}
