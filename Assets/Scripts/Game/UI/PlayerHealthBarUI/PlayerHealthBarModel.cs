using UnityEngine;
using UniRx;
using Zenject;

public class PlayerHealthBarModel : MonoBehaviour
{
    DiContainer diContainer;

    internal FloatReactiveProperty PlayerHealthPoints = new FloatReactiveProperty(300);
    internal float PlayerMaximumHealthPoints { get => 300;}
    internal EndGameUICanvas EndGameCanvas { get => endGameUICanvas ??= diContainer.Resolve<EndGameUICanvas>(); }
    EndGameUICanvas endGameUICanvas;
    internal Player Player { get => player ??= diContainer.Resolve<Player>(); }
    Player player;
    [Inject]
    void Construct(DiContainer _diContainer) => diContainer = _diContainer;

}
