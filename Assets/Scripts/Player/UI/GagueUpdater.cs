using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GagueUpdater : MonoBehaviour
{
    private Slider slider;
    [SerializeField]
    private string gagueName;

    private void Start()
    {
        slider = GetComponent<Slider>();
        slider.maxValue = Inventory.Instance.GetItem(gagueName);
        slider.value = Inventory.Instance.GetItem(gagueName);
    }

    private void OnEnable()
    {
        Inventory.Instance.OnInventoryChanged.AddListener(UpdateGague);
    }

    public void UpdateGague(string name, float amount)
    {
        if (name == gagueName)
        {
            slider.value = amount;
        }
    }
}
