using UnityEngine;

public class Patroler : MonoBehaviour
{
    [SerializeField] private PatrollerFolowing _patrollerFolowing;
    [SerializeField] private MonsterMover _monsterMover;
    [SerializeField] private ProtectedPoint _protectedPoint;

    private int _lives = 4;

    private void OnEnable()
    {
        _protectedPoint.RunToHero += EnableFolovingState;
        _protectedPoint.StopRunToHero += EnableMoverState;
    }

    private void OnDisable()
    {
        _protectedPoint.RunToHero -= EnableFolovingState;
        _protectedPoint.StopRunToHero -= EnableMoverState;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.TryGetComponent(out Hero hero))
        {
            TakeDamage();
        }

        if (_lives == 0)
        {
            Die();
        }
    }

    public void TakeDamage()
    {
        _lives--;
    }

    public void Die()
    {
        Destroy(gameObject);
    }

    public void EnableFolovingState(Hero hero)
    {
        _patrollerFolowing.enabled = true;
        _monsterMover.enabled = false;

        _patrollerFolowing.RunToHero(hero);
    }

    public void EnableMoverState()
    {
        _monsterMover.enabled = true;
        _patrollerFolowing.enabled = false;
    }
}