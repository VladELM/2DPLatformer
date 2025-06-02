using System;
using System.Collections.Generic;
using UnityEngine;

public class Patroller : MonoBehaviour
{
    [SerializeField] private float _speed;

    private List<Transform> _targets;
    private Transform _currentTarget;
    private int _targetIndex;

    public event Action<float> TargetChanged;

    public void Initialize(List<Transform> targets)
    {
        _targets = targets;
        _targetIndex = 0;
        _currentTarget = GetTarget();
        TargetChanged?.Invoke(_currentTarget.position.x);
    }

    public void Patrol()
    {
        Vector3 targetPosition = new Vector3(_currentTarget.position.x,
                                                GetEqualizedTargetY(),
                                            _currentTarget.position.z);

        transform.position = Vector2.MoveTowards(transform.position, targetPosition, _speed * Time.deltaTime);

        if (IsDistanceZero())
        {
            _currentTarget = GetTarget();
            TargetChanged?.Invoke(_currentTarget.position.x);
        }
    }

    private float GetEqualizedTargetY()
    {
        float offsetY = Math.Abs(Math.Abs(_currentTarget.position.y) - Math.Abs(transform.position.y));

        float targetY = 0;

        if (_currentTarget.position.y > transform.position.y)
            targetY = _currentTarget.position.y - offsetY;
        else if (_currentTarget.position.y < transform.position.y)
            targetY = _currentTarget.position.y + offsetY;

        return targetY;
    }

    private bool IsDistanceZero()
    {
        bool isZero = false;
        float offset = Math.Abs(_currentTarget.position.x) - Math.Abs(transform.position.x);

        if (offset == 0)
            isZero = true;

        return isZero;
    }

    private Transform GetTarget()
    {
        if (_targetIndex == _targets.Count)
            _targetIndex = 0;

        Transform target = _targets[_targetIndex];
        _targetIndex++;

        return target;
    }
}
