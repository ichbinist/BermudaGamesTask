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
        Runner.OnDamageTaken.AddListener(HitAction);
        Runner.OnWealthChanged.AddListener(WealthChangeAction);
    }

    private void OnDisable()
    {
        Runner.OnMovementStarted.RemoveListener(MovementStartAction);
        Runner.OnMovementStopped.RemoveListener(MovementStopAction);
        Runner.OnDamageTaken.RemoveListener(HitAction);
        Runner.OnWealthChanged.RemoveListener(WealthChangeAction);
    }

    private void MovementStartAction()
    {
        Animator.SetBool("IsHappy", Runner.GetCharacterMoralState());
        Animator.SetTrigger("Run");
    }

    private void WealthChangeAction(bool isHappy)
    {
        if (Runner.IsMovementStarted)
        {
            if (isHappy)
            {
                SpinAction();
            }
            else
            {
                HitAction();
            }
        }
    }

    private void HitAction()
    {
        Animator.SetBool("IsHappy", Runner.GetCharacterMoralState());
        Animator.SetTrigger("Hit");
    }

    private void SpinAction()
    {
        Animator.SetBool("IsHappy", Runner.GetCharacterMoralState());
        Animator.SetTrigger("Spin");
    }

    private void MovementStopAction()
    {
        Animator.SetBool("IsHappy", Runner.GetCharacterMoralState());
        Animator.SetTrigger("Ending");
    }
}