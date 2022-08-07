using UnityEngine;
using System.Collections.Generic;
using UniRx;
using Zenject;

internal class ObstacleSpawner : MonoBehaviour
{
    internal Obstacle.Factory obstacleFactory;
    internal List<Obstacle> obstacleList = new List<Obstacle>();
    DiContainer diContainer;
    GridBuilder gridBuilder { get => diContainer.Resolve<GridBuilder>(); }

    [Inject]
    void Construct(Obstacle.Factory _obstacleFactory, DiContainer _diContainer)
    {
        obstacleFactory = _obstacleFactory;
        diContainer = _diContainer;
    }
    internal void SpawnObstacle(int tileNumber)
    {
        Obstacle obstacleToSpawn = obstacleFactory.Create();
        obstacleList.Add(obstacleToSpawn);
        obstacleToSpawn.transform.position = gridBuilder.tileArray[tileNumber].transform.position;
        obstacleToSpawn.HealthPoints.Where(_ => obstacleToSpawn.HealthPoints.Value <= 0).
            Subscribe(_ => obstacleToSpawn.Die(obstacleToSpawn, obstacleList)).AddTo(obstacleToSpawn);
    }
}
