using UnityEngine;
using System.Collections.Generic;
using UniRx;
using Zenject;

internal class ObstacleSpawner : MonoBehaviour
{
    internal List<Obstacle.Factory> obstacleFactories;
    internal List<Obstacle> obstacleList = new List<Obstacle>();
    DiContainer diContainer;
    GridBuilder gridBuilder { get => diContainer.Resolve<GridBuilder>(); }

    [Inject]
    void Construct(List<Obstacle.Factory> _obstacleFactories, DiContainer _diContainer)
    {
        obstacleFactories = _obstacleFactories;
        diContainer = _diContainer;
    }
    internal void SpawnObstacle(int tileNumber)
    {
        Obstacle obstacleToSpawn = obstacleFactories[Random.Range(0, obstacleFactories.Count)].Create();
        obstacleList.Add(obstacleToSpawn);
        obstacleToSpawn.transform.position = gridBuilder.tileArray[tileNumber].transform.position;
        obstacleToSpawn.HealthPoints.Where(_ => obstacleToSpawn.HealthPoints.Value <= 0).
            Subscribe(_ => obstacleToSpawn.Die(obstacleToSpawn, obstacleList)).AddTo(obstacleToSpawn);
    }
}
