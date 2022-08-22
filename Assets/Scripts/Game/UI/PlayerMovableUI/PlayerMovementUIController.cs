using UnityEngine;
using UniRx;

public class PlayerMovementUIController : MonoBehaviour
{
    internal PlayerMovementUIModel Model =>
        playerMovementUIModel ??= GetComponent<PlayerMovementUIModel>();
    PlayerMovementUIModel playerMovementUIModel;
    internal PlayerMovementUIView View =>
        playerMovementUIView ??= GetComponent<PlayerMovementUIView>();
    PlayerMovementUIView playerMovementUIView;

    private void Start()
    {
        View.AttackButton.OnClickAsObservable().
            Subscribe(_ => Attack(Model.Player)).AddTo(this);
    }

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
}