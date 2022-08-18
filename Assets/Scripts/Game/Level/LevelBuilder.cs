using DG.Tweening;
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

    private void Start() => BuildALevel();

    void BuildALevel()
    {
        BuildEnvironment();
        levelSpawner.wallSpawner.BuildWalls();
        for (int i = xScale() * 4; i < tileCount(); i++)
        {
            var randomNumber = Random.Range(0, 20);
            if (randomNumber < 3) levelSpawner.enemySpawner.SpawnEnemy(i);
            else if (randomNumber >= 3 && randomNumber < 5) levelSpawner.obstacleSpawner.SpawnObstacle(i);
        }
    }

    internal void BuildANewPartOfLevel()
    {
        for (int i = xScale() * (yScale() + 1);
            i < tileCount(); i++)
        {
            levelSpawner.wallSpawner.SpawnSideWalls(i);
            var randomNumber = Random.Range(0, 20);
            if (randomNumber < 3) levelSpawner.enemySpawner.SpawnEnemy(i);
            else if (randomNumber >= 3 && randomNumber < 5) levelSpawner.obstacleSpawner.SpawnObstacle(i);
        }
    }

    private void BuildEnvironment()
    {
        levelSpawner.environmentSpawner.SpawnEnvironment(Vector3.zero);
        levelSpawner.environmentSpawner.SpawnEnvironment(Vector3.forward * 12);
    }

    private int xScale() => gridBuilder.gridScale.xScale;
    private int yScale() => gridBuilder.gridScale.yScale;
    private int tileCount() => gridBuilder.tileArray.Count;
}

