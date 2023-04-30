using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Inventory : MonoBehaviour
{
    private Dictionary<string, float> playerInventory = new Dictionary<string, float>();

    public UnityEvent<string, float> OnInventoryChanged = new UnityEvent<string, float>();

    [SerializeField]
    private float fuelMax;

    [SerializeField]
    private float supplyMax;

    public static Inventory Instance
    {
        get
        {
            return instance;
        }
        private set
        {
            instance = value;
        }
    }

    private static Inventory instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.Log("Multiple Singletons detected, deleting object. Please remove extra singleton from scene", this);
            Destroy(this.gameObject);
            return;
        }

        Instance = this;
        AddItem("fuel", fuelMax);
        AddItem("supply", supplyMax);

       OnInventoryChanged.AddListener(GameManager.Instance.GameOverFromSupply);
    }

    private void OnDestroy()
    {
        OnInventoryChanged.RemoveAllListeners();
    }

    public void RemoveItem(string itemName,float amount)
    {
        if (playerInventory.ContainsKey(itemName))
        {
            if (playerInventory[itemName] > 0)
            {
                playerInventory[itemName] -= amount;
            }
            else
            {
                playerInventory[itemName] = 0;
            }

            OnInventoryChanged?.Invoke(itemName, playerInventory[itemName]);
        }
    }

    public bool DoesItemExist(string itemName)
    {
        return playerInventory.ContainsKey(itemName);
    }

    public float GetItem(string itemName)
    {
        return playerInventory[itemName];
    }

    public void AddItem(string itemName, float amount)
    {
        if (playerInventory.ContainsKey(itemName))
        {
            playerInventory[itemName] += amount;
            return;
        }

        playerInventory.Add(itemName, amount);
        OnInventoryChanged?.Invoke(itemName, playerInventory[itemName]);
    }
}
