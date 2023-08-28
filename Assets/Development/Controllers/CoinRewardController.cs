using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinRewardController : MonoBehaviour
{
    private Reward reward;
    public Reward Reward { get { return(reward == null) ? reward = GetComponent<Reward>() : reward; } }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponentInParent<Runner>() && Reward.IsCollectable && Reward.RewardType == RewardType.Currency)
        {
            CurrencyManager.Instance.AddTemporaryCurrency(Reward.CoinRewardAmount);
            gameObject.SetActive(false);
        }
    }
}