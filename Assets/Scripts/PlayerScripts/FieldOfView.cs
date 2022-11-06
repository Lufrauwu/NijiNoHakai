using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldOfView : MonoBehaviour
{
    public float _radius;
    [Range(0, 360)]
    public float _angle;
    public GameObject _EnemyRef;
    public LayerMask _targetMask;
    public LayerMask _obstrucionMask;
    public bool _canSeeEnemies;

    private void Start()
    {
        _EnemyRef = GameObject.FindGameObjectWithTag("Enemy");
        StartCoroutine(FOVRoutine());
    }

    private IEnumerator FOVRoutine()
    {
        float delay = 0.2f;
        WaitForSeconds wait = new WaitForSeconds(delay);

        while (true)
        {
            yield return wait;
            FieldOfViewCheck();
        }
    }

    private void FieldOfViewCheck()
    {
        Collider[] rangeChecks = Physics.OverlapSphere(transform.position, _radius, _targetMask);

        if (rangeChecks.Length != 0)
        {
            Transform target = rangeChecks[0].transform;
            Vector3 directionToTarget = (target.position - transform.position).normalized;

            if (Vector3.Angle(transform.forward, directionToTarget) < _angle / 2)
            {
                float distanceToTarget = Vector3.Distance(transform.position, target.position);

                if (!Physics.Raycast(transform.position, directionToTarget, distanceToTarget, _obstrucionMask))
                {
                    _canSeeEnemies = true;
                }
                else
                {
                    _canSeeEnemies = false;
                }
            }
            else
            {
                _canSeeEnemies = false;
            }
        }
        else if (_canSeeEnemies)
        {
            _canSeeEnemies = false;
        }
    }
}
