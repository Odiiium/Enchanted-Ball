using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class ShopRightButton : MonoBehaviour
{
    int CurrentBall { get => PlayerPrefs.GetInt("currentBall"); set => PlayerPrefs.SetInt("currentBall", value); }
    internal Button Button { get => button ??= GetComponent<Button>(); }
    Button button;
    internal void SwitchToRight(Material[] balls, BallToBuy ballToBuy, ShopBuyButton buyButton, string[] ballNames, TextMeshProUGUI text)
    {
        if (CurrentBall == balls.Length - 1) CurrentBall = 0;
        else CurrentBall++;
        DisplayBall(balls, ballToBuy, buyButton);
        ShowBallName(ballNames, text);
    }

    private void DisplayBall(Material[] balls, BallToBuy ballToBuy, ShopBuyButton buyButton)
    {
        ballToBuy.Material = balls[CurrentBall];
        if (PlayerPrefs.GetInt($"{CurrentBall}") == 1) buyButton.gameObject.SetActive(false);
    }

    private void ShowBallName(string[] ballNames, TextMeshProUGUI text)
    {
        text.text = ballNames[CurrentBall];
    }
}