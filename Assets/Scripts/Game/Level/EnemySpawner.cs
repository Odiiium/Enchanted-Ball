using UnityEngine;
using System.Collections.Generic;
using UniRx;
using UniRx.Triggers;
using Zenject;
public class EnemySpawner : MonoBehaviour 
{
    EnemyObservable enemyObservable = new EnemyObservable();
    internal List<Enemy.Factory> enemyFactories;
    internal List<Enemy> enemyList = new List<Enemy>();
    DiContainer diContainer;

    CoinSpawner coinSpawner { get => diContainer.Resolve<CoinSpawner>(); }
    GridBuilder gridBuilder { get => diContainer.Resolve<GridBuilder>(); }
    Player player { get => diContainer.Resolve<Player>(); }

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
        enemyObservable.SubscribeToObservables(enemyToSpawn, enemyList, diContainer);
    }

}