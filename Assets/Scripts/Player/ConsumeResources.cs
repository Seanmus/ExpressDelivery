using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConsumeResources : MonoBehaviour
{
    private float timeSinceFuelConsumption = 0f;
    private float timeSinceSupplyConsumption = 0f;

    [SerializeField]
    private float fuelConsumptionRate = 0f;
    [SerializeField]
    private float supplyConsumptionRate = 0f;
    [SerializeField]
    private float fuelConsumption = 0f;
    [SerializeField]
    private float supplyConsumption = 0f;

    private void Start()
    {
        timeSinceFuelConsumption = Time.time;
        timeSinceSupplyConsumption = Time.time;
    }

    private void Update()
    {
        if (Time.time - timeSinceFuelConsumption > fuelConsumptionRate)
        {
            Inventory.Instance.RemoveItem("fuel", fuelConsumption);
            timeSinceFuelConsumption = Time.time;
        }

        if (Time.time - timeSinceSupplyConsumption > supplyConsumptionRate)
        {
            Inventory.Instance.RemoveItem("supply", supplyConsumption);
            timeSinceSupplyConsumption = Time.time;
        }
    }


}
