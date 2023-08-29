using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunnerSkinController : MonoBehaviour
{
    [FoldoutGroup("Runner Skin Controller References")]
    public GameObject PoorCharacter, AverageCharacter, RichCharacter;

    private Runner runner;
    public Runner Runner { get { return (runner == null) ? runner = GetComponent<Runner>() : runner; } }

    private void OnEnable()
    {
        Runner.OnWealthChanged.AddListener(SetSkin);
    }

    private void OnDisable()
    {
        Runner.OnWealthChanged.RemoveListener(SetSkin);
    }

    private void SetSkin(bool state)
    {
        PoorCharacter.SetActive(false);
        AverageCharacter.SetActive(false);
        RichCharacter.SetActive(false);

        switch (Runner.CharacterWealthState)
        {
            case CharacterWealthState.Poor:
                PoorCharacter.SetActive(true);
                break;
            case CharacterWealthState.Average:
                AverageCharacter.SetActive(true);
                break;
            case CharacterWealthState.Rich:
                RichCharacter.SetActive(true);
                break;
            default:
                break;
        }
    }
}