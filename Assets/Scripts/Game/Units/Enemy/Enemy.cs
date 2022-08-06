using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
using UniRx;
using UniRx.Triggers;

public class Enemy : MonoBehaviour, IEnemy
{
    EnemyMovable enemyMovable = new EnemyMovable();
    Tile tile;
    DiContainer diContainer;
    int damage = 50;

    internal Tile Tile { get => tile; set => tile = value; }
    PlayerHealthBarCanvas playerHealthBarCanvas { get => diContainer.Resolve<PlayerHealthBarCanvas>(); }
    PlayerBorderCollider playerBorderCollider { get => diContainer.Resolve<PlayerBorderCollider>(); }
    LevelBuilder LevelBuilder { get => levelBuilder ??= diContainer.Resolve<LevelBuilder>(); }
    LevelBuilder levelBuilder;

    [Inject]
    void Construct(DiContainer _diContainer) => diContainer = _diContainer;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 8) Die();
    }

    public void Die()
    {
        Attack();
        LevelBuilder.enemyPool.Despawn(this);
        LevelBuilder.enemyList.Remove(this);
        Destroy(gameObject);
    }
    public void Attack() => playerHealthBarCanvas.Controller.ReduceHealthPoints(damage);

    public void Jump() => enemyMovable.Move(transform);


    public class Pool : MemoryPool<Enemy> { }
}
