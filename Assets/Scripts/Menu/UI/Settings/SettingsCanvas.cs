using UnityEngine;

public class SettingsCanvas : MonoBehaviour
{
    internal SettingsUIController Controller { get => settingsUIController ??= GetComponent<SettingsUIController>(); }
    SettingsUIController settingsUIController;

}
