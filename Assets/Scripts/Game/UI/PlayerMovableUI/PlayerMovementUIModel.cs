using UnityEngine;
using UniRx;

public class PlayerMovementUIModel : MonoBehaviour
{

    internal void Attack(Player player)
    {
        if (player.playerStateMachine.currentState is PlayerAimingState)
            player.playerStateMachine.ChangeState(new PlayerAttackState());
    }

    internal void SetInitialAimingState(Player player)
    {
        player.playerStateMachine = player.playerStateFactory.Create();
        player.playerStateMachine.InitializeState(new PlayerAimingState());
    }

    internal void SubscribeToLeftMoving(PlayerMovementUIController controller, AimRay aimRay, CompositeDisposable disposable)
    {
        Observable.EveryUpdate().
            Subscribe(_ => {
                if (controller.View.MoveRayRightButtonHandler.isMoving)
                    aimRay.aimRayMovable.Move(aimRay.secondPoint.transform);
            }).AddTo(disposable);
    }

    internal void SubscribeToRightMoving(PlayerMovementUIController controller, AimRay aimRay, CompositeDisposable disposable)
    {
        Observable.EveryUpdate().
            Subscribe(_ => {
                if (controller.View.LeftAimMoveButtonHandler.isMoving)
                    aimRay.aimRayMovable.MoveLeft(aimRay.secondPoint.transform);
            }).AddTo(disposable);
    }

}