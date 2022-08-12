using UnityEngine;
using UnityEngine.UI;
internal class SettingsUIView : MonoBehaviour
{
    internal Slider VolumeSlider { get => volumeSlider ??= GetComponentInChildren<Slider>();}
    Slider volumeSlider;
    internal Button BackButton { get => backButton ??= GetComponentInChildren<SettingsBackButton>().GetComponent<Button>(); }
    Button backButton;
}
