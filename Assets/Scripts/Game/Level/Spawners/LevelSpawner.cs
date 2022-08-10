using UnityEngine;
using Zenject;

internal class LevelSpawner : MonoBehaviour
{
    internal EnemySpawner enemySpawner;
    internal ObstacleSpawner obstacleSpawner;
    internal WallSpawner wallSpawner;

    [Inject]
    private void Construct(EnemySpawner _enemySpawner, ObstacleSpawner _obstacleSpawner, WallSpawner _wallSpawner)
    {
        enemySpawner = _enemySpawner;
        obstacleSpawner = _obstacleSpawner;
        wallSpawner = _wallSpawner;
    }
}
