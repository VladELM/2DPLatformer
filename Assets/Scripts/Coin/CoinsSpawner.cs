using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinsSpawner : MonoBehaviour
{
    [SerializeField] private Coin _coinPrefab;
    [SerializeField] private Transform _spawnPointParent;
    [SerializeField] private List<Transform> _spawnPoints;
    [SerializeField] float _timeToDelay;

    private int _coinsAmout;

    private WaitForSeconds _delay;

    private void Awake()
    {
        _delay = new WaitForSeconds(_timeToDelay);
        int spawnPointsAmount = _spawnPoints.Count;

        for (int i = 0; i < spawnPointsAmount; i++)
        {
            Coin coin = Instantiate(_coinPrefab);
            coin.transform.position = _spawnPoints[i].transform.position;
            coin.Touched += GiveBackCoin;
        }

        _spawnPoints.Clear();
    }

    private void GetCoin(Coin coin)
    {
        coin.EnableSprite();
    }

    private void GiveBackCoin(Coin coin)
    {
        coin.DisableSprite();
        StartCoroutine(Spawning(coin));
    }

    private IEnumerator Spawning(Coin coin)
    {   
        yield return _delay;

        GetCoin(coin);
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
