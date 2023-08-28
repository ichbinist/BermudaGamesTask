using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Sirenix.OdinInspector;
public class LevelManager : Singleton<LevelManager>
{
    [HideInInspector]
    public UnityEvent OnLevelStarted = new UnityEvent();
    [HideInInspector]
    public UnityEvent OnLevelFinished = new UnityEvent();
    [FoldoutGroup("Level Manager Settings")]
    [FoldoutGroup("Level Manager Settings/Level List")]
    public List<Level> Levels = new List<Level>();
    [HideInInspector]
    public Level CurrentLevel;
    [HideInInspector]
    public bool IsLevelStarted;

    [Button]
    public void StartLevel()
    {
        if (IsLevelStarted) return;
        OnLevelStarted.Invoke();
        IsLevelStarted = true;
    }

    [Button]
    public void FinishLevel()
    {
        if (!IsLevelStarted) return;
        IsLevelStarted = false;
        OnLevelFinished.Invoke();
    }

    public void LoadLastLevel()
    {
        Debug.Log("Current Fake Level: " + GetFakeLevel().ToString());

        if (PlayerPrefs.HasKey("LastLevel"))
        {
            CurrentLevel = Levels[PlayerPrefs.GetInt("LastLevel")];
        }
        else
        {
            PlayerPrefs.SetInt("LastLevel", 0);
            CurrentLevel = Levels[PlayerPrefs.GetInt("LastLevel")];
        }
        SceneInitializationManager.Instance.LoadLevel(CurrentLevel);
    }

    public void LoadNextLevel()
    {
        IncreaseFakeLevel();

        PlayerPrefs.SetInt("LastLevel", PlayerPrefs.GetInt("LastLevel") + 1);
        if (PlayerPrefs.GetInt("LastLevel") >= Levels.Count)
        {
            PlayerPrefs.SetInt("LastLevel", 0);
        }
        LoadLastLevel();
    }

    public int GetFakeLevel()
    {
        if (PlayerPrefs.HasKey("FakeLevels"))
        {
            return PlayerPrefs.GetInt("FakeLevels");
        }
        else
        {
            PlayerPrefs.SetInt("FakeLevels", 1);
            return PlayerPrefs.GetInt("FakeLevels");
        }
    }

    public void IncreaseFakeLevel()
    {
        PlayerPrefs.SetInt("FakeLevels", PlayerPrefs.GetInt("FakeLevels") + 1);
    }

    public void ReloadLevel()
    {
        LoadLastLevel();
    }
}