using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


[RequireComponent(typeof(Collider))]
public class ActivateOnTrigger : MonoBehaviour
{
    [SerializeField]
    private string triggeringTag;

    public UnityEvent TriggerTripped;

    private void OnDestroy()
    {
        TriggerTripped.RemoveAllListeners();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(triggeringTag) == true)
        {
            TriggerTripped?.Invoke();
        }
    }
}