using UnityEngine;
using System.Collections.Generic;
using UniRx;
using UniRx.Triggers;
using Zenject;
public class EnemySpawner : MonoBehaviour 
{
    [SerializeField] List<Enemy> enemies;
    EnemyObservable enemyObservable = new EnemyObservable();
    internal List<Enemy> enemyList = new List<Enemy>();
    DiContainer diContainer;

    internal EnemyFactory EnemyFactory { get => enemyFactory ??= diContainer.Resolve<EnemyFactory>(); set => enemyFactory = value; }
    internal EnemyFactory enemyFactory;
    GridBuilder gridBuilder { get => diContainer.Resolve<GridBuilder>(); }

    [Inject]
    void Construct(EnemyFactory _enemyFactories, DiContainer _diContainer)
    {
        EnemyFactory = _enemyFactories;
        diContainer = _diContainer;
    }
    internal void SpawnEnemy(int tileNumber)
    {
        Enemy enemyToSpawn = EnemyFactory.
            Create(enemies[Random.Range(0, enemies.Count)], gridBuilder.tileArray[tileNumber].transform.position);
        enemyToSpawn.diContainer = diContainer;
        enemyList.Add(enemyToSpawn);
        enemyObservable.SubscribeToObservables(enemyToSpawn, enemyList, diContainer);
    }

}