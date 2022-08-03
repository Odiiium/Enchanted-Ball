using UnityEngine;
using Zenject;
public class PlayerAttackState : IState
{
    Player player;
    internal static int AttackIndex { get => attackIndex == 3 ? attackIndex = 0 : attackIndex++;}
    static int attackIndex;
    public DiContainer DiContainer { get { return diContainer; } set { diContainer = value; } }
    DiContainer diContainer;

    public void Construct()
    {
        player = DiContainer.Resolve<Player>();
    }

    public void Enter()
    {
        Construct();
        player.DoShot();
        player.Skin.Animator.SetTrigger($"Attack{AttackIndex}");
        player.playerStateMachine.ChangeState(new PlayerIdleState());
    }

    public void Exit()
    {

    }
}