using UnityEngine;

public class Collector : MonoBehaviour
{
    [SerializeField] private HealthHero _life;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.TryGetComponent(out MedKid medKid))
        {
            _life.Heal();
        }
        else if (collision.collider.TryGetComponent(out Monster patroler))
        {
            _life.TakeDamage();
        }
    }
}