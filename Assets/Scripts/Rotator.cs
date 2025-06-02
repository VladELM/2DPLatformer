using UnityEngine;

public class Rotator : MonoBehaviour
{
    private float _rightRotationY;
    private float _leftRotationY = 180f;

    private void Awake()
    {
        _rightRotationY = transform.rotation.y;
    }

    public void RotatePlayer(float direction)
    {
        float rotationY = _rightRotationY;

        if (direction < 0)
            rotationY = _leftRotationY;
        else if (direction > 0)
            rotationY = _rightRotationY;

        transform.rotation = Quaternion.Euler(transform.rotation.x, rotationY, transform.rotation.z);
    }

    public void RotateEnemy(float targetValueX)
    {
        float rotationY = _rightRotationY;

        if (transform.position.x > targetValueX)
            rotationY = _leftRotationY;
        else if (transform.position.x < targetValueX)
            rotationY = _rightRotationY;

        transform.rotation = Quaternion.Euler(transform.rotation.x, rotationY, transform.rotation.z);
    }
}
