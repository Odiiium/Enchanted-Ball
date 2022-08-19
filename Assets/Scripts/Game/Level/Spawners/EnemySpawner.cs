using UnityEngine;
using System.Collections.Generic;
using UniRx;
using UniRx.Triggers;
using Zenject;
public class EnemySpawner : MonoBehaviour 
{
    EnemyObservable enemyObservable = new EnemyObservable();
    internal EnemyFacade.Factory enemyFactory;
    internal List<Enemy> enemyList = new List<Enemy>();
    DiContainer diContainer;

    CoinSpawner coinSpawner { get => diContainer.Resolve<CoinSpawner>(); }
    GridBuilder gridBuilder { get => diContainer.Resolve<GridBuilder>(); }
    Player player { get => diContainer.Resolve<Player>(); }

    [Inject]
    void Construct(EnemyFacade.Factory _enemyFactories, DiContainer _diContainer)
    {
        enemyFactory = _enemyFactories;
        diContainer = _diContainer;
    }
    internal void SpawnEnemy(int tileNumber)
    {
        EnemyFacade enemyToSpawn = enemyFactory.Create();
/*        enemyList.Add(enemyToSpawn);
        enemyToSpawn.transform.position = gridBuilder.tileArray[tileNumber].transform.position;
        enemyObservable.SubscribeToObservables(enemyToSpawn, enemyList, diContainer);*/
    }

}