using UnityEngine;
using TMPro;
public class EndGameHighscoreElement : MonoBehaviour
{
    internal TextMeshProUGUI Text { get => text ??= GetComponentInChildren<TextMeshProUGUI>(); }
    TextMeshProUGUI text;

    internal void ShowHighScore(int score)
    {
        if (PlayerPrefs.GetInt("HighScore") < score)
        {
            Text.gameObject.SetActive(true);
            PlayerPrefs.SetInt("HighScore", score);
        }
        else Text.gameObject.SetActive(false);

    }
}