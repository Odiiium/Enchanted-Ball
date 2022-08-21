using UnityEngine;

public class EndGameUIView : MonoBehaviour
{
    internal EndGameBackToMenuButton BackToMenuButton { get => backToMenuButton ??= GetComponentInChildren<EndGameBackToMenuButton>(); }
    EndGameBackToMenuButton backToMenuButton;
    internal EndGameHighscoreElement HighscoreElement { get => endGameHighscoreElement ??= GetComponentInChildren<EndGameHighscoreElement>(); }
    EndGameHighscoreElement endGameHighscoreElement;
    internal EndGameMoneyElement MoneyElement { get => endGameMoneyElement ??= GetComponentInChildren<EndGameMoneyElement>(); }
    EndGameMoneyElement endGameMoneyElement;
    internal EndGameRestartButton RestartButton { get => endGameRestartButton ??= GetComponentInChildren<EndGameRestartButton>(); }
    EndGameRestartButton endGameRestartButton;
    internal EndGameScoreElement ScoreElement { get => endGameScoreElement ??= GetComponentInChildren<EndGameScoreElement>();}
    EndGameScoreElement endGameScoreElement;

}
