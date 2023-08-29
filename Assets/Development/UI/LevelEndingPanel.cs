using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelEndingPanel : MonoBehaviour
{
    [FoldoutGroup("Level Ending Panel References")]
    public CanvasGroup SuccessPanel, FailPanel;
    [FoldoutGroup("Level Ending Panel References")]
    public Button SuccessButton, FailButton;

    private void OnEnable()
    {
        GameManager.Instance.OnGameComplete.AddListener(GameCompleteAction);
        SuccessButton.onClick.AddListener(() => GameManager.Instance.CompleteStage(true));
        FailButton.onClick.AddListener(() => GameManager.Instance.CompleteStage(false));
        SceneInitializationManager.Instance.OnSceneLoaded.AddListener(CloseAllPanels);
    }

    private void OnDisable()
    {
        if (GameManager.Instance)
        {
            GameManager.Instance.OnGameComplete.RemoveListener(GameCompleteAction);
            SuccessButton.onClick.RemoveListener(() => GameManager.Instance.CompleteStage(true));
            FailButton.onClick.RemoveListener(() => GameManager.Instance.CompleteStage(false));
            SceneInitializationManager.Instance.OnSceneLoaded.RemoveListener(CloseAllPanels);
        }
    }

    private void GameCompleteAction(bool state)
    {
        if (state)
        {
            OpenPanel(SuccessPanel);
        }
        else
        {
            OpenPanel(FailPanel);
        }
    }

    private void CloseAllPanels()
    {
        ClosePanel(SuccessPanel);
        ClosePanel(FailPanel);
    }

    private void OpenPanel(CanvasGroup canvasGroup)
    {
        canvasGroup.alpha = 1;
        canvasGroup.interactable = true;
        canvasGroup.blocksRaycasts = true;
    }

    private void ClosePanel(CanvasGroup canvasGroup)
    {
        canvasGroup.alpha = 0;
        canvasGroup.interactable = false;
        canvasGroup.blocksRaycasts = false;
    }
}
