using Zenject;
using UnityEngine;

public class MenuCanvasInstaller : MonoInstaller
{
    [SerializeField] MainMenuCanvas mainMenuCanvas;
    [SerializeField] ShopCanvas shopCanvas;
    [SerializeField] SettingsCanvas settingsCanvas;
    [SerializeField] PlayerMoneyCanvas playerMoneyCanvas;

    [SerializeField] Transform parentCanvasTransform;

    public override void InstallBindings() => BindCanvases();

    private void BindCanvases()
    {
        BindPlayerMoneyCanvas();
        BindMainMenuCanvas();
        BindSettingsCanvas();
        BindShopCanvas();
    }

    private void BindMainMenuCanvas()
    {
        var mainMenuModel = Container.
            InstantiatePrefabForComponent<MainMenuCanvas>(mainMenuCanvas, parentCanvasTransform);
        Container.Bind<MainMenuCanvas>().FromInstance(mainMenuModel).AsSingle().NonLazy();
    }

    private void BindShopCanvas()
    {
        var shopCanvasModel = Container.
            InstantiatePrefabForComponent<ShopCanvas>(shopCanvas, parentCanvasTransform);
        Container.Bind<ShopCanvas>().FromInstance(shopCanvasModel).AsSingle().NonLazy();
    }
    private void BindSettingsCanvas()
    {
        var settingsCanvasModel = Container.
            InstantiatePrefabForComponent<SettingsCanvas>(settingsCanvas, parentCanvasTransform);
        Container.Bind<SettingsCanvas>().FromInstance(settingsCanvasModel).AsSingle().NonLazy();
    }
    private void BindPlayerMoneyCanvas()
    {
        var playerMoneyCanvasModel = Container.
            InstantiatePrefabForComponent<PlayerMoneyCanvas>(playerMoneyCanvas, parentCanvasTransform);
        Container.Bind<PlayerMoneyCanvas>().FromInstance(playerMoneyCanvasModel).AsSingle().NonLazy();
    }
}