using UnityEngine;
using System.Collections.Generic;
using Zenject;

internal class ShopUIModel : MonoBehaviour
{
    DiContainer diContainer;
    [SerializeField] internal Material[] ballMaterialArray;
    [SerializeField] internal int[] ballPrice;
    [SerializeField] internal string[] ballNames;
    internal BallToBuy Ball { get => ballToBuy ??= diContainer.Resolve<BallToBuy>(); }
    BallToBuy ballToBuy;
    internal PlayerMoneyCanvas Money { get => moneyCanvas ??= diContainer.Resolve<PlayerMoneyCanvas>(); }
    PlayerMoneyCanvas moneyCanvas;
    internal ShopCanvas ShopCanvas { get => shopCanvas ??= diContainer.Resolve<ShopCanvas>(); }
    ShopCanvas shopCanvas;
    internal MainMenuCanvas MainMenuCanvas { get => mainMenuCanvas ??= diContainer.Resolve<MainMenuCanvas>(); }
    MainMenuCanvas mainMenuCanvas;
    internal ShopCamera ShopCamera { get => shopCamera ??= diContainer.Resolve<ShopCamera>(); }
    ShopCamera shopCamera;

    [Inject]
    void Construct(DiContainer _diContainer) => diContainer = _diContainer;
}
