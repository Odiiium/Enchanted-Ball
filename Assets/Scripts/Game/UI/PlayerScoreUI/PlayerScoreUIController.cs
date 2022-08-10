using System.Collections;
using UnityEngine;

public class PlayerScoreUIController : MonoBehaviour
{
    internal PlayerScoreUIView View { get => playerScoreUIView ??= GetComponent<PlayerScoreUIView>(); }
    PlayerScoreUIView playerScoreUIView;
    internal PlayerScoreUIModel Model { get => playerScoreUIModel ??= GetComponent<PlayerScoreUIModel>(); }
    PlayerScoreUIModel playerScoreUIModel;

    internal void AddScore()
    {
        Model.score++;
        View.ShowScore(Model.score);
    }

}