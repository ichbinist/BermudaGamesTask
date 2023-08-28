using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Obstacle : MonoBehaviour
{
    [HideInInspector]
    public UnityEvent OnObstacleDestroyed = new UnityEvent();

    [FoldoutGroup("Obstacle Settings")]
    [ReadOnly]
    public bool IsInteractable = true;
    [FoldoutGroup("Obstacle Settings")]
    public int Health = 1;
}