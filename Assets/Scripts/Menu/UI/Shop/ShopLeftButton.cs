using UnityEngine;
using UnityEngine.UI;
using TMPro;
internal class ShopLeftButton : MonoBehaviour
{
    int CurrentBall { get => PlayerPrefs.GetInt("currentBall"); set => PlayerPrefs.SetInt("currentBall", value); }
    internal Button Button { get => button ??= GetComponent<Button>(); }
    Button button;

    internal void SwitchToLeft(Material[] balls, BallToBuy ballToBuy, ShopBuyButton buyButton, string[] ballNames, TextMeshProUGUI text)
    {
        if (CurrentBall == 0) CurrentBall = balls.Length - 1;
        else CurrentBall--;
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
