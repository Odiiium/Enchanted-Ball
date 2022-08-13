using UnityEngine;
using UniRx;
internal class ShopUIController : MonoBehaviour
{
    internal ShopUIView View { get => shopUIView ??= GetComponent<ShopUIView>(); }
    ShopUIView shopUIView;
    internal ShopUIModel Model { get => shopUIModel ??= GetComponent<ShopUIModel>(); }
    ShopUIModel shopUIModel;

    private void Awake() => SubscribeToEvents();

    private void OnEnable() => Model.Display.ShowFullShopInformation(Model, View);

    private void SubscribeToEvents()
    {
        SubscribeToSwitchRight();
        SubscribeToSwitchLeft();
        SubscribeToSelect();
        SubscribeToGoToMenu();
        SubsribeToBuy();
        PlayerPrefs.SetInt("0", 1);
    }

    void SubscribeToSwitchRight() => View.RightButton.Button.OnClickAsObservable().
            Subscribe(_ => View.RightButton.SwitchToRight
                (Model,View)).AddTo(this);

    void SubscribeToSwitchLeft() => View.LeftButton.Button.OnClickAsObservable().
            Subscribe(_ => View.LeftButton.SwitchToLeft
                (Model, View)).AddTo(this);

    void SubscribeToGoToMenu() => View.BackToMenuButton.Button.OnClickAsObservable().
        Subscribe(_ => View.BackToMenuButton.BackToMenu(Model.MainMenuCanvas, Model.ShopCanvas, Model.ShopCamera)).AddTo(this);

    void SubsribeToBuy() => View.BuyButton.Button.OnClickAsObservable().
            Subscribe(_ => View.BuyButton.BuyBall(Model.ballPrice, Model.Money, View)).AddTo(this);

    void SubscribeToSelect() => View.SelectButton.Button.OnClickAsObservable().
            Subscribe(_ => View.SelectButton.SelectBall()).AddTo(this);
}
