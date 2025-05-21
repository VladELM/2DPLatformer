using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    [SerializeField] private float _speed;

    public void Move(float direction)
    {
        transform.Translate(Vector2.right * direction * _speed * Time.deltaTime);
    }
}
