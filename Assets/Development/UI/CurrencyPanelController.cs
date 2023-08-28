using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
using TMPro;

public class CurrencyPanelController : MonoBehaviour
{
    [FoldoutGroup("Currency Panel References")]
    public CanvasGroup TapToPlayPanel;
    [FoldoutGroup("Currency Panel References")]
    public CanvasGroup InGamePlayPanel;
    [FoldoutGroup("Currency Panel References")]
    public TextMeshProUGUI TapToPlayCurrencyText;
    [FoldoutGroup("Currency Panel References")]
    public TextMeshProUGUI InGameCurrencyText;

    private void Awake()
    {
        ClosePanel(TapToPlayPanel);
        ClosePanel(InGamePlayPanel);
        InGameCurrencyText.SetText("0");
        TapToPlayCurrencyText.SetText(JSONDataManager.Instance.JSONDATA.Currency.ToString());
    }

    private void OnEnable()
    {
        SceneInitializationManager.Instance.OnSceneLoaded.AddListener(() => { OpenPanel(TapToPlayPanel); ClosePanel(InGamePlayPanel); });
        LevelManager.Instance.OnLevelStarted.AddListener(() => { OpenPanel(InGamePlayPanel); ClosePanel(TapToPlayPanel); });
        CurrencyManager.Instance.OnTemporaryCurrencyChanged.AddListener(() => { InGameCurrencyText.SetText(CurrencyManager.Instance.TemporaryCurrency.ToString()); });
        CurrencyManager.Instance.OnPersistentCurrencyChanged.AddListener(() => { TapToPlayCurrencyText.SetText(JSONDataManager.Instance.JSONDATA.Currency.ToString()); });
    }

    private void OnDisable()
    {
        if(SceneInitializationManager.Instance)
        {
            SceneInitializationManager.Instance.OnSceneLoaded.RemoveListener(() => { OpenPanel(TapToPlayPanel); ClosePanel(InGamePlayPanel); });
            LevelManager.Instance.OnLevelStarted.RemoveListener(() => { OpenPanel(InGamePlayPanel); ClosePanel(TapToPlayPanel); });
            CurrencyManager.Instance.OnTemporaryCurrencyChanged.RemoveListener(() => { InGameCurrencyText.SetText(CurrencyManager.Instance.TemporaryCurrency.ToString()); });
            CurrencyManager.Instance.OnPersistentCurrencyChanged.RemoveListener(() => { TapToPlayCurrencyText.SetText(JSONDataManager.Instance.JSONDATA.Currency.ToString()); });
        }
    }

    private void ClosePanel(CanvasGroup canvasGroup)
    {
        canvasGroup.alpha = 0;
        canvasGroup.interactable = false;
        canvasGroup.blocksRaycasts = false;
    }

    private void OpenPanel(CanvasGroup canvasGroup)
    {
        canvasGroup.alpha = 1;
        canvasGroup.interactable = true;
        canvasGroup.blocksRaycasts = true;
    }
}