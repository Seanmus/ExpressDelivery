using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResupplyPoint : MonoBehaviour
{
    [SerializeField]
    private string resourceName;

    [SerializeField]
    private float amount;

    public void Resupply()
    {
        Inventory.Instance.AddItem(resourceName, amount);
    }
}
