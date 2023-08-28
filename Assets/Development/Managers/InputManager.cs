using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

public class InputManager : Singleton<InputManager>
{
    [FoldoutGroup("Input Manager Settings")]
    [FoldoutGroup("Input Manager Settings/Tap Debug")]
    [ReadOnly]
    public Vector3 FirstTouchPosition;

    [FoldoutGroup("Input Manager Settings")]
    [FoldoutGroup("Input Manager Settings/Tap Debug")]
    [ReadOnly]
    public Vector3 LastTouchPosition;

    private void Update()
    {
        SetTouchPositions();
    }

    #region Tap
    private void SetTouchPositions()
    {
        if (Input.GetMouseButtonDown(0))
        {
            FirstTouchPosition = Input.mousePosition;
            LastTouchPosition = Input.mousePosition;
        }
        else if (Input.GetMouseButton(0))
        {
            LastTouchPosition = Input.mousePosition;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            LastTouchPosition = Input.mousePosition;
        }    
    }
    #endregion

    #region Swerve
    public Vector2 GetSwerveAmount(float swerveSpeed)
    {
        Vector2 ScreenSwerveAmount = Input.mousePosition - InputManager.Instance.FirstTouchPosition;

        Vector2 UnclampedWorldSwerveAmount = ScreenSwerveAmount / Screen.width;

        Vector2 ClampedSwerveAmount = new Vector2(UnclampedWorldSwerveAmount.x * swerveSpeed, 0f);

        return ClampedSwerveAmount;
    }
    #endregion
}
