using UnityEngine;
using System;

public class HealthHero : MonoBehaviour
{
    [SerializeField] private int _health;

    public float maxHealthChar { get; private set; }

    public float health { get; private set; }

    public event Action ChangingHealth;

    private void Awake()
    {
        maxHealthChar = _health;
        health = maxHealthChar;
    }

    public void TakeDamage()
    {
        --health;

        if (health == 0)
        {
            Die();
        }

        ChangingHealth.Invoke();
    }

    public void Heal()
    {
        health++;

        ChangingHealth.Invoke();
    }

    private void Die()
    {
        Destroy(gameObject);
    }
}