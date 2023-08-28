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

    [HideInInspector]
    public UnityEvent OnCharacterBounce = new UnityEvent();
    [HideInInspector]
    public UnityEvent OnDamageTaken = new UnityEvent();

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
    }
    
    private void LevelFinishedAction()
    {
        IsMovementStarted = false;
    }
}