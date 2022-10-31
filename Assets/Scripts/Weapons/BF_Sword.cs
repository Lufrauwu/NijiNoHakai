using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BF_Sword : MonoBehaviour
{
    public PlayerController _player;
    [SerializeField] private GameObject _swordParticles;

    private void Start()
    {
        GameObject controller = GameObject.FindGameObjectWithTag("Player");
        _player = controller.GetComponent<PlayerController>();
    }

    void Update()
    {
        if(_player._heavyAttack)
        {
            _swordParticles.SetActive(true);
        }
        else
        {
            _swordParticles.SetActive(false);
        }
    }
}
