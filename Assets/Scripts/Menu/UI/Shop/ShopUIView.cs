using UnityEngine;
using TMPro;

internal class ShopUIView : MonoBehaviour
{
    internal ShopLeftButton LeftButton { get => shopLeftButton ??= GetComponentInChildren<ShopLeftButton>(); }
    ShopLeftButton shopLeftButton;
    internal ShopRightButton RightButton { get => shopRightButton ??= GetComponentInChildren<ShopRightButton>(); }
    ShopRightButton shopRightButton;
    internal ShopSelectButton SelectButton { get => shopSelectButton ??= GetComponentInChildren<ShopSelectButton>(); }
    ShopSelectButton shopSelectButton;
    internal ShopBuyButton BuyButton { get => shopBuyButton ??= GetComponentInChildren<ShopBuyButton>(); }
    ShopBuyButton shopBuyButton;
    internal ShopBackToMenuButton BackToMenuButton { get => shopBackToMenuButton ??= GetComponentInChildren<ShopBackToMenuButton>(); }
    ShopBackToMenuButton shopBackToMenuButton;
    internal TextMeshProUGUI BallNameText { get => ballNameText ??= GetComponentInChildren<TextMeshProUGUI>(); }
    TextMeshProUGUI ballNameText;
    internal ShopPriceElement Price { get => shopPriceElement ??= GetComponentInChildren<ShopPriceElement>(); }
    ShopPriceElement shopPriceElement;
}
