using UnityEngine;

public class PlayerPosSave : MonoBehaviour
{
    private GameManager _gameManager = default;

    private void Start()
    {
        _gameManager = GameObject.FindGameObjectWithTag("GM").GetComponent<GameManager>();
        transform.position = _gameManager._lastCheckpointPos;
    }
    
}
