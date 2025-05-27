using UnityEngine;

public class CoinsCollector : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.TryGetComponent(out Coin coin))
            coin.HideCoin();
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.TryGetComponent(out Coin coin))
            coin.GiveBackCoin();
    }
}
