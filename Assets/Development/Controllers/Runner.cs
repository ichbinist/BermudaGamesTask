using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Runner : MonoBehaviour
{
    [FoldoutGroup("Runner Settings")]
    [ReadOnly]
    public bool IsMovementStarted;

    [FoldoutGroup("Runner Settings")]
    [ReadOnly]
    public CharacterWealthState CharacterWealthState = CharacterWealthState.Average;

    [HideInInspector]
    public UnityEvent OnCharacterBounce = new UnityEvent();
    [HideInInspector]
    public UnityEvent OnDamageTaken = new UnityEvent();
    [HideInInspector]
    public UnityEvent OnMovementStarted = new UnityEvent();
    [HideInInspector]
    public UnityEvent OnMovementStopped = new UnityEvent();
    [HideInInspector]
    public WealthStateEvent OnWealthChanged = new WealthStateEvent();

    private void OnEnable()
    {
        LevelManager.Instance.OnLevelStarted.AddListener(LevelStartedAction);
        LevelManager.Instance.OnLevelFinished.AddListener(LevelFinishedAction);
    }

    private void OnDisable()
    {
        if (LevelManager.Instance)
        {
            LevelManager.Instance.OnLevelStarted.RemoveListener(LevelStartedAction);
            LevelManager.Instance.OnLevelFinished.RemoveListener(LevelFinishedAction);
        }
    }

    private void LevelStartedAction()
    {
        IsMovementStarted = true;
        OnMovementStarted.Invoke();
    }
    
    private void LevelFinishedAction()
    {
        IsMovementStarted = false;
        OnMovementStopped.Invoke();
        GameManager.Instance.OnGameComplete.Invoke(GetCharacterMoralState());
    }

    public bool GetCharacterMoralState()
    {
        bool localState = false;
        switch (CharacterWealthState)
        {
            case CharacterWealthState.Poor:
                localState = false;
                break;
            case CharacterWealthState.Average:
                localState = true;
                break;
            case CharacterWealthState.Rich:
                localState = true;
                break;
            default:
                break;
        }
        return localState;
    }
}

public class WealthStateEvent : UnityEvent<bool> { }

public enum CharacterWealthState
{
    Poor,
    Average,
    Rich
}