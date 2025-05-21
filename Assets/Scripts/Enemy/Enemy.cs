using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float _speed;

    private Transform _targetPosition;
    private bool _isInBattleMode;

    private void Awake()
    {
        StartCoroutine(Moving());
    }

    private void Patrol()
    {
        transform.position = Vector2.MoveTowards(transform.position, _targetPosition.position,
                                                _speed * Time.deltaTime);
    }

    private IEnumerator Moving()
    {
        while (enabled)
        {
            yield return null;

            if (_isInBattleMode == false)
                Patrol();
            else
                break;
        }
    }

    private bool IsDistanceZero()
    {
        bool isZero = false;

        Vector2 offset = _targetPosition.position - transform.position;
        float offsetSquare = offset.sqrMagnitude;

        if (offsetSquare == 0)
            isZero = true;

        return isZero;
    }
}
