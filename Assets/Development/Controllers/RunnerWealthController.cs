using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class RunnerWealthController : MonoBehaviour
{
    public Image WealthSlider;
    public TextMeshProUGUI WealthText;

    private Runner runner;
    public Runner Runner { get { return (runner == null) ? runner = GetComponent<Runner>() : runner; } }

    public void SetCharacterWealthState()
    {
        float currentPercentage = (float)CurrencyManager.Instance.TemporaryCurrency / (float)LevelManager.Instance.CurrentLevel.TargetMaxWealth;
        currentPercentage *= 100f;

        CharacterWealthState previousState = Runner.CharacterWealthState;

        WealthSlider.fillAmount = currentPercentage / 100f;

        if (currentPercentage <= LevelManager.Instance.CurrentLevel.PoorPercentage)
        {
            Runner.CharacterWealthState = CharacterWealthState.Poor;
            WealthSlider.color = Color.red;
            WealthText.SetText("POOR");
            WealthText.color = Color.red;
        }
        else if(currentPercentage > LevelManager.Instance.CurrentLevel.PoorPercentage && currentPercentage < LevelManager.Instance.CurrentLevel.AveragePercentage)
        {
            Runner.CharacterWealthState = CharacterWealthState.Average;
            WealthSlider.color = Color.green;
            WealthText.SetText("AVERAGE");
            WealthText.color = Color.green;
        }
        else
        {
            Runner.CharacterWealthState = CharacterWealthState.Rich;
            WealthSlider.color = Color.yellow;
            WealthText.SetText("RICH");
            WealthText.color = Color.yellow;
        }

        if(previousState != Runner.CharacterWealthState)
        {
            bool isHappy = false;

            if(previousState == CharacterWealthState.Rich)
            {
                isHappy = false;
            }
            else if(previousState == CharacterWealthState.Average && Runner.CharacterWealthState == CharacterWealthState.Poor)
            {
                isHappy = false;
            }
            else
            {
                isHappy = true;
            }

            Runner.OnWealthChanged.Invoke(isHappy);
        }
    }

    private void LateUpdate()
    {
        SetCharacterWealthState();
    }
}