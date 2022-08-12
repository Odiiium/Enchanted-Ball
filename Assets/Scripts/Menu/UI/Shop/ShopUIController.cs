using UnityEngine;
using UniRx;
using Zenject;
internal class ShopUIController : MonoBehaviour
{
    DiContainer diContainer;
    internal ShopUIView View { get => shopUIView ??= GetComponent<ShopUIView>(); }
    ShopUIView shopUIView;
    internal ShopUIModel Model { get => shopUIModel ??= GetComponent<ShopUIModel>(); }
    ShopUIModel shopUIModel;

    [Inject]
    void Construct(DiContainer _diContainer) => diContainer = _diContainer;

    private void Awake() => SubscribeToEvents();

    private void SubscribeToEvents()
    {
        SubscribeToSwitchRight();
        SubscribeToSwitchLeft();
        SubscribeToSelect();
        SubscribeToGoToMenu();
        SubsribeToBuy();
    }

    void SubscribeToSwitchRight() => View.RightButton.Button.OnClickAsObservable().
            Subscribe(_ => View.RightButton.SwitchToRight
                (Model.ballMaterialArray, Model.Ball, View.BuyButton, Model.ballNames, View.BallNameText)).AddTo(this);

    void SubscribeToSwitchLeft() => View.LeftButton.Button.OnClickAsObservable().
            Subscribe(_ => View.LeftButton.SwitchToLeft
                (Model.ballMaterialArray, Model.Ball, View.BuyButton, Model.ballNames, View.BallNameText)).AddTo(this);

    void SubscribeToGoToMenu() => View.BackToMenuButton.Button.OnClickAsObservable().
        Subscribe(_ => View.BackToMenuButton.BackToMenu(Model.MainMenuCanvas, Model.ShopCanvas, Model.ShopCamera)).AddTo(this);

    void SubsribeToBuy() => View.BuyButton.Button.OnClickAsObservable().
            Subscribe(_ => View.BuyButton.BuyBall(Model.ballPrice, Model.Money)).AddTo(this);

    void SubscribeToSelect() => View.SelectButton.Button.OnClickAsObservable().
            Subscribe(_ => View.SelectButton.SelectBall()).AddTo(this);
}
