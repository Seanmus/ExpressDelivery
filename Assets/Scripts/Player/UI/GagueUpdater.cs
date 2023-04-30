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
        Inventory.Instance.OnInventoryChanged.AddListener(UpdateGague);

        slider = GetComponent<Slider>();
        slider.maxValue = Inventory.Instance.GetItem(gagueName);
        slider.value = Inventory.Instance.GetItem(gagueName);
    }

    public void UpdateGague(string name, float amount)
    {
        if (name == gagueName)
        {
            slider.value = amount;
        }
    }
}
