using UnityEngine;

public class Patroler : Entity
{
    [SerializeField] private float _speed;
    [SerializeField] private int _positionOfPatrol;
    [SerializeField] private Transform _point;
    private int _lives = 2;

    [SerializeField] private Transform _hero;
    [SerializeField] private float _stopingDistance;

    private bool _movingRight;
    private bool _chill = false;
    private bool _angry = false;
    private bool _goBack = false;

    private string _tagHero = "Hero";

    public void Start()
    {
        _hero = GameObject.FindGameObjectWithTag(_tagHero).transform;
    }

    public void Update()
    {
        DetermineState();

        if (_chill == true)
        {
            Chill();
        }
        else if (_angry == true)
        {
            Angry();
        }
        else if (_goBack == true)
        {
            GoBack();
        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Hero")
        {
            GetDamage();
        }
        if (_lives == 0)
        {
            Die();
        }
    }

    private void Chill()
    {
        Flip();

        if (_movingRight)
        {
            transform.position = new Vector2(transform.position.x + _speed * Time.deltaTime, transform.position.y);
        }
        else
        {
            transform.position = new Vector2(transform.position.x - _speed * Time.deltaTime, transform.position.y);
        }
    }

    private void Angry()
    {
        transform.position = Vector2.MoveTowards(transform.position, _hero.position, _speed * Time.deltaTime);
    }

    private void GoBack()
    {
        transform.position = Vector2.MoveTowards(transform.position, _point.position, _speed * Time.deltaTime);
    }

    private void Flip()
    {
        if (transform.position.x > _point.position.x + _positionOfPatrol)
        {
            _movingRight = false;
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }

        else if (transform.position.x < _point.position.x - _positionOfPatrol)
        {
            _movingRight = true;
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
    }

    private void DetermineState()
    {
        if (Vector2.Distance(transform.position, _point.position) < _positionOfPatrol && _angry == false)
        {
            _chill = true;
        }

        if (Vector2.Distance(transform.position, _hero.position) < _stopingDistance)
        {
            _angry = true;
            _chill = false;
            _goBack = false;
        }

        if (Vector2.Distance(transform.position, _hero.position) > _stopingDistance)
        {
            _goBack = true;
            _angry = false;
        }
    }

    public override void GetDamage()
    {
        _lives--;
    }

    public override void Die()
    {
        Destroy(gameObject);
    }
}