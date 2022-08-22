using UnityEngine;
using TMPro;

public class EndGameScoreElement : MonoBehaviour
{
    internal TextMeshProUGUI Text { get => text ??= GetComponentInChildren<TextMeshProUGUI>(); }
    TextMeshProUGUI text;

    internal void ShowScore(int score) => Text.text = "SCORE:" + score;
}