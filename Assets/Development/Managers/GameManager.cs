using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Sirenix.OdinInspector;

public class GameManager : Singleton<GameManager>
{
    public GameEvent OnGameFinishes = new GameEvent();

    private void Start()
    {
        Application.targetFrameRate = 60;
    }

    [Button(ButtonSizes.Large)]
    public void CompleteStage(bool state)
    {
        if (state)
        {
            LevelManager.Instance.LoadNextLevel();
        }
        else
        {
            LevelManager.Instance.ReloadLevel();
        }
    }
}
public class GameEvent : UnityEvent<bool> { }