using UnityEngine;

[RequireComponent(typeof(Animator))]

public class AnimationOperator : MonoBehaviour
{
    [SerializeField] string _moveBlendParameter;
    [SerializeField] string _idleBlendParameter;
    [SerializeField] string _moveBoolParameter;
    [SerializeField] float _moveLeftValue = 0;
    [SerializeField] float _moveRightValue = 1;
    [SerializeField] float _idleLeftValue = 0;
    [SerializeField] float _idleRightValue = 1;

    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public void TurnOnMoveMode()
    {
        _animator.SetBool(_moveBoolParameter, true);
    }

    public void TurnOnIdleMode()
    {
        _animator.SetBool(_moveBoolParameter, false);
    }

    public void ToggleMoveAnimation(float direction)
    {
        if (direction < 0)
            _animator.SetFloat(_moveBlendParameter, _moveLeftValue);
        else if (direction > 0)
            _animator.SetFloat(_moveBlendParameter, _moveRightValue);
    }

    public void ToggleIdleAnimation(bool isIdleLeft, bool isIdleRight)
    {
        if (isIdleLeft || isIdleRight == false)
            _animator.SetFloat(_idleBlendParameter, _idleLeftValue);
        else if (isIdleLeft == false || isIdleRight)
            _animator.SetFloat(_idleBlendParameter, _idleRightValue);
    }
}
