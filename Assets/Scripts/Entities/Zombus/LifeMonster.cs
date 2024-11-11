using UnityEngine;

public class LifeMonster : MonoBehaviour
{
    private int _lives = 4;

    public void TakeDamage()
    {
        _lives--;

        if (_lives == 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Destroy(gameObject);
    }
}
