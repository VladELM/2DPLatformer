using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private InputReader _inputReader;
    [SerializeField] private Rotator _rotator;
    [SerializeField] private Mover _mover;
    [SerializeField] private Jumper _jumper;
    [SerializeField] private PlayerAnimator _playerAnimator;

    private void FixedUpdate()
    {
        if (_inputReader.Direction != 0)
        {
            _rotator.RotatePlayer(_inputReader.Direction);
            _mover.Move(_inputReader.Direction);
        }

        if (_inputReader.IsJump)
            _jumper.Jump();
    }

    private void Update()
    {
        if (_jumper.IsJumping)
        {
            if (_inputReader.IsMoveLeft || _inputReader.IsMoveRight)
                _playerAnimator.TurnOnIdleMode();
        }
        else
        {
            if (_inputReader.IsMoveLeft || _inputReader.IsMoveRight)
                _playerAnimator.TurnOnMoveMode();

            if (_inputReader.IsIdleLeft || _inputReader.IsIdleRight)
                _playerAnimator.TurnOnIdleMode();
        }
    }
}
