using UnityEngine;

public class HeroMover : MonoBehaviour
{
    [SerializeField] private CheckGround _checkGround;
    [SerializeField] private InputReader _inputReader;

    private readonly int _degreesRotation = 180;

    public void Run(Transform transform)
    {
        int speed = 3;

        if (_inputReader.HorizontalDirection > 0)
        {
            Flip(0, transform);
        }

        if (_inputReader.HorizontalDirection < 0)
        {
            Flip(_degreesRotation, transform);
        }

        Vector3 directionVector = Vector3.right * _inputReader.HorizontalRawDirection;

        transform.position = Vector3.MoveTowards(transform.position, transform.position + directionVector, speed * Time.deltaTime);
    }

    public void Jump(Rigidbody2D rigidbody2D, Transform transform)
    {
        float jumpForce = 8;

        if (_checkGround.ExploreGround())
        {
            rigidbody2D.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);
        }
    }

    private void Flip(int degreesRotation, Transform transform)
    {
        Quaternion _rotation = transform.rotation;

        _rotation.y = degreesRotation;
        transform.rotation = _rotation;
    }
}