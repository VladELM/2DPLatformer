using System.Collections;
using System.Collections.Generic;
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

        IsMoveLeft = Input.GetKey(KeyCode.A);
        IsMoveRight = Input.GetKey(KeyCode.D);

        IsIdleLeft = Input.GetKeyUp(KeyCode.A);
        IsIdleRight = Input.GetKeyUp(KeyCode.D);

        IsJump = Input.GetKey(KeyCode.Space);
    }
}
