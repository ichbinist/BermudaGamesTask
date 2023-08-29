using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class RunnerSwerveController : MonoBehaviour
{
    [FoldoutGroup("Runner Swerve Settings")]
    public float SwerveSpeed = 6f;
    private float localSwerveSpeed;

    [FoldoutGroup("Runner Swerve Settings")]
    public float SwerveLimit = 3.7f;

    [FoldoutGroup("Runner Swerve Settings")]
    public Runner Runner;

    private Vector3 positionBeforeSwerve;


    private void OnEnable()
    {
        Runner.OnDamageTaken.AddListener(DamageTakenAction);
        localSwerveSpeed = SwerveSpeed;
    }

    private void OnDisable()
    {
        Runner.OnDamageTaken.RemoveListener(DamageTakenAction);
    }
    private void DamageTakenAction()
    {
        StartCoroutine(DelayedDamageTakenCoroutine());
    }

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
                transform.localPosition = Vector3.Lerp(transform.localPosition, new Vector3(Mathf.Clamp(positionBeforeSwerve.x + InputManager.Instance.GetSwerveAmount(localSwerveSpeed).x, -SwerveLimit, SwerveLimit), transform.localPosition.y, 0f), Time.deltaTime * SwerveSpeed * 2.5f);
            }

            RotateCharacter();

            if (Input.GetMouseButtonUp(0))
            {
                positionBeforeSwerve = transform.localPosition;
            }  
        }
    }

    private void RotateCharacter()
    {
        if (Input.GetMouseButton(0))
        {
            float distance = positionBeforeSwerve.x + InputManager.Instance.GetSwerveAmount(localSwerveSpeed).x;
            float rotationDistance = distance - transform.localPosition.x;
            transform.localRotation = Quaternion.Lerp(transform.localRotation, Quaternion.Euler(0f, Mathf.Clamp(120f * (rotationDistance), -45f, 45f), 0f), Time.deltaTime * 20f);
        }
        else
        {
            transform.localRotation = Quaternion.Lerp(transform.localRotation, Quaternion.identity, Time.deltaTime * 10f);
        }
    }

    private IEnumerator DelayedDamageTakenCoroutine()
    {
        localSwerveSpeed = 0;
        yield return new WaitForSeconds(0.5f);
        localSwerveSpeed = SwerveSpeed;
    }
}