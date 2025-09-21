using TMPro;
using UnityEngine;

public class PlayerMoney : MonoBehaviour
{
    // Public fields
    public int Money { get { return money; } }

    public TextMeshProUGUI moneyText;

    // Private fields
    private int money = 200;

    private const string MoneyKey = "PlayerMoney";

    void Start()
    {
        // Load saved money or start with 200 if no data found
        money = PlayerPrefs.GetInt(MoneyKey, 200);
        UpdateMoneyText();
        Debug.Log("Money loaded: " + money);
    }

    // Call this method to add money
    public void AddMoney(int amount)
    {
        money += amount;
        Debug.Log("Money added. Current money: " + money);
    }

    // Call this method to spend money
    public bool SpendMoney(int amount)
    {
        if (money >= amount)
        {
            money -= amount;
            Debug.Log("Money spent. Current money: " + money);
            return true;
        }
        else
        {
            Debug.Log("Not enough money!");
            return false;
        }
    }

    // Save money when the application quits or pauses
    void OnApplicationQuit()
    {
        SaveMoney();
    }

    void OnApplicationPause(bool pauseStatus)
    {
        if (pauseStatus)
        {
            SaveMoney();
        }
    }

    // Method to save the curren amount of money
    private void SaveMoney()
    {
        PlayerPrefs.SetInt(MoneyKey, money);
        PlayerPrefs.Save();
        Debug.Log("Money saved: " + money);
    }

    private void UpdateMoneyText()
    {
        if (moneyText != null)
        {
            moneyText.text = money.ToString() + "$";
        }
    }

    // Method to get current money
    public int GetMoney()
    {
        return money;
    }
}
