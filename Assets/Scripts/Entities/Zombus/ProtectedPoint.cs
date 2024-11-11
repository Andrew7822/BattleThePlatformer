using System;
using UnityEngine;

public class ProtectedPoint : MonoBehaviour
{
    public event Action<Hero> RunToHero;
    public event Action StopRunToHero;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.TryGetComponent(out Hero hero))
        {
            RunToHero.Invoke(hero);
        }
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.TryGetComponent(out Hero hero))
        {
            StopRunToHero.Invoke();
        }
    }
}