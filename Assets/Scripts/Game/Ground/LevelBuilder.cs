using System.Collections.Generic;
using System.Linq;
using Zenject;
using UnityEngine;
public class LevelBuilder : MonoBehaviour
{
    GridBuilder gridBuilder;
    DiContainer diContainer;

    internal Enemy.Pool enemyPool;
    internal Obstacle.Pool obstaclePool;

    internal List<Enemy> enemyList = new List<Enemy>();
    internal List<Obstacle> obstacleList = new List<Obstacle>();

    [Inject]
    void Construct(GridBuilder _gridBuilder , Enemy.Pool _enemyPool, Obstacle.Pool _obstaclePool, DiContainer _diContainer)
    {
        diContainer = _diContainer;
        gridBuilder = _gridBuilder;
        enemyPool = _enemyPool;
        obstaclePool = _obstaclePool;
    }

    private void Start()
    {
        DoInitialSpawn();
    }

    private void DoInitialSpawn()
    {
        for (int i = gridBuilder.gridScale.xScale * 4; i < gridBuilder.tileArray.Count; i++)
        {
            var randomNumber = Random.Range(0, 20);

            if (randomNumber < 3) SpawnEnemy(i);
            else if (randomNumber >= 3 && randomNumber < 5) SpawnObstacle(i);
        }
    }

    internal void DoInGameSpawn()
    {

    }

    private void SpawnEnemy(int tileNumber)
    {
        Enemy enemyToSpawn = enemyPool.Spawn();
        enemyList.Add(enemyToSpawn);
        enemyToSpawn.transform.position = gridBuilder.tileArray[tileNumber].transform.position;
        enemyToSpawn.Tile = gridBuilder.tileArray[tileNumber];
    }

    private void SpawnObstacle(int tileNumber)
    {
        Obstacle obstacleToSpawn = obstaclePool.Spawn();
        obstacleList.Add(obstacleToSpawn);
        obstacleToSpawn.transform.position = gridBuilder.tileArray[tileNumber].transform.position;
        obstacleToSpawn.Tile = gridBuilder.tileArray[tileNumber];
    }

}

