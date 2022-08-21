using UniRx;
using UnityEngine;

public class EndGameUIController : MonoBehaviour
{
    internal EndGameUIModel Model { get => endGameUIModel ??= GetComponent<EndGameUIModel>(); }
    EndGameUIModel endGameUIModel;
    internal EndGameUIView View { get => endGameUIView ??= GetComponent<EndGameUIView>(); }
    EndGameUIView endGameUIView;

    private void Awake() => SubscribeToObservables();

    private void OnEnable() => OnGameEndsDoActions();

    private void SubscribeToObservables()
    {
        View.BackToMenuButton.Button.OnClickAsObservable().
            Subscribe(_ => View.BackToMenuButton.BackToMenu()).AddTo(this);
        View.RestartButton.Button.OnClickAsObservable().
            Subscribe(_ => View.RestartButton.Restart()).AddTo(this);
    }

    private void OnGameEndsDoActions()
    {
        View.MoneyElement.ShowMoneyEarned(MoneyModel().MoneyBeforeGameStarts, MoneyModel().Money);
        View.ScoreElement.ShowScore(ScoreModel().score);
        View.HighscoreElement.ShowHighScore(ScoreModel().score);
    }

    PlayerMoneyUIModel MoneyModel() { return Model.MoneyCanvas.Controller.Model; }
    PlayerScoreUIModel ScoreModel() { return Model.ScoreCanvas.Controller.Model; }

}