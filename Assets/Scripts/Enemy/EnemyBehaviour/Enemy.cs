using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Patroller))]
[RequireComponent (typeof(EnemyRotator))]

public class Enemy : MonoBehaviour
{
    private Patroller _patroller;
    private EnemyRotator _enemyRotator;
    private bool _isPatrolling;

    private void OnDestroy()
    {
        _patroller.TargetChanged -= _enemyRotator.Rotate;
    }

    public void Initialize(Vector3 position, List<Transform> targets)
    {
        transform.position = position;

        _patroller = GetComponent<Patroller>();
        _enemyRotator = GetComponent<EnemyRotator>();

        _patroller.TargetChanged += _enemyRotator.Rotate;
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
