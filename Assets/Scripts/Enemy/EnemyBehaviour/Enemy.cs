using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Patroller))]
[RequireComponent (typeof(Rotator))]

public class Enemy : MonoBehaviour
{
    private Patroller _patroller;
    private Rotator _enemyRotator;
    private bool _isPatrolling;

    private void OnDestroy()
    {
        _patroller.TargetChanged -= _enemyRotator.RotateEnemy;
    }

    public void Initialize(Vector3 position, List<Transform> targets)
    {
        transform.position = position;

        _patroller = GetComponent<Patroller>();
        _enemyRotator = GetComponent<Rotator>();

        _patroller.TargetChanged += _enemyRotator.RotateEnemy;
        _patroller.Initialize(targets);

        _isPatrolling = true;
        StartCoroutine(Operating());
    }

    private IEnumerator Operating()
    {
        while (enabled)
        {
            yield return null;

            if (_isPatrolling)
                _patroller.Patrol();
        }
    }
}
