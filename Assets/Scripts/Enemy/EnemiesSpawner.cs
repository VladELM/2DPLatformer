using System.Collections.Generic;
using UnityEngine;

public class EnemiesSpawner : MonoBehaviour
{
    [SerializeField] private Enemy _enemyPrefab;
    [SerializeField] private List<EnemySpawnPoint> _spawnPoints;

    private void Awake()
    {
        SpawnEnemies();
    }

    private void SpawnEnemies()
    {
        for (int i = 0; i < _spawnPoints.Count; i++)
        {
            Enemy enemy = Instantiate(_enemyPrefab);
            enemy.Initialize(_spawnPoints[i].transform.position, _spawnPoints[i].GetPatrolPoints());
        }
    }

    #if UNITY_EDITOR
    [ContextMenu("FillSpanwPointsList")]
    private void FillSpanwPointsList()
    {
        int childAmount = transform.childCount;

        for (int i = 0; i < childAmount; i++)
        {
            Transform child = transform.GetChild(i);

            if (child.TryGetComponent(out EnemySpawnPoint enemySpawnPoint))
                _spawnPoints.Add(enemySpawnPoint);
        }
    }

    #endif
}
