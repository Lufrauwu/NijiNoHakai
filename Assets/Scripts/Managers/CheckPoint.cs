using System;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    [SerializeField] private GameObject _interactButton = default;
    [SerializeField] private GameObject _checkPointPrefab = default;
    private GameManager _gameManager = default;

    private void Start()
    {
       // _gameManager = GameObject.FindGameObjectWithTag("GM").GetComponent<GameManager>();
       // _checkPointPrefab.transform.position = transform.position;
    }

    private void OnTriggerExit(Collider collision)
    {
        if (collision.CompareTag("Player"))
        {
            _interactButton.SetActive(false);
        }
    }
    
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Player"))
        {
            _interactButton.SetActive(true);
        }
    }

    public void SavePosition()
    {
        
    }
    
    /*public void SavePosition()
    {
        _gameManager._lastCheckpointPos = new Vector3(transform.position.x + 5, transform.position.y, transform.position.z);
    }*/


}

//using UnityEngine;

/*public class CheckPoint : MonoBehaviour
{
    private GameManager _gameManager = default;
    private void OnTriggerEnter(Collider collision)
    {
        if(collision.transform.tag == "Player")
        {
            _gameManager._lastCheckpointPos = transform.position;

        }
    }
}*/
