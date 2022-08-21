using UnityEditor;
using UnityEngine;
using Zenject;

public class PlayerDeathState : IState
{
    public DiContainer DiContainer { get { return diContainer; } set { diContainer = value; } }
    DiContainer diContainer;

    PlayerHealthBarCanvas HealthBarCanvas { get => playerHealthBarCanvas ??= diContainer.Resolve<PlayerHealthBarCanvas>(); }
    PlayerHealthBarCanvas playerHealthBarCanvas;
    PlayerScoreCanvas ScoreCanvas { get => playerScoreCanvas ??= diContainer.Resolve<PlayerScoreCanvas>(); }
    PlayerScoreCanvas playerScoreCanvas;
    PlayerMoneyCanvas MoneyCanvas { get => playerMoneyCanvas ??= diContainer.Resolve<PlayerMoneyCanvas>();}
    PlayerMoneyCanvas playerMoneyCanvas;

    public void Enter()
    {
        HealthBarCanvas.gameObject.SetActive(false);
        ScoreCanvas.gameObject.SetActive(false);
        MoneyCanvas.gameObject.SetActive(false);
    }

    public void Construct() { }
    public void Exit() { }
}