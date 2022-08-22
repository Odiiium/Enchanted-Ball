using UnityEngine;
using Zenject;
using UniRx;

public class PlayerMovementUIModel : MonoBehaviour
{
    internal DiContainer diContainer;
    internal Player Player { get => player ??= diContainer.Resolve<Player>(); }
    Player player;

    [Inject]
    void Construct(DiContainer _diContainer) => diContainer = _diContainer;

}