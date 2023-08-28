using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunnerSwerveController : MonoBehaviour
{
    [FoldoutGroup("Runner Swerve Settings")]
    public float SwerveSpeed = 6f;

    [FoldoutGroup("Runner Swerve Settings")]
    public float SwerveLimit = 3.7f;

    [FoldoutGroup("Runner Swerve Settings")]
    public Runner Runner;

    private Vector3 positionBeforeSwerve;

    private void Update()
    {
        if (Runner.IsMovementStarted)
        {
            if (Input.GetMouseButtonDown(0))
            {
                positionBeforeSwerve = transform.localPosition;
            }
            if (Input.GetMouseButton(0))
            {
                transform.localPosition = Vector3.Lerp(transform.localPosition, new Vector3(Mathf.Clamp(positionBeforeSwerve.x + InputManager.Instance.GetSwerveAmount(SwerveSpeed).x, -SwerveLimit, SwerveLimit), transform.localPosition.y, 0f), Time.deltaTime * SwerveSpeed * 2.5f);
            }
            if (Input.GetMouseButtonUp(0))
            {
                positionBeforeSwerve = transform.localPosition;
            }
        }
    }
}