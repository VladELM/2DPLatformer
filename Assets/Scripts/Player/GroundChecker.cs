using UnityEngine;

[RequireComponent(typeof(CircleCollider2D))]

public class GroundChecker : MonoBehaviour
{
    public float Radius { get; private set; }

    private void Start()
    {
        Radius = GetComponent<CircleCollider2D>().radius;
    }
}
