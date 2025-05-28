using UnityEngine;

public class InputReader : MonoBehaviour
{
    private string Horizontal = nameof(Horizontal);

    public float Direction { get; private set; }
    public bool IsMoveLeft { get; private set; }
    public bool IsMoveRight { get; private set; }
    public bool IsIdleLeft { get; private set; }
    public bool IsIdleRight { get; private set; }
    public bool IsJump { get; private set; }

    private void Update()
    {
        Direction = Input.GetAxis(Horizontal);

        IsMoveLeft = Input.GetKey(Constants.ButtonA);
        IsMoveRight = Input.GetKey(Constants.ButtonD);

        IsIdleLeft = Input.GetKeyUp(Constants.ButtonA);
        IsIdleRight = Input.GetKeyUp(Constants.ButtonD);

        IsJump = Input.GetKey(Constants.ButtonSpace);
    }
}
