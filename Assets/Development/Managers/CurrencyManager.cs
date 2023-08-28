using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

public class CurrencyManager : Singleton<CurrencyManager>
{
    [FoldoutGroup("Currency Manager Settings")]
    [FoldoutGroup("Currency Manager Settings/Debug")]
    [ReadOnly]
    public int TemporaryCurrency;
    [HideInInspector]
    public UnityEvent OnTemporaryCurrencyAdded = new UnityEvent();
    [HideInInspector]
    public UnityEvent OnTemporaryCurrencyRemoved = new UnityEvent();
    private void OnEnable()
    {
        JSONDataManager.Instance.OnDataLoaded += InitializeData;
    }

    private void OnDisable()
    {
        if (JSONDataManager.Instance)
            JSONDataManager.Instance.OnDataLoaded -= InitializeData;
    }

    private void InitializeData(JSONDATA jsondata)
    {

    }

    public void AddTemporaryCurrency(int currency)
    {
        TemporaryCurrency += currency;
        if(currency > 0)
        {
            OnTemporaryCurrencyAdded.Invoke();
        }
        else
        {
            OnTemporaryCurrencyRemoved.Invoke();
        }
    }

    public void ResetTemporaryCurrency()
    {
        TemporaryCurrency = 0;
    }

    public void AddTemporaryToPersistent()
    {
        AddPersistentCurrency(TemporaryCurrency);
        ResetTemporaryCurrency();
    }

    public void AddPersistentCurrency(int currency)
    {
        JSONDataManager.Instance.JSONDATA.Currency += currency;
        JSONDataManager.Instance.SaveData();
    }

    public void RemovePersistentCurrency(int currency)
    {
        JSONDataManager.Instance.JSONDATA.Currency -= currency;
        JSONDataManager.Instance.SaveData();
    }

    public bool IsCurrencyEnough(int amount)
    {
        if (JSONDataManager.Instance.JSONDATA.Currency >= amount)
            return true;
        else
            return false;
    }
}