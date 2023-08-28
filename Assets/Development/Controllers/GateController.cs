using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateController : MonoBehaviour
{
    private Gate gate;
    public Gate Gate { get { return (gate == null) ? gate = GetComponent<Gate>() : gate; } }

    private void OnTriggerEnter(Collider other)
    {
        if (!Gate.IsInteracted)
        {
            if (other.GetComponentInParent<Runner>())
            {
                Interaction();
            }
        }
    }

    private void Interaction()
    {
        Gate.IsInteracted = true;
        Gate.SpriteRenderer.enabled = false;
        Gate.AmountText.gameObject.SetActive(false);

        foreach (Gate _gate in Gate.ConnectedGates)
        {
            _gate.IsInteracted = true;
        }

        if (Gate.OperationType == OperationType.Increase)
        {
            CurrencyManager.Instance.AddTemporaryCurrency(Mathf.RoundToInt(Gate.ChangeAmount));
            Gate.GoodFeedbackParticle.Play();
        }
        else if (Gate.OperationType == OperationType.Decrease)
        {
            CurrencyManager.Instance.AddTemporaryCurrency(Mathf.RoundToInt(-Gate.ChangeAmount));
            Gate.BadFeedbackParticle.Play();
        }
    }
}