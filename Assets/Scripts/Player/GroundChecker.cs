using UnityEngine;

[RequireComponent(typeof(CircleCollider2D))]

public class GroundChecker : MonoBehaviour
{
    [SerializeField] private LayerMask _layerMask;

    public float Radius { get; private set; }
    public bool IsGroundTouched => Physics2D.OverlapCircle(transform.position, Radius, _layerMask);

    private void Start()
    {
        Radius = GetComponent<CircleCollider2D>().radius;
    }
}
