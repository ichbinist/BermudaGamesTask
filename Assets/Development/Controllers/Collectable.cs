using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    [FoldoutGroup("Reward Settings")]
    public RewardType RewardType;
    [FoldoutGroup("Reward Settings")]
    [ShowIf("IsCoinReward")]
    public int CoinRewardAmount;
    [FoldoutGroup("Reward Settings")]
    public bool IsCollectable = false;
    public bool IsCoinReward { get { return(RewardType == RewardType.Currency) ? true:false; } }
}

public enum RewardType
{
    Currency,
    PowerUp
}