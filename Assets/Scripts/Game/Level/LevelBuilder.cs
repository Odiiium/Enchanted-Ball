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
    internal Wall.Pool wallPool;

    internal List<Enemy> enemyList = new List<Enemy>();
    internal List<Obstacle> obstacleList = new List<Obstacle>();
    internal List<Wall> wallList = new List<Wall>();

    [Inject]
    void Construct(GridBuilder _gridBuilder, Enemy.Pool _enemyPool, Obstacle.Pool _obstaclePool, Wall.Pool _wallPool, DiContainer _diContainer)
    {
        diContainer = _diContainer;
        gridBuilder = _gridBuilder;
        enemyPool = _enemyPool;
        obstaclePool = _obstaclePool;
        wallPool = _wallPool;
    }

    private void Start()
    {
        BuildALevel();
    }

    void BuildALevel()
    {
        BuildWalls();
        for (int i = gridBuilder.gridScale.xScale * 4; i < gridBuilder.tileArray.Count; i++)
        {
            var randomNumber = Random.Range(0, 20);
            if (randomNumber < 3) SpawnEnemy(i);
            else if (randomNumber >= 3 && randomNumber < 5) SpawnObstacle(i);
        }
    }

    void BuildWalls()
    {
        for (int i = gridBuilder.gridScale.xScale; i < gridBuilder.tileArray.Count; i++) 
            SpawnSideWalls(i);
        for (int i = 0; i < gridBuilder.gridScale.xScale; i++) 
            SpawnForwardAndBackWalls(i);
    }

    void SpawnEnemy(int tileNumber)
    {
        Enemy enemyToSpawn = enemyPool.Spawn();
        enemyList.Add(enemyToSpawn);
        enemyToSpawn.transform.position = gridBuilder.tileArray[tileNumber].transform.position;
        enemyToSpawn.Tile = gridBuilder.tileArray[tileNumber];
    }

    void SpawnObstacle(int tileNumber)
    {
        Obstacle obstacleToSpawn = obstaclePool.Spawn();
        obstacleList.Add(obstacleToSpawn);
        obstacleToSpawn.transform.position = gridBuilder.tileArray[tileNumber].transform.position;
        obstacleToSpawn.Tile = gridBuilder.tileArray[tileNumber];
    }

    void SpawnSideWalls(int tileNumber)
    {
        var xScale = gridBuilder.gridScale.xScale;
        if (tileNumber % xScale == 0)
        {
            AddWallToList(out Wall wallToSpawn);
            wallToSpawn.transform.position = gridBuilder.tileArray[tileNumber].transform.position + Vector3.left;
        }
        if (tileNumber % xScale == xScale - 1)
        {
            AddWallToList(out Wall wallToSpawn);
            wallToSpawn.transform.position = gridBuilder.tileArray[tileNumber].transform.position + Vector3.right;
        }
    }

    void SpawnForwardAndBackWalls(int cellIndex)
    {
        Wall forwardWallToSpawn = wallPool.Spawn();
        forwardWallToSpawn.transform.position = new Vector3(cellIndex - (gridBuilder.gridScale.xScale - 1)/2, 0, gridBuilder.gridScale.yScale);
        Wall backWallToSpawn = wallPool.Spawn();
        backWallToSpawn.transform.position = new Vector3(cellIndex - (gridBuilder.gridScale.xScale - 1) / 2, 0, -2);
    }

    void AddWallToList(out Wall wall)
    {
        Wall wallToSpawn = wallPool.Spawn();
        wallList.Add(wallToSpawn);
        wall = wallToSpawn;
    }
}

