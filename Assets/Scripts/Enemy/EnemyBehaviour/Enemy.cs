using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(EnemyPatroller))]
[RequireComponent (typeof(EnemyAnimation))]

public class Enemy : MonoBehaviour
{
    private EnemyPatroller _enemyPatroller;
    private EnemyAnimation _enemyAnimation;
    private EnemyMode _currentMode;

    private void OnDisable()
    {
        _enemyPatroller.TargetChanged -= _enemyAnimation.ToggleAnimationSide;
    }

    public void Initialize(Vector3 position, List<Transform> targets)
    {
        transform.position = position;

        _enemyPatroller = GetComponent<EnemyPatroller>();
        _enemyAnimation = GetComponent<EnemyAnimation>();

        _enemyPatroller.TargetChanged += _enemyAnimation.ToggleAnimationSide;
        _enemyPatroller.Initialize(targets);

        _currentMode = EnemyMode.Patroling;


        StartCoroutine(Operating());
    }

    private IEnumerator Operating()
    {
        while (enabled)
        {
            yield return null;

            if (_currentMode == EnemyMode.Patroling)
                _enemyPatroller.Patrol();
        }
    }

    private enum EnemyMode
    {
        Staying,
        Patroling,
        Huntig,
        Fighting
    }
}
