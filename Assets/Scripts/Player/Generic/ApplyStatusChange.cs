using KartGame.KartSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApplyStatusChange : MonoBehaviour
{
    [SerializeField]
    private ArcadeKart.StatPowerup changeStats = new ArcadeKart.StatPowerup();


    public void ApplyStatChange(ArcadeKart kart)
    {
        kart.AddPowerup(changeStats);
        Debug.Log("Debuff applied");
    }
}
