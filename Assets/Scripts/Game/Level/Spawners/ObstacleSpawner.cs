using UnityEngine;
using System.Collections.Generic;
using UniRx;
using Zenject;

internal class ObstacleSpawner : MonoBehaviour
{
    DiContainer diContainer;
    ObstacleFactory obstacleFactory;
    [SerializeField] internal List<Obstacle> obstacles;
    internal List<Obstacle> obstacleList = new List<Obstacle>();
    GridBuilder gridBuilder { get => diContainer.Resolve<GridBuilder>(); }

    [Inject]
    void Construct(ObstacleFactory _obstacleFactory, DiContainer _diContainer)
    {
        obstacleFactory = _obstacleFactory;
        diContainer = _diContainer;
    }
    internal void SpawnObstacle(int tileNumber)
    {
        Obstacle obstacleToSpawn = obstacleFactory.Create
            (obstacles[Random.Range(0, obstacles.Count)], gridBuilder.tileArray[tileNumber].transform.position);
        obstacleList.Add(obstacleToSpawn);

        obstacleToSpawn.HealthPoints.Where(_ => obstacleToSpawn.HealthPoints.Value <= 0).
            Subscribe(_ => obstacleToSpawn.Die(obstacleToSpawn, obstacleList)).AddTo(obstacleToSpawn);
    }
}
