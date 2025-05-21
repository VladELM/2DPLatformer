using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]

public class Jumper : MonoBehaviour
{
    [SerializeField] private float _jumpForce;
    [SerializeField] private GroundChecker _groundChecker;
    [SerializeField] private LayerMask _layerMask;

    public bool IsJumping => ! IsGroundTouched();

    private Rigidbody2D _rigidbody2D;

    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    public void Jump()
    {
        //Debug.Log()

        if (IsGroundTouched())
            _rigidbody2D.AddForce(Vector2.up * _jumpForce);
    }

    private bool IsGroundTouched()
    {
        return Physics2D.OverlapCircle(_groundChecker.transform.position, _groundChecker.Radius, _layerMask);
    }
}
