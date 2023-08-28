using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class ObstacleRewardController : MonoBehaviour
{
    [FoldoutGroup("Obstacle Reward Settings")]
    public int RewardCount = 0;
    [FoldoutGroup("Obstacle Reward Settings")]
    public Reward RewardPrefab;
    [FoldoutGroup("Obstacle Reward Settings")]
    public Transform RewardPrefabHolder;

    [FoldoutGroup("Obstacle Reward Settings/Reward Positioning")]
    public float RewardStartHeight = 3.75f;
    [FoldoutGroup("Obstacle Reward Settings/Reward Positioning")]
    public float RewardHeightIncrement = 0.19f;

    [FoldoutGroup("Obstacle Reward Settings/Debug")]
    [ReadOnly]
    public List<Reward> Rewards = new List<Reward>();

    private Obstacle obstacle;
    public Obstacle Obstacle { get { return (obstacle == null) ? obstacle = GetComponent<Obstacle>() : obstacle; }}   
    
    private void OnEnable()
    {
        InitializeRewards();
        Obstacle.OnObstacleDestroyed.AddListener(DropRewards);
    }

    private void OnDisable()
    {
        Obstacle.OnObstacleDestroyed.RemoveListener(DropRewards);
    }

    private void InitializeRewards()
    {
        for (int i = 0; i < RewardCount; i++)
        {
            Reward localReward = Instantiate(RewardPrefab, RewardPrefabHolder);
            localReward.transform.localPosition = Vector3.up * RewardStartHeight + Vector3.up * RewardHeightIncrement * i;
            Rewards.Add(localReward);
        }
    }

    public void DropRewards()
    {
        for (int i = 0; i < Rewards.Count; i++)
        {
            float heightBeforeAnimation = Rewards[i].transform.localPosition.y + 0.5f;
            Reward localReward = Rewards[i];
            localReward.transform.DOLocalMoveY(heightBeforeAnimation - RewardStartHeight, 0.6f).SetEase(Ease.OutBounce).SetDelay(i*0.05f).OnComplete(()=> localReward.IsCollectable = true);
            localReward.transform.DOShakeRotation(0.6f, 30f);
        }
    }
}