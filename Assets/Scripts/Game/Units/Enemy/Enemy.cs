using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class Enemy : MonoBehaviour, IEnemy
{
    EnemyMovable enemyMovable = new EnemyMovable();
    internal Tile Tile { get => tile; set => tile = value; }
    Tile tile;
    DiContainer diContainer;

    LevelBuilder LevelBuilder { get => levelBuilder ??= diContainer.Resolve<LevelBuilder>(); }
    LevelBuilder levelBuilder;

    [Inject]
    void Construct(DiContainer _diContainer)
    {
        diContainer = _diContainer;
    }

    public void Jump()
    {
        enemyMovable.Move(transform);
    }

    public void Die()
    {
        levelBuilder.enemyPool.Despawn(this);
        levelBuilder.enemyList.Remove(this);
    }

    public class Factory : PlaceholderFactory<Enemy> { }
    public class Pool : MemoryPool<Enemy> { }
}
