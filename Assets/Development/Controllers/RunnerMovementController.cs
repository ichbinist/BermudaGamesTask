using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunnerMovementController : MonoBehaviour
{
    [FoldoutGroup("Runner Movement Settings")]
    public float MovementSpeed = 8f;

    [FoldoutGroup("Runner Movement Settings")]
    public Runner Runner;

    private void Update()
    {
        if (Runner.IsMovementStarted)
        {
            transform.position += Vector3.forward * Time.fixedDeltaTime * MovementSpeed;
        }
    }
}