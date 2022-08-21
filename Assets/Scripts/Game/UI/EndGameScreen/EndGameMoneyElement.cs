using UnityEngine;
using TMPro;

public class EndGameMoneyElement : MonoBehaviour
{
    internal TextMeshProUGUI Text { get => text ??= GetComponentInChildren<TextMeshProUGUI>(); }
    TextMeshProUGUI text;

    internal void ShowMoneyEarned(int moneyBeforeStart, int money) =>
        Text.text = "Earned:" + (money - moneyBeforeStart);

}