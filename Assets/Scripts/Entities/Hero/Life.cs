using UnityEngine;

public class Life : MonoBehaviour
{
    private int _lives = 4;

    public void TakeDamage()
    {
        --_lives;

        if (_lives == 0)
        {
            Die();
        }
    }

    public void Heal()
    {
        _lives++;
    }

    private void Die()
    {
        Destroy(gameObject);
    }
}