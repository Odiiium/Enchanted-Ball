using UnityEngine;
using UnityEngine.UI;
using Zenject;
using UniRx;
using UnityEngine.EventSystems;

public class PlayerMovementCanvas : MonoBehaviour
{
    CompositeDisposable disposable;
    DiContainer diContainer;
    internal PlayerMovementUIController Controller { get => playerMovementUIController ??= gameObject.GetComponent<PlayerMovementUIController>(); }
    PlayerMovementUIController playerMovementUIController;
    internal Player Player { get => player ??= diContainer.Resolve<Player>(); }
    Player player;
    internal AimRay AimRay { get => aimRay ??= diContainer.Resolve<AimRay>(); }
    AimRay aimRay;

    [Inject]
    void Construct(DiContainer _diContainer)
    {
        diContainer = _diContainer;
    }

    private void Start()
    {
        disposable = new CompositeDisposable();
        Controller.View.AttackButton.OnClickAsObservable().
            Subscribe(_ => Controller.Model.Attack(Player)).AddTo(disposable);
        Controller.Model.SubscribeToLeftMoving(Controller, AimRay, disposable);
        Controller.Model.SubscribeToRightMoving(Controller, AimRay, disposable);
    }

}
