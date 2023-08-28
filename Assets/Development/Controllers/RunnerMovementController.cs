using DG.Tweening;
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

    private void OnEnable()
    {
        Runner.OnDamageTaken.AddListener(DamageTakenAction);
        localMovementSpeed = MovementSpeed;
    }

    private void OnDisable()
    {
        Runner.OnDamageTaken.RemoveListener(DamageTakenAction);
    }

    private void DamageTakenAction()
    {
        float localZ = transform.position.z;
        transform.DOMoveZ(localZ - 3f, 0.5f).OnStart(() => localMovementSpeed = 0).OnComplete(() => localMovementSpeed = MovementSpeed);
    }

    private void Update()
    {
        if (Runner.IsMovementStarted)
        {
            transform.position += Vector3.forward * Time.fixedDeltaTime * localMovementSpeed;
        }
    }
}