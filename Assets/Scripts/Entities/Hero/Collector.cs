using UnityEngine;

public class Collector : MonoBehaviour
{
    [SerializeField] private Hero _hero;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.TryGetComponent(out MedKid medKid))
        {
            _hero.Heal();
        }
        else if (collision.collider.TryGetComponent(out Patroler patroler))
        {
            _hero.TakeDamage();
        }
    }
}