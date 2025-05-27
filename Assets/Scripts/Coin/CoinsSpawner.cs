using System.Collections.Generic;
using UnityEngine;

public class CoinsSpawner : MonoBehaviour
{
    [SerializeField] private Coin _coinPrefab;
    [SerializeField] private Transform _spawnPointParent;
    [SerializeField] private List<Transform> _spawnPoints;

    private void Awake()
    {
        int spawnPointsAmount = _spawnPoints.Count;

        for (int i = 0; i < spawnPointsAmount; i++)
        {
            Coin coin = Instantiate(_coinPrefab);
            coin.transform.position = _spawnPoints[i].transform.position;
        }

        _spawnPoints.Clear();
    }

    #if UNITY_EDITOR
    [ContextMenu("FillSpawnPointsList")]
    private void FillSpawnPointsList()
    {
        _spawnPoints = new List<Transform>();
        int spawnPointsAmount = _spawnPointParent.childCount;

        for (int i = 0; i < spawnPointsAmount; i++)
        {
            Transform point = _spawnPointParent.GetChild(i);

            if (point.TryGetComponent(out CoinSpawnPoint component))
                _spawnPoints.Add(point);
        }
    }

    #endif
}
