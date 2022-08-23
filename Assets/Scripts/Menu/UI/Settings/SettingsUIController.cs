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
        SetInitialVolume();
        SetStartedVolume();
        SubscribeToChangeVolume();
        SubscribeToMenuProvider();
    }

    void SubscribeToChangeVolume() => View.VolumeSlider.OnValueChangedAsObservable().
        Subscribe(value => ChangeVolume(value)).AddTo(this);

    void SubscribeToMenuProvider() => View.BackButton.OnClickAsObservable().
        Subscribe(_ => GoToMainMenu());

    void ChangeVolume(float value) => SettingsUIModel.Sound.Volume = value;

    void SetStartedVolume() => View.VolumeSlider.value = SettingsUIModel.Sound.Volume;

    void SetInitialVolume()
    {
        if (PlayerPrefs.GetInt("InitialVolumeKey") == 0)
        {
            SettingsUIModel.Sound.Volume = .5f;
            PlayerPrefs.SetInt("InitialVolumeKey", 1);
        }
    }

    private void GoToMainMenu()
    {
        MainMenuCanvas.gameObject.SetActive(true);
        Canvas.gameObject.SetActive(false);
    }
}