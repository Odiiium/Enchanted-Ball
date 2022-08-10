using System.Collections;
using UnityEngine;
using TMPro;
public class PlayerScoreUIView : MonoBehaviour
{
    internal TextMeshProUGUI ScoreText { get => scoreText ??= transform.GetChild(0).GetComponentInChildren<TextMeshProUGUI>(); }
    TextMeshProUGUI scoreText;

    internal void ShowScore(int score)
    {
        ScoreText.text = score.ToString();
    }
}