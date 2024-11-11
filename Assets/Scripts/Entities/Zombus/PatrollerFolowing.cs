using UnityEngine;

public class PatrollerFolowing : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private ProtectedPoint _protectedPoint;

    private Transform _target;

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, _target.position, _speed * Time.deltaTime);
    }

    private void OnEnable()
    {
        _protectedPoint.RunToHero += RunToHero;
        _protectedPoint.StopRunToHero += StopRunToHero;
    }

    private void OnDisable()
    {
        _protectedPoint.RunToHero -= RunToHero;
        _protectedPoint.StopRunToHero -= StopRunToHero;
    }

    public void RunToHero(Hero hero)
    {
        _target = hero.transform;
    }

    public   void StopRunToHero()
    {
        _target = _spawnPoint.transform;
    }
}
