using DG.Tweening;
using PathCreation;
using PathCreation.Examples;
using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunnerMovementController : MonoBehaviour
{
    [FoldoutGroup("Runner Movement Settings")]
    public float MovementSpeed = 8f;

    private float localMovementSpeed;

    [FoldoutGroup("Runner Movement Settings")]
    public Runner Runner;

    private PathCreator pathCreator;

    public PathCreator PathCreator { get { return(pathCreator == null) ? pathCreator = FindObjectOfType<PathCreator>() : pathCreator; } }


    private PathFollower pathFollower;

    public PathFollower PathFollower { get { return (pathFollower == null) ? pathFollower = GetComponent<PathFollower>() : pathFollower; } }

    private void OnEnable()
    {
        Runner.OnDamageTaken.AddListener(DamageTakenAction);
        localMovementSpeed = MovementSpeed;
        PathFollower.pathCreator = PathCreator;
        Runner.OnMovementStopped.AddListener(StopMovement);
    }

    private void OnDisable()
    {
        Runner.OnDamageTaken.RemoveListener(DamageTakenAction);
        Runner.OnMovementStopped.RemoveListener(StopMovement);
    }

    private void DamageTakenAction()
    {
        float localZ = transform.position.z;
        transform.DOMoveZ(localZ - 3f, 0.5f).OnStart(() => localMovementSpeed = 0).OnComplete(() => localMovementSpeed = MovementSpeed);
    }

    private void StopMovement()
    {
        localMovementSpeed = 0;
        PathFollower.speed = 0;
    }

    private void Update()
    {
        if (Runner.IsMovementStarted)
        {
            PathFollower.speed = localMovementSpeed;
        }
    }
}