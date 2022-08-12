using UnityEngine;
using UniRx;
using Zenject;

internal class SettingsUIController : MonoBehaviour
{
    DiContainer diContainer;

    internal SettingsUIModel Model { get => settingsUIModel ??= GetComponent<SettingsUIModel>(); }
    SettingsUIModel settingsUIModel;
    internal SettingsUIView View { get => settingsUIView ??= GetComponent<SettingsUIView>(); }
    SettingsUIView settingsUIView;
    SettingsCanvas Canvas { get => diContainer.Resolve<SettingsCanvas>(); }
    MainMenuCanvas MainMenuCanvas { get => diContainer.Resolve<MainMenuCanvas>(); }

    [Inject]
    void Construct(DiContainer _diContainer) => diContainer = _diContainer;

    private void Awake() => SubscribeToEvents();

    void SubscribeToEvents()
    {
        SubscribeToChangeVolume();
        SubscribeToMenuProvider();
    }

    void SubscribeToChangeVolume() => View.VolumeSlider.OnValueChangedAsObservable().
        Subscribe(value => ChangeVolume(value)).AddTo(this);

    void SubscribeToMenuProvider() => View.BackButton.OnClickAsObservable().
        Subscribe(_ => GoToMainMenu());

    void ChangeVolume(float value) => SettingsUIModel.Sound.Volume = value;

    private void GoToMainMenu()
    {
        MainMenuCanvas.gameObject.SetActive(true);
        Canvas.gameObject.SetActive(false);
    }
}