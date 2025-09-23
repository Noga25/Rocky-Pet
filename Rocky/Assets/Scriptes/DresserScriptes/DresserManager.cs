using UnityEngine;
using UnityEngine.UI;

public class DresserManager : MonoBehaviour
{
    [SerializeField] GameObject shopUI;
    [SerializeField] GameObject ClostUI;
    [SerializeField] GameObject Player;
    public void ClickShop()
    {
        shopUI.SetActive(true);

        ClostUI.SetActive(false);

        Player.SetActive(false);
    }

    public void ClickCloset()
    {
        ClostUI.SetActive(true);

        shopUI.SetActive(false);

        Player.SetActive(false);
    }

    public void BuyItem()
    {
    }

    public void ShutDown()
    {
    }

}
