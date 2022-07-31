using UnityEngine;
using Zenject;
using UniRx;
public class PlayerAimingState : IState
{
    CompositeDisposable disposable;
    AimRay aimRay;

    public void Enter()
    {
        ResolveAimRay();
        disposable = new CompositeDisposable();
        aimRay.gameObject.SetActive(true);
        Observable.EveryUpdate().Subscribe(_ => MoveTheAim()).AddTo(disposable);
    }

    public void Exit()
    {
        aimRay.gameObject.SetActive(false);
        disposable?.Dispose();
    }

    private void MoveTheAim() => aimRay.aimRayMovable.Move(aimRay.secondPoint.transform);

    [Inject]
    private void ResolveAimRay()
    {
        DiContainer newContainer = new DiContainer();
        aimRay = newContainer.TryResolve<AimRay>();
    }
}
