using System.Collections;
using UnityEngine;

public class ShopDisplay : MonoBehaviour
{
    internal int CurrentBall { get => PlayerPrefs.GetInt("currentBall"); set => PlayerPrefs.SetInt("currentBall", value); }

    internal void ShowFullShopInformation(ShopUIModel model, ShopUIView view)
    {
        DisplayBall(model, view);
        ShowBallName(model, view);
        ShowBallPrice(model, view);
    }

    private void DisplayBall(ShopUIModel model, ShopUIView view)
    {
        model.Ball.Material = model.ballMaterialArray[CurrentBall];
        if (PlayerPrefs.GetInt($"{CurrentBall}") == 1) view.BuyButton.gameObject.SetActive(false);
        else view.BuyButton.gameObject.SetActive(true);
    }

    private void ShowBallPrice(ShopUIModel model, ShopUIView view)
    {
        if (PlayerPrefs.GetInt($"{CurrentBall}") == 1) view.Price.gameObject.SetActive(false);
        else
        {
            view.Price.gameObject.SetActive(true);
            view.Price.TextElement.text = model.ballPrice[CurrentBall].ToString();
        }
    }
    private void ShowBallName(ShopUIModel model, ShopUIView view) => view.BallNameText.text = model.ballNames[CurrentBall];


}