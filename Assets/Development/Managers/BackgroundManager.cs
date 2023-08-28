using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

public class BackgroundManager : Singleton<BackgroundManager>
{
    public Material BackgroundMaterial;

    private void OnEnable()
    {
        SceneInitializationManager.Instance.OnSceneLoaded.AddListener(SetColor);
    }
    private void OnDisable()
    {
        if (SceneInitializationManager.Instance)
            SceneInitializationManager.Instance.OnSceneLoaded.RemoveListener(SetColor);
    }
    public void SetColor()
    {
        Material temperaryMaterial = new Material(BackgroundMaterial);
        temperaryMaterial.SetColor("_MiddleColor", LevelManager.Instance.CurrentLevel.BackgroundColor);
        RenderSettings.skybox = temperaryMaterial;
    }
}