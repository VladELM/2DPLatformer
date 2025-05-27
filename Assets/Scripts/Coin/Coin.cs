using System.Collections;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]

public class Coin : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _spriteRenderer;
    [SerializeField] private Sprite _coinSprite;
    [SerializeField] float _timeToDelay;

    private Coroutine _coroutine;
    private WaitForSeconds _delay;
    private bool _isTimeOut;

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _coinSprite = _spriteRenderer.sprite;
        _delay = new WaitForSeconds(_timeToDelay);
        _isTimeOut = true;
    }

    public void HideCoin()
    {
        if (_isTimeOut)
            _spriteRenderer.sprite = null;
        else
            StopCoroutine(_coroutine);
    }

    public void GiveBackCoin()
    {
        _isTimeOut = false;
        _coroutine = StartCoroutine(Spawning());
    }

    private IEnumerator Spawning()
    {
        yield return _delay;

        _isTimeOut = true;
        _spriteRenderer.sprite = _coinSprite; ;
    }
}
