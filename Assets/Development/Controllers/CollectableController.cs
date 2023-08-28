using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableController : MonoBehaviour
{
    private Collectable reward;
    public Collectable Reward { get { return(reward == null) ? reward = GetComponent<Collectable>() : reward; } }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponentInParent<Runner>() && Reward.IsCollectable && Reward.RewardType == RewardType.Currency)
        {
            CurrencyManager.Instance.AddTemporaryCurrency(Reward.CoinRewardAmount);
            gameObject.SetActive(false);
        }
    }
}