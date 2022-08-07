using System.Collections.Generic;
using UnityEngine;
using Zenject;


public class Enemy : MonoBehaviour, IEnemy
{
    EnemyMovable enemyMovable = new EnemyMovable();
    DiContainer diContainer;
    int damage = 50;

    internal Collider Collider { get => enemyCollider ??= GetComponent<Collider>(); }
    Collider enemyCollider;
    PlayerHealthBarCanvas playerHealthBarCanvas { get => diContainer.Resolve<PlayerHealthBarCanvas>(); }
    LevelBuilder LevelBuilder { get => levelBuilder ??= diContainer.Resolve<LevelBuilder>(); }
    LevelBuilder levelBuilder;
    internal EnemyHealthBarController HealthController { get => healthBarController ??= GetComponentInChildren<EnemyHealthBarController>(); }
    EnemyHealthBarController healthBarController;

    [Inject]
    void Construct(DiContainer _diContainer) => diContainer = _diContainer;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 8) HealthController.Model.HealthPoints.Value = 0;
    }

    public void Die(Enemy enemy, List<Enemy> enemyList)
    {
        Attack();
        enemyList.RemoveAt(enemyList.IndexOf(enemy));
        Destroy(gameObject);
    }
    public void Attack() => playerHealthBarCanvas.Controller.ReduceHealthPoints(damage);
    public void Jump() => enemyMovable.Move(transform);
    public class Factory : PlaceholderFactory<Enemy> { }
}
