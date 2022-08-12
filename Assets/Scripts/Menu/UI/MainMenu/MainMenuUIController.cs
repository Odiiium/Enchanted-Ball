using UnityEngine;
using UnityEngine.SceneManagement;
using UniRx;
using Zenject;

internal class MainMenuUIController : MonoBehaviour
{
    internal MainMenuUIView View { get => mainMenuUIView ??= GetComponent<MainMenuUIView>(); }
    MainMenuUIView mainMenuUIView;
    internal MainMenuUIModel Model { get => mainMenuUIModel ??= GetComponent<MainMenuUIModel>(); }
    MainMenuUIModel mainMenuUIModel;

    private void Awake() => SubscribeToEvents();

    private void SubscribeToEvents()
    {
        SubscribeToGoToPlayScene();
        SubscribeToGoToSettings();
        SubscribeToGoToShop();
    }

    private void SubscribeToGoToPlayScene() => View.PlayButton.OnClickAsObservable().
        Subscribe(_ => SceneManager.LoadScene("Game")).AddTo(this);
    private void SubscribeToGoToSettings() => View.SettingsButton.OnClickAsObservable().
        Subscribe(_ => GoToSettingsMenu()).AddTo(this);
    private void SubscribeToGoToShop() => View.ShopButton.OnClickAsObservable().
        Subscribe(_ => GoToShopMenu()).AddTo(this);

    private void GoToSettingsMenu()
    {
        Model.SettingsCanvas.gameObject.SetActive(true);
        Model.MainMenuCanvas.gameObject.SetActive(false);
    }

    private void GoToShopMenu()
    {
        Model.ShopCamera.gameObject.SetActive(true);
        Model.ShopCanvas.gameObject.SetActive(true);
        Model.MainMenuCanvas.gameObject.SetActive(false);
    }
}
