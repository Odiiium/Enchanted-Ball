using System.Collections;
using UnityEngine;

public class PlayerScoreCanvas : MonoBehaviour
{
    internal PlayerScoreUIController Controller { get => playerScoreUIController ??= GetComponent<PlayerScoreUIController>(); }
    PlayerScoreUIController playerScoreUIController;

    private void Start() => Controller.View.ShowScore(Controller.Model.score);
}