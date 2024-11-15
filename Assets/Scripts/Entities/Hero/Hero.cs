using UnityEngine;

public class Hero : MonoBehaviour
{
    [SerializeField] private InputReader _inputReader;

    private Rigidbody2D _rigidbody2D;
    private Animators _animators;
    private Animator _animator;

    private HeroMover _mover;

    private void Awake()
    {
        _animator = GetComponentInChildren<Animator>();
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _animators = new Animators(_animator);
        _mover = GetComponent<HeroMover>();
    }

    private void Update()
    {
        _animators.EnableAnimationIdle();

        if (_inputReader.PressedHorizontal)
        {
            _mover.Run(transform);
            _animators.EnableAnimationRun();
        }

        if (_inputReader.PressedJump)
        {
            _mover.Jump(_rigidbody2D, transform);
            _animators.EnableAnimationJump();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.TryGetComponent(out MedKid medKid))
        {
            medKid.Die();
        }
    }
}