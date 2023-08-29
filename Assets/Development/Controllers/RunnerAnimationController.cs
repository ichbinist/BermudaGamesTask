using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunnerAnimationController : MonoBehaviour
{
    public Animator Animator;

    private Runner runner;
    public Runner Runner { get { return (runner == null) ? runner = GetComponent<Runner>() : runner; } }

    private void OnEnable()
    {
        Runner.OnMovementStarted.AddListener(MovementStartAction);
        Runner.OnMovementStopped.AddListener(MovementStopAction);
    }

    private void OnDisable()
    {
        Runner.OnMovementStarted.RemoveListener(MovementStartAction);
        Runner.OnMovementStopped.RemoveListener(MovementStopAction);
    }

    private void MovementStartAction()
    {
        Animator.SetTrigger("Run");
    }
    private void MovementStopAction()
    {
        Animator.SetTrigger("Stop");
    }
}