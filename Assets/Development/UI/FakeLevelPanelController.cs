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
    }

    private void OnDisable()
    {
        if (SceneInitializationManager.Instance)
            SceneInitializationManager.Instance.OnSceneLoaded.RemoveListener(Initialize);
    }

    private void Initialize()
    {
        FakeLevelText.SetText("Level " + LevelManager.Instance.GetFakeLevel().ToString());
    }
}
