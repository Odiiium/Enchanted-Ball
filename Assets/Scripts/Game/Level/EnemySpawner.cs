using UnityEngine;
using System.Collections.Generic;
using UniRx;
using UniRx.Triggers;
using Zenject;
internal class EnemySpawner : MonoBehaviour 
{
    internal List<Enemy.Factory> enemyFactories
        ;
    internal List<Enemy> enemyList = new List<Enemy>();
    DiContainer diContainer;
    GridBuilder gridBuilder { get => diContainer.Resolve<GridBuilder>(); }

    [Inject]
    void Construct(List<Enemy.Factory> _enemyFactories, DiContainer _diContainer)
    {
        enemyFactories = _enemyFactories;
        diContainer = _diContainer;
    }
    internal void SpawnEnemy(int tileNumber)
    {
        Enemy enemyToSpawn = enemyFactories[Random.Range(0, enemyFactories.Count)].Create();
        enemyList.Add(enemyToSpawn);
        enemyToSpawn.transform.position = gridBuilder.tileArray[tileNumber].transform.position;
        SubscribeToObservables(enemyToSpawn);
    }

    void SubscribeToObservables(Enemy enemyToSpawn)
    {
        SubscribeToHealthChangedEvent(enemyToSpawn);
        SubscribeToCollisionDetectionEvent(enemyToSpawn);
    }

    void SubscribeToHealthChangedEvent(Enemy enemyToSpawn)
    {
        EnemyHealth(enemyToSpawn).
            Where(_ => EnemyHealth(enemyToSpawn).Value <= 0).
            Subscribe(_ => enemyToSpawn.Die(enemyToSpawn, enemyList)).
            AddTo(enemyToSpawn);
    }

    void SubscribeToCollisionDetectionEvent(Enemy enemyToSpawn)
    {
        enemyToSpawn.Model.Collider.OnCollisionEnterAsObservable().
            Subscribe(collision => 
            { if (collision.gameObject.layer == 7) EnemyHealth(enemyToSpawn).Value -= 100; }
            ).AddTo(enemyToSpawn);
    }

    private FloatReactiveProperty EnemyHealth(Enemy enemyToSpawn) => enemyToSpawn.Model.HealthController.Model.HealthPoints;
}