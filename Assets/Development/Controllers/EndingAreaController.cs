using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndingAreaController : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Runner runner = other.GetComponentInParent<Runner>();
        if(runner != null)
        {
            LevelManager.Instance.FinishLevel();
        }
    }
}
