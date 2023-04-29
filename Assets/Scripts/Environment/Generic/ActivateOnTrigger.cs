using KartGame.KartSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


[RequireComponent(typeof(Collider))]
public class ActivateOnTrigger : MonoBehaviour
{
    [SerializeField]
    private string triggeringTag;

    public UnityEvent<ArcadeKart> TriggerTripped;

    private void OnDestroy()
    {
        TriggerTripped.RemoveAllListeners();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(triggeringTag) == true)
        {
            ArcadeKart kart = other.GetComponent<ArcadeKart>();
            if (kart != null)
            {
                TriggerTripped?.Invoke(kart);
            }
        }
    }
}
