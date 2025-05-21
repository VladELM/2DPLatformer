using static UnityEngine.Random;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class CoinsSpawner : MonoBehaviour
{
    [SerializeField] private Coin _coinPrefab;
    [SerializeField] private Transform _spawnPointParent;
    [SerializeField] private List<Transform> _spawnPoints;
    [SerializeField] float _timeToDelay;

    private Queue<Coin> _coinsPool;
    private WaitForSeconds _delay;

    private void Awake()
    {
        _coinsPool = new Queue<Coin>();
        _delay = new WaitForSeconds(_timeToDelay);

        int spawnPointsAmount = _spawnPoints.Count;

        for (int i = 0; i < spawnPointsAmount; i++)
        {
            Coin coin = Instantiate(_coinPrefab);
            coin.transform.position = _spawnPoints[i].transform.position;
            _coinsPool.Enqueue(coin);
            coin.Touched += GiveBackCoin;
        }

        _spawnPoints.Clear();
    }

    private void GetCoin()
    {
        if (_coinsPool.Count > 0)
        {
            Coin coin = _coinsPool.Dequeue();
            coin.gameObject.SetActive(true);
            coin.Touched += GiveBackCoin;
        }
    }

    private void GiveBackCoin(Coin coin)
    {
        coin.gameObject.SetActive(false);
        _coinsPool.Enqueue(coin);
        coin.Touched -= GiveBackCoin;

        StartCoroutine(Spawning());
    }

    private IEnumerator Spawning()
    {   
        yield return _delay;

        GetCoin();
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

            if (point.TryGetComponent(out SpawnPoint component))
                _spawnPoints.Add(point);
        }
    }

    #endif
}
