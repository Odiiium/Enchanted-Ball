using UnityEngine;
using Zenject;
using UniRx;
public class PlayerAimingState : MonoBehaviour, IState
{
    CompositeDisposable disposable;
    AimRay aimRay;
    public DiContainer diContainer { get; set; }

    [Inject]
    void Construct(AimRay _aimray)
    {
        aimRay = _aimray;
    }

    public void Enter()
    {
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
