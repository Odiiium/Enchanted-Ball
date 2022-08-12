using UnityEngine;
using UnityEngine.UI;

internal class MainMenuUIView : MonoBehaviour
{
    internal Button PlayButton { get => playButton ??= GetComponentInChildren<PlayButton>().Button; }
    Button playButton;
    internal Button SettingsButton { get => settingsButton ??= GetComponentInChildren<SettingsButton>().Button; }
    Button settingsButton;
    internal Button ShopButton { get => shopButton ??= GetComponentInChildren<ShopButton>().Button; }
    Button shopButton;
}
