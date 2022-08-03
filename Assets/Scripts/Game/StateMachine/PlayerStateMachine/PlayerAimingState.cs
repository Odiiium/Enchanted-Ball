using UnityEngine;
using Zenject;
using UniRx;
public class PlayerAimingState : IState
{
    CompositeDisposable disposable;
    AimRay aimRay;
    public DiContainer DiContainer { get { return diContainer; } set { diContainer = value; } }
    DiContainer diContainer;

    void Construct()
    {
        aimRay = DiContainer.Resolve<AimRay>();
    }

    public void Enter()
    {
        Construct();
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
}
