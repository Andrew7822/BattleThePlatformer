using UnityEngine;

public class Hero : MonoBehaviour
{
    private const string Horizontal = "Horizontal";
    private const string Jump = "Jump";

    [SerializeField] private Transform _grooundDetector;

    private Rigidbody2D _rigidbody2D;
    private Animators _animators;
    private Animator _animator;

    private int _lives = 4;
    private int _speed = 3;
    private float _jumpForce = 8;
    private bool _isGrounded;

    private HeroMover _mover;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _animators = new Animators(_animator);
        _mover = GetComponent<HeroMover>();
    }

    private void Update()
    {
        ExploreGround();

        _animators.EnableAnimationIdle();

        if (Input.GetButton(Horizontal))
        {
            _mover.Run(transform, _speed, Horizontal);
            _animators.EnableAnimationRun();
        }

        if (Input.GetButtonDown(Jump))
        {
            _mover.Jump(_rigidbody2D, transform, _jumpForce, _isGrounded);
            _animators.EnableAnimationJump();
        }

        if (_lives == 0)
        {
            Die();
        }
    }

    public void ExploreGround()
    {
        float radius = 0.1f;
        int arrayLength = 1;

        Collider2D[] colliders = Physics2D.OverlapCircleAll(_grooundDetector.position, radius);

        for (int i = 0; i < colliders.Length; i++)
        {
            colliders[i].TryGetComponent(out Ground ground);
        }
        _isGrounded = colliders.Length > arrayLength;
    }

    public void TakeDamage()
    {
        --_lives;
    }

    public void Heal()
    {
        ++_lives;
    }

    public void Die()
    {
        Destroy(gameObject);
    }
}