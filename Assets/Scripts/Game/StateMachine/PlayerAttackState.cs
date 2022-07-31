using UnityEngine;
using Zenject;
public class PlayerAttackState : IState
{
    Player player;
    int AttackIndex { get => attackIndex == 3 ? attackIndex = 0 : attackIndex++; }
    int attackIndex;


    [Inject]
    void Construrt(Player _player)
    {
        player = _player;
    }

    public void Enter()
    {
        player.DoShot();
        player.Skin.Animator.SetTrigger($"Attack{attackIndex}");
    }

    public void Exit()
    {
        throw new System.NotImplementedException();
    }
}