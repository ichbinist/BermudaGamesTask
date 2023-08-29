using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FakeLevelPanelController : MonoBehaviour
{
    [FoldoutGroup("Fake Level Panel References")]
    public TextMeshProUGUI FakeLevelText;

    private void OnEnable()
    {
        SceneInitializationManager.Instance.OnSceneLoaded.AddListener(Initialize);
        LevelManager.Instance.OnLevelFinished.AddListener(ClosePanel);
    }

    private void OnDisable()
    {
        if (SceneInitializationManager.Instance)
        {
            LevelManager.Instance.OnLevelFinished.RemoveListener(ClosePanel);
            SceneInitializationManager.Instance.OnSceneLoaded.RemoveListener(Initialize);
        }
    }

    private void Initialize()
    {
        FakeLevelText.gameObject.SetActive(true);
        FakeLevelText.SetText("Level " + LevelManager.Instance.GetFakeLevel().ToString());
    }

    private void ClosePanel()
    {
        FakeLevelText.gameObject.SetActive(false);
    }
}
