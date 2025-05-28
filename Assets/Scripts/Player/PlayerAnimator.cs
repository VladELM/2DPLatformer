using UnityEngine;

[RequireComponent(typeof(Animator))]

public class PlayerAnimator : MonoBehaviour
{
    private Animator _animator;
    private int IsMoving = Animator.StringToHash(nameof(IsMoving));

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public void TurnOnMoveMode()
    {
        _animator.SetBool(IsMoving, true);
    }

    public void TurnOnIdleMode()
    {
        _animator.SetBool(IsMoving, false);
    }
}
