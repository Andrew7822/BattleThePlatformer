using UnityEngine;

public class EnaibleState : MonoBehaviour
{
    [SerializeField] private ProtectedPoint _protectedPoint;
    [SerializeField] private PatrollerFolowing _patrollerFolowing;
    [SerializeField] private MonsterMover _monsterMover;

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
