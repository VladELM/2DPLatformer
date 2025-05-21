using System;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]

public class Coin : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _spriteRenderer;
    [SerializeField] private Sprite _coinSprite;

    private bool _isExited;

    public event Action<Coin> Touched;

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _coinSprite = _spriteRenderer.sprite;
        _isExited = true;
    }

    private void OnDestroy()
    {
        Touched = null;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.TryGetComponent(out Player component))
        {
            DisableSprite();
            _isExited = false;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (_isExited == false)
        {
            if (other.gameObject.TryGetComponent(out Player component))
            {
                _isExited = true;
                Touched?.Invoke(this);
            }
        }
    }

    public void EnableSprite()
    {
        if (_isExited)
            _spriteRenderer.sprite = _coinSprite;
    }

    public void DisableSprite()
    {
        _spriteRenderer.sprite = null;
    }
}
