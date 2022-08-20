using UnityEngine;
using UnityEngine.UI;

internal class SettingsButton : MonoBehaviour
{
    internal Button Button { get => button ??= GetComponent<Button>(); }
    Button button;
}
