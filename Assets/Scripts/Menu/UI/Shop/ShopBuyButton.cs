using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ShopBuyButton : MonoBehaviour
{
    internal Button Button { get => button ??= GetComponent<Button>(); }
    Button button;

    internal void BuyBall(int[] priceArray, PlayerMoneyCanvas moneyCanvas)
    {
        if (PlayerPrefs.GetInt("Money") >= priceArray[PlayerPrefs.GetInt("currentBall")])
        {
            PlayerPrefs.SetInt($"{PlayerPrefs.GetInt("currentBall")}", 1);
            moneyCanvas.Controller.Model.Money -= priceArray[PlayerPrefs.GetInt("currentBall")];
            gameObject.SetActive(false);
        }
        else return;
    }
}