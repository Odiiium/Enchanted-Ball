using UnityEngine;
using System.Collections.Generic;
using UniRx;
using Zenject;
internal class EnemySpawner : MonoBehaviour 
{
    internal Enemy.Factory enemyFactory;
    internal List<Enemy> enemyList = new List<Enemy>();
    DiContainer diContainer;
    GridBuilder gridBuilder { get => diContainer.Resolve<GridBuilder>(); }

    [Inject]
    private void Construct(Enemy.Factory _enemyFactory, DiContainer _diContainer)
    {
        enemyFactory = _enemyFactory;
        diContainer = _diContainer; 
    }
    internal void SpawnEnemy(int tileNumber)
    {
        Enemy enemyToSpawn = enemyFactory.Create();
        enemyList.Add(enemyToSpawn);
        enemyToSpawn.transform.position = gridBuilder.tileArray[tileNumber].transform.position;
        enemyToSpawn.HealthPoints.Where(_ => enemyToSpawn.HealthPoints.Value <= 0).
            Subscribe(_ => enemyToSpawn.Die(enemyToSpawn, enemyList)).AddTo(enemyToSpawn);
    }
}
