using UnityEngine;

public class Animators
{
    public Animator _animator { get; private set; }

    private string _nameState = "State";

    public Animators(Animator animator)
    {
        _animator = animator;
    }

    private States State
    {
        set { _animator.SetInteger(_nameState, (int)value); }
    }

    public void EnableAnimationIdle()
    {
        State = States.idle;
    }

    public void EnableAnimationRun()
    {
        State = States.run;
    }

    public void EnableAnimationJump()
    {
        State = States.jump;
    }
}

public enum States
{
    idle,
    run,
    jump
}