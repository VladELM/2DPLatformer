using UnityEngine;

[RequireComponent(typeof(Animator))]

public class AnimationOperator : MonoBehaviour
{
    private Animator _animator;
    private int IsMoving = Animator.StringToHash(nameof(IsMoving));
    private float _defaultScaleX;


    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _defaultScaleX = transform.localScale.x;
    }

    public void TurnOnMoveMode()
    {
        _animator.SetBool(IsMoving, true);
    }

    public void TurnOnIdleMode()
    {
        _animator.SetBool(IsMoving, false);
    }

    public void ToggleMoveAnimation(float direction)
    {
        float xScale = _defaultScaleX;

        if (direction < 0)
            xScale *= (-1);
        else if (direction > 0)
            xScale = _defaultScaleX;

        transform.localScale = new Vector3(xScale, transform.localScale.y, transform.localScale.z);
    }

    public void ToggleIdleAnimation(bool isIdleLeft, bool isIdleRight)
    {
        float xScale = _defaultScaleX;

        if (isIdleLeft || isIdleRight == false)
            xScale *= (-1);
        else if (isIdleLeft == false || isIdleRight)
            xScale = _defaultScaleX;

        transform.localScale = new Vector3(xScale, transform.localScale.y, transform.localScale.z);
    }
}
