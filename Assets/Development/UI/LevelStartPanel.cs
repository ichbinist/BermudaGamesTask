using DG.Tweening;
using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LevelStartPanel : MonoBehaviour
{
    [FoldoutGroup("Level Start Panel References")]
    public TextMeshProUGUI LevelStartText;
    [FoldoutGroup("Level Start Panel References")]
    public CanvasGroup CanvasGroup;

    private void Awake()
    {
        LevelStartText.transform.DOScale(Vector3.one * 1.25f, 0.75f).SetEase(Ease.Linear).SetLoops(-1, LoopType.Yoyo);
    }

    private void OnEnable()
    {
        SceneInitializationManager.Instance.OnSceneLoaded.AddListener(ShowPanel);
        LevelManager.Instance.OnLevelStarted.AddListener(HidePanel);
    }

    private void OnDisable()
    {
        if(SceneInitializationManager.Instance)
            SceneInitializationManager.Instance.OnSceneLoaded.AddListener(ShowPanel);
        if (LevelManager.Instance)
            LevelManager.Instance.OnLevelStarted.AddListener(HidePanel);
    }

    private void HidePanel()
    {
        CanvasGroup.alpha = 0;
        CanvasGroup.interactable = false;
        CanvasGroup.blocksRaycasts = false;
    }

    private void ShowPanel()
    {
        CanvasGroup.alpha = 1;
        CanvasGroup.interactable = true;
        CanvasGroup.blocksRaycasts = true;
    }
}
