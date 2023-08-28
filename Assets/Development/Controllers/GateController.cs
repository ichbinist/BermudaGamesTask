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
            Interaction();
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
    }
}