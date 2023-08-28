using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleCollisionController : MonoBehaviour
{
    private bool isCollided;
    [FoldoutGroup("Obstacle Collision Settings")]
    public int ObstacleDamageAmount = -10;

    private void OnTriggerEnter(Collider other)
    {
        if (!isCollided)
        {
            Runner collidedRunner = other.GetComponentInParent<Runner>();
            
            if(collidedRunner != null)
            {
                isCollided = true;
                CurrencyManager.Instance.AddTemporaryCurrency(ObstacleDamageAmount);
                collidedRunner.OnDamageTaken.Invoke();
            }
        }
    }
}