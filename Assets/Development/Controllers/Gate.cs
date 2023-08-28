using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Gate : MonoBehaviour
{
    [FoldoutGroup("Gate References")]
    public SpriteRenderer SpriteRenderer;
    [FoldoutGroup("Gate References")]
    public Image BannerBackground;
    [FoldoutGroup("Gate References")]
    public TextMeshProUGUI BannerText;
    [FoldoutGroup("Gate References")]
    public TextMeshProUGUI AmountText;
    [FoldoutGroup("Gate Settings")]
    public OperationType OperationType;
    [FoldoutGroup("Gate Settings")]
    public GateType GateType;
    [FoldoutGroup("Gate Settings")]
    public float ChangeAmount;
    [FoldoutGroup("Gate Settings")]
    public int FakeAmountMultiplier = 1;

    private void OnEnable()
    {
        InitializeGate();
    }

    private void InitializeGate()
    {
        if(OperationType == OperationType.Increase ||OperationType == OperationType.Multiply)
        {
            SpriteRenderer.color = Color.blue;
            BannerBackground.color = Color.blue;
        }
        else
        {
            SpriteRenderer.color = Color.red;
            BannerBackground.color = Color.red;
        }

        AmountText.SetText(GetOperationCharacter() + (ChangeAmount * FakeAmountMultiplier).ToString());
        BannerText.SetText(GetGateName());
    }

    private string GetOperationCharacter()
    {
        switch (OperationType)
        {
            case OperationType.Increase:
                return "+";
            case OperationType.Decrease:
                return "-";
            case OperationType.Multiply:
                return "x";
            case OperationType.Divide:
                return "%";
            default:
                return "";
        }
    }

    private string GetGateName()
    {
        switch (GateType)
        {
            case GateType.Type1:
                return "TYPE 1";
            case GateType.Type2:
                return "TYPE 2";
            case GateType.Type3:
                return "TYPE 3";
            default:
                return "TYPE 4";
        }
    }
}

public enum OperationType
{
    Increase,
    Decrease,
    Multiply,
    Divide
}

public enum GateType
{
    Type1,
    Type2,
    Type3
}