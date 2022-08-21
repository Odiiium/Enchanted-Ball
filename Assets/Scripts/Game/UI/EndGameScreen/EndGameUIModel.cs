using UnityEngine;
using Zenject;

public class EndGameUIModel : MonoBehaviour
{
    DiContainer diContainer;
    internal PlayerScoreCanvas ScoreCanvas { get => playerScoreCanvas ??= diContainer.Resolve<PlayerScoreCanvas>(); }
    PlayerScoreCanvas playerScoreCanvas;
    internal PlayerMoneyCanvas MoneyCanvas { get => playerMoneyCanvas ??= diContainer.Resolve<PlayerMoneyCanvas>(); }
    PlayerMoneyCanvas playerMoneyCanvas;

    [Inject]
    private void Construct(DiContainer _diContainer) => diContainer = _diContainer;
}
