using UnityEngine;

public class MedKid : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.TryGetComponent(out Hero hero))
        {
            Destroy(gameObject);
        }
    }
}