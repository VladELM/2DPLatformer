using UnityEngine;

public class EnemyRotator : MonoBehaviour
{
    private float _rightRotationY;
    private float _leftRotationY = 180;

    private void Awake()
    {
        _rightRotationY = transform.rotation.y;
    }

    public void Rotate(float targetValueX)
    {
        float rotationY = _rightRotationY;

        if (transform.position.x > targetValueX)
            rotationY = _leftRotationY;
        else if (transform.position.x < targetValueX)
            rotationY = _rightRotationY;

        transform.rotation = Quaternion.Euler(transform.rotation.x, rotationY, transform.rotation.z);
    }
}
