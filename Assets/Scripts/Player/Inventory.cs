using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    private Dictionary<string, float> playerInventory = new Dictionary<string, float>();

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
    }

    public void RemoveItem(string itemName,float amount)
    {
        if (playerInventory.ContainsKey(itemName))
        {
            if (playerInventory[itemName] > 0)
            {
                playerInventory[itemName] -= amount;
            }
        }
    }

    public bool DoesItemExist(string itemName)
    {
        return playerInventory.ContainsKey(itemName);
    }

    public void AddItem(string itemName, float amount)
    {
        if (playerInventory.ContainsKey(itemName))
        {
            playerInventory[itemName] += amount;
            return;
        }

        playerInventory.Add(itemName, amount);
    }
}
