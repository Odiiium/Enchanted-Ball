using System.Collections.Generic;
using UnityEngine;
using Zenject;


public class Enemy : MonoBehaviour, IEnemy
{
    DiContainer diContainer;
    internal EnemyModel Model { get => enemyModel ??= GetComponentInChildren<EnemyModel>(); set => enemyModel ??= GetComponentInChildren<EnemyModel>();}
    EnemyModel enemyModel;
    PlayerHealthBarCanvas playerHealthBarCanvas { get => diContainer.Resolve<PlayerHealthBarCanvas>(); }
    PlayerScoreCanvas playerScoreCanvas { get => diContainer.Resolve<PlayerScoreCanvas>(); } 
    LevelBuilder LevelBuilder { get => levelBuilder ??= diContainer.Resolve<LevelBuilder>(); }
    LevelBuilder levelBuilder;

    [Inject]
    void Construct(DiContainer _diContainer) => diContainer = _diContainer;
    void Start() => Model.EnemySettings.SetUpSettings
        (Model.HealthController.Model.HealthPoints.Value, Model.HealthController.Model.maxHealth);

    public void Die(Enemy enemy, List<Enemy> enemyList)
    {
        playerScoreCanvas.Controller.AddScore();
        enemyList.RemoveAt(enemyList.IndexOf(enemy));
        Destroy(gameObject);
    }

    public void Attack() => playerHealthBarCanvas.Controller.ReduceHealthPoints(Model.EnemySettings.damage);
    public void Jump() => Model.EnemyMovable.Move(transform);
    public class Factory : PlaceholderFactory<Enemy> { }

}
