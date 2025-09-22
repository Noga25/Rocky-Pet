using System.Collections.Generic;
using UnityEngine;

public class ShopManager : MonoBehaviour
{
    [SerializeField] PlayerMoney playerMoney;
    [SerializeField] private FridgeManager fridgeManager;

    // Dictionary of items and their prices
    private Dictionary<string, int> shopItems = new Dictionary<string, int>()
    {
        {"Water", 20},
        {"Milk", 30},
        {"Juice", 40},
        {"Orange", 20},
        {"Salad", 30},
        {"Chicken", 40},
        {"Rice", 20},
        {"Choclate", 30},
    };

    // Try to buy an item
    public bool BuyItem(string itemName)
    {
        if (!shopItems.ContainsKey(itemName))
        {
            Debug.Log("Item not found in shop: " + itemName);
            return false;
        }

        int price = shopItems[itemName];

        // Check if player has enough money
        if (playerMoney.Money < price)
        {
            Debug.Log("Not enough money to buy " + itemName);
            return false;
        }

        // Check if fridge has space
        if (!fridgeManager.HasSpace())
        {
            Debug.Log("No space left in the fridge!");
            return false;
        }

        // Deduct money
        playerMoney.SpendMoney(price);
        Debug.Log(itemName + " bought! Remaining money: " + playerMoney);

        // Add item to fridge
        fridgeManager.AddItem(itemName);

        return true;
    }
}
