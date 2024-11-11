using UnityEngine;

public class InputReader : MonoBehaviour
{
    private const string Horizontal = "Horizontal";
    private const string Jump = "Jump";

    public bool PressedHorizontal => Input.GetButton(Horizontal);

    public bool PressedJump => Input.GetButtonDown(Jump);

    public float HorizontalDirection => Input.GetAxis(Horizontal);

    public float HorizontalRawDirection => Input.GetAxisRaw(Horizontal);
}