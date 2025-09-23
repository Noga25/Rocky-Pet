using System.Collections.Generic;
using UnityEngine;

public class ClosestManager : MonoBehaviour
{
    [SerializeField] private int maxCapacity = 6; // How many items the fridge can hold
    private List<string> storedItems = new List<string>();

    // Check if fridge has space left
    public bool HasSpace()
    {
        return storedItems.Count < maxCapacity;
    }

    // Add an item to the fridge
    public void AddItem(string itemName)
    {
        if (HasSpace())
        {
            storedItems.Add(itemName);
            Debug.Log(itemName + " stored in fridge. (" + storedItems.Count + "/" + maxCapacity + ")");
        }
        else
        {
            Debug.Log("No space left for " + itemName);
        }
    }

    // Check what items are in the fridge
    public List<string> GetItems()
    {
        return storedItems;
    }

    // Check if fridge contains a specific item
    public bool ContainsItem(string itemName)
    {
        return storedItems.Contains(itemName);
    }
}
