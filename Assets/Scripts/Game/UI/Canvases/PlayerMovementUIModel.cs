using UnityEngine;
using UniRx;

public class PlayerMovementUIModel : MonoBehaviour
{

    internal void Attack(Player player)
    {
        if (player.playerStateMachine.currentState is PlayerAimingState)
        {
            player.playerStateMachine.ChangeState(new PlayerAttackState());
        }
    }

    internal void SetInitialAimingState(Player player)
    {
        player.playerStateMachine = player.playerStateFactory.Create();
        player.playerStateMachine.InitializeState(new PlayerAimingState());
    }

}