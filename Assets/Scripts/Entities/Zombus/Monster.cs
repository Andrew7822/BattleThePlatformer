using UnityEngine;

public class Monster : MonoBehaviour
{
    [SerializeField] private HealthHero _lifeMonster;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.TryGetComponent(out Hero hero))
        {
            _lifeMonster.TakeDamage();
        }
    }
}