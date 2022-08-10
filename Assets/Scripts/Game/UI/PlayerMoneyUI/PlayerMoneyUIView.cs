using UnityEngine;
using TMPro;
public class PlayerMoneyUIView : MonoBehaviour
{
    internal TextMeshProUGUI MoneyText { get => moneyText ??= transform.GetChild(0).GetComponentInChildren<TextMeshProUGUI>(); }
    TextMeshProUGUI moneyText;

    internal void ShowCoins(int coinsCount) => MoneyText.text = coinsCount.ToString();
}