using UnityEngine;
using Zenject;
internal class MainMenuUIModel : MonoBehaviour
{
    DiContainer diContainer;
    internal MainMenuCanvas MainMenuCanvas { get => mainMenuCanvas ??= diContainer.Resolve<MainMenuCanvas>(); }
    MainMenuCanvas mainMenuCanvas;
    internal SettingsCanvas SettingsCanvas { get => settingsCanvas ??= diContainer.Resolve<SettingsCanvas>(); }
    SettingsCanvas settingsCanvas;
    internal ShopCanvas ShopCanvas { get => shopCanvas ??= diContainer.Resolve<ShopCanvas>(); }
    ShopCanvas shopCanvas;
    internal ShopCamera ShopCamera { get => shopCamera ??= diContainer.Resolve<ShopCamera>(); }
    ShopCamera shopCamera;

    [Inject]
    void Construct(DiContainer _diContainer) => diContainer = _diContainer;

}
