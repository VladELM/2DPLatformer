using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]

public class Jumper : MonoBehaviour
{
    [SerializeField] private float _jumpForce;
    [SerializeField] private GroundChecker _groundChecker;

    private Rigidbody2D _rigidbody2D;

    public bool IsJumping => !_groundChecker.IsGroundTouched;

    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    public void Jump()
    {
        if (_groundChecker.IsGroundTouched)
            _rigidbody2D.AddForce(Vector2.up * _jumpForce);
    }
}
