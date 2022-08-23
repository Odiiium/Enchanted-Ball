using UnityEngine;
using Zenject;
public class StructureHitProvider : IStructureHitVisitor
{
    Player _player;
    PlayerHealthBarCanvas _canvas;

    public void Visit(Structure structure, DiContainer diContainer) { }
    public void Visit(DoubleDamageWall wall, DiContainer diContainer)
    {
        Player player = _player ??= diContainer.Resolve<Player>();
        player.damage *= 1.8f;
    }

    public void Visit(DeathWall wall, DiContainer diContainer)
    {
        PlayerHealthBarCanvas playerHealthBarCanvas = _canvas ??= diContainer.Resolve<PlayerHealthBarCanvas>();
        playerHealthBarCanvas.Controller.ReduceHealthPoints(10);
    }

    public void Visit(ReduceDamageWall wall, DiContainer diContainer)
    {
        Player player = _player ??= diContainer.Resolve<Player>();
        player.damage /= 1.6f;
    }

    public void Visit(HealWall wall, DiContainer diContainer)
    {
        PlayerHealthBarCanvas playerHealthBarCanvas = _canvas ??= diContainer.Resolve<PlayerHealthBarCanvas>();
        playerHealthBarCanvas.Controller.AddHealthPoints(25);
    }
}
