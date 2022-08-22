using UnityEngine;
using Zenject;

public class PauseMenuModel : MonoBehaviour
{
    DiContainer diContainer;
    internal PlayerMovementCanvas MovementCanvas { get => playerMovementCanvas ??= diContainer.Resolve<PlayerMovementCanvas>(); }
    PlayerMovementCanvas playerMovementCanvas;
    internal Player Player { get => player ??= diContainer.Resolve<Player>(); }
    Player player;

    [Inject]
    void Construct(DiContainer _diContainer) => diContainer = _diContainer;

}
