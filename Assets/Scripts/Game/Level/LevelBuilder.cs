using System.Collections.Generic;
using System.Linq;
using Zenject;
using UnityEngine;
using UniRx;
public class LevelBuilder : MonoBehaviour
{
    GridBuilder gridBuilder;
    DiContainer diContainer;
    internal LevelSpawner levelSpawner;

    [Inject]
    void Construct(GridBuilder _gridBuilder, LevelSpawner _levelSpawner, DiContainer _diContainer)
    {
        diContainer = _diContainer;
        gridBuilder = _gridBuilder;
        levelSpawner = _levelSpawner;
    }

    private void Start()
    {
        BuildALevel();
    }

    void BuildALevel()
    {
        levelSpawner.wallSpawner.BuildWalls();
        for (int i = gridBuilder.gridScale.xScale * 4; i < gridBuilder.tileArray.Count; i++)
        {
            var randomNumber = Random.Range(0, 20);
            if (randomNumber < 3) levelSpawner.enemySpawner.SpawnEnemy(i);
            else if (randomNumber >= 3 && randomNumber < 5) levelSpawner.obstacleSpawner.SpawnObstacle(i);
        }
    }
}

