using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ObstacleHealthController : MonoBehaviour
{
    private Obstacle obstacle;
    public Obstacle Obstacle { get { return (obstacle == null) ? obstacle = GetComponent<Obstacle>() : obstacle; } }

    public TextMeshProUGUI HealthText;

    private void OnEnable()
    {
        HealthText.SetText(Obstacle.Health.ToString());
    }

    [Button]
    public void DecreaseHealth(int damage = 1)
    {
        Obstacle.Health -= damage;
        if(Obstacle.Health <= 0)
        {
            DestroyObstacle();
        }
        else
        {
            HealthText.SetText(Obstacle.Health.ToString());
        }
    }

    public void DestroyObstacle()
    {
        Obstacle.OnObstacleDestroyed.Invoke();
        Obstacle.IsInteractable = false;
        transform.GetChild(0).gameObject.SetActive(false);
    }
}