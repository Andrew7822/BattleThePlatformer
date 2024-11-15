using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SmoothHealthBar : MonoBehaviour
{
    [SerializeField] private HealthHero _health;

    private Coroutine _coroutine;
    private Image _healthBarSmooth;

    private float _speed = 0.3f;
    private float _speedCoefficient = 0.01f;

    private void Awake()
    {
        _healthBarSmooth = GetComponent<Image>();
    }

    private void OnEnable()
    {
        _health.ChangingHealth += FillHealth;
    }

    private void OnDisable()
    {
        _health.ChangingHealth -= FillHealth;
    }

    private void FillHealth()
    {
        if (_coroutine != null)
        {
            StopCoroutine(_coroutine);
        }

        _coroutine = StartCoroutine(SmoothFill());
    }

    private IEnumerator SmoothFill()
    {
        float trueValue = _health.health / _health.maxHealthChar;

        while (Mathf.Abs(_healthBarSmooth.fillAmount - trueValue) > _speedCoefficient)
        {
            _healthBarSmooth.fillAmount = Mathf.MoveTowards(_healthBarSmooth.fillAmount, trueValue, _speed * Time.deltaTime);

            yield return null;
        }
    }
}