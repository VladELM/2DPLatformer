using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private InputReader _inputReader;
    [SerializeField] private Mover _mover;
    [SerializeField] private Jumper _jumper;
    [SerializeField] private AnimationOperator _animationOperator;

    private void FixedUpdate()
    {
        if (_inputReader.Direction != 0)
            _mover.Move(_inputReader.Direction);

        if (_inputReader.IsJump)
            _jumper.Jump();
    }

    private void Update()
    {
        if (_jumper.IsJumping)
        {
            if (_inputReader.IsMoveLeft || _inputReader.IsMoveRight)
            {
                _animationOperator.TurnOnIdleMode();
                _animationOperator.ToggleIdleAnimation(_inputReader.IsMoveLeft, _inputReader.IsMoveRight);
            }
        }
        else
        {
            if (_inputReader.IsMoveLeft || _inputReader.IsMoveRight)
            {
                _animationOperator.TurnOnMoveMode();
                _animationOperator.ToggleMoveAnimation(_inputReader.Direction);
            }

            if (_inputReader.IsIdleLeft || _inputReader.IsIdleRight)
            {
                _animationOperator.TurnOnIdleMode();
                _animationOperator.ToggleIdleAnimation(_inputReader.IsIdleLeft, _inputReader.IsIdleRight);
            }
        }
    }
}
