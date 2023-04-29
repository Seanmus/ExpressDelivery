using KartGame.KartSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ApplyStatusChange : MonoBehaviour
{
    [SerializeField]
    private ArcadeKart.StatPowerup changeStats = new ArcadeKart.StatPowerup();

    public UnityEvent OnStatusApplied;

    private void OnDestroy()
    {
        OnStatusApplied.RemoveAllListeners();    
    }

    public void ApplyStatChange(ArcadeKart kart)
    {
        kart.AddPowerup(changeStats);
        OnStatusApplied?.Invoke();
    }
}
