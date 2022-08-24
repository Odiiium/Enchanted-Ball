using UnityEngine;
using Zenject;
public class StructureHitProvider : IStructureHitVisitor
{
    Player _player;
    PlayerHealthBarCanvas _canvas;
    CoinSpawner _coinSpawner;
    PlayerMoneyCanvas _moneyCanvas;

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

    public void Visit(MoneyWall wall, DiContainer diContainer)
    {
        int randomCountOfCoins = Random.Range(1, 3);
        CoinSpawner coinSpawner = _coinSpawner ??= diContainer.Resolve<CoinSpawner>();
        coinSpawner.SpawnCoins(wall.transform.position, wall, 3);
    }
}
