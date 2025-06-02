using UnityEngine;

[RequireComponent(typeof(Animator))]

public class PlayerAnimator : MonoBehaviour
{
    [SerializeField] private string _movingParameter;

    private Animator _animator;
    private int _movingParameterHashed;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _movingParameterHashed =  Animator.StringToHash(_movingParameter);
    }

    public void TurnOnMoveMode()
    {
        _animator.SetBool(_movingParameterHashed, true);
    }

    public void TurnOnIdleMode()
    {
        _animator.SetBool(_movingParameterHashed, false);
    }
}
