using UnityEngine;

public class SettingsCanvas : MonoBehaviour
{
    SettingsUIController Controller { get => settingsUIController ??= GetComponent<SettingsUIController>(); }
    SettingsUIController settingsUIController;
}
