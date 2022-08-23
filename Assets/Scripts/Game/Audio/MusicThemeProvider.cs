using UnityEngine;
using System.Collections;

public class MusicThemeProvider : MonoBehaviour
{
    [SerializeField] private AudioClip[] audioClipArray;
    internal int clipIndex;
    float SoundVolume { get => SettingsUIModel.Sound.Volume; }
    internal AudioSource AudioSource { get => audioSource ??= GetComponent<AudioSource>(); }
    AudioSource audioSource;

    void Update() => audioSource.volume = SoundVolume;

    private void Awake()
    {
        clipIndex = Random.Range(0, audioClipArray.Length);
        AudioSource.PlayOneShot(audioClipArray[clipIndex], SoundVolume);
        StartCoroutine(WaitForNextMusicTheme(audioClipArray[clipIndex].length));
    }

    public IEnumerator WaitForNextMusicTheme(float time)
    {
        clipIndex++;
        if (clipIndex == audioClipArray.Length) clipIndex = 0;
        yield return new WaitForSeconds(time);
        AudioSource.PlayOneShot(audioClipArray[clipIndex]);
        StartCoroutine(WaitForNextMusicTheme(audioClipArray[clipIndex].length));
    }
}
