using UnityEngine;
using Zenject;

internal class LevelSpawner : MonoBehaviour
{
    internal EnemySpawner enemySpawner;
    internal ObstacleSpawner obstacleSpawner;
    internal WallSpawner wallSpawner;
    internal EnvironmentSpawner environmentSpawner;

    [Inject]
    private void Construct(EnemySpawner _enemySpawner, ObstacleSpawner _obstacleSpawner, WallSpawner _wallSpawner, EnvironmentSpawner _environmentSpawner)
    {
        enemySpawner = _enemySpawner;
        obstacleSpawner = _obstacleSpawner;
        wallSpawner = _wallSpawner;
        environmentSpawner = _environmentSpawner;
    }
}
