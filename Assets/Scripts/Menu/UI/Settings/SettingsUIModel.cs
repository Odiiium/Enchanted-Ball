using UnityEngine;
internal class SettingsUIModel : MonoBehaviour
{
    internal static class Sound
    {
        internal static float Volume { get => PlayerPrefs.GetFloat("SoundVolume"); set => PlayerPrefs.SetFloat("SoundVolume", value); }
    }
}
