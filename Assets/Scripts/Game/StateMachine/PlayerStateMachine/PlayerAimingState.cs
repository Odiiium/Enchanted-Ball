using UnityEngine;
using Zenject;
using UniRx;
public class PlayerAimingState : IState
{
    AimRay aimRay;
    public DiContainer DiContainer { get { return diContainer; } set { diContainer = value; } }
    DiContainer diContainer;

    public void Construct()
    {
        aimRay = DiContainer.Resolve<AimRay>();
    }

    public void Enter()
    {
        Construct();
        aimRay.gameObject.SetActive(true);
    }

    public void Exit()
    {
        aimRay.gameObject.SetActive(false);
    }

}
