using UnityEngine;
using UnityEngine.UI;

public class KitchenManager : MonoBehaviour
{
    [SerializeField] GameObject shopUI;
    [SerializeField] GameObject FridgeUI;
    [SerializeField] GameObject Player;
    public void ClickShop()
    {
        shopUI.SetActive(true);

        FridgeUI.SetActive(false);

        Player.SetActive(false);
    }

    public void ClickFridge()
    {
        FridgeUI.SetActive(true);

        shopUI.SetActive(false);

        Player.SetActive(false);
    }

}
