using UnityEngine;
using Zenject;
public class PlayerAttackState : IState
{
    Player player;
    int AttackIndex { get => attackIndex == 3 ? attackIndex = 0 : attackIndex++; }
    public DiContainer DiContainer { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }

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