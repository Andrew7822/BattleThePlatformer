using UnityEngine;

public class CheckGround : MonoBehaviour
{
    [SerializeField] private Transform _grooundDetector;

    public bool ExploreGround()
    {
        float radius = 0.1f;
        int arrayLength = 1;

        Collider2D[] colliders = Physics2D.OverlapCircleAll(_grooundDetector.position, radius);

        bool isGrounded = colliders.Length > arrayLength;

        return isGrounded;
    }
}
