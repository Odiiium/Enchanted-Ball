using System.Collections.Generic;
using UnityEngine;
using Zenject;
internal class SpawnerInstaller : MonoInstaller
{
    [SerializeField] EnemySpawner enemySpawner;
    [SerializeField] ObstacleSpawner obstacleSpawner;
    [SerializeField] WallSpawner wallSpawner;
    [SerializeField] LevelSpawner levelSpawner;

    [SerializeField] Transform spawnersParentTransform;

    [SerializeField] List<Enemy> EnemyToSpawn;
    Obstacle ObstacleToSpawn { get => obstacle ??= Resources.Load<Obstacle>("Obstacle/Cube"); }
    Obstacle obstacle;
    Wall WallToSpawn { get => wall ??= Resources.Load<Wall>("Walls/Wall"); }
    Wall wall;

    public override void InstallBindings()
    {
        BindFactories();
        BindSpawners();
    }

    private void BindFactories()
    {
        foreach (Enemy enemy in EnemyToSpawn) Container.
                BindFactory<Enemy, Enemy.Factory>().FromComponentInNewPrefab(enemy);
        Container.BindFactory<Obstacle, Obstacle.Factory>().FromComponentInNewPrefab(ObstacleToSpawn);
        Container.BindFactory<Wall, Wall.Factory>().FromComponentInNewPrefab(WallToSpawn);
    }
    private void BindSpawners()
    {
        BindEnemySpawner();
        BindObstacleSpawner(); 
        BindWallsSpawner();
        BindLevelSpawner();
    }

    private void BindEnemySpawner()
    {
        EnemySpawner enemySpawnerModel = Container.InstantiatePrefabForComponent<EnemySpawner>
            (enemySpawner, Vector3.zero, Quaternion.identity, spawnersParentTransform);
        Container.Bind<EnemySpawner>().FromInstance(enemySpawnerModel).AsSingle().NonLazy();
    }
    private void BindObstacleSpawner()
    {
        ObstacleSpawner obstacleSpawnerModel = Container.InstantiatePrefabForComponent<ObstacleSpawner>
            (obstacleSpawner, Vector3.zero, Quaternion.identity, spawnersParentTransform);
        Container.Bind<ObstacleSpawner>().FromInstance(obstacleSpawnerModel).AsSingle().NonLazy();
    }

    private void BindWallsSpawner()
    {
        WallSpawner wallSpawnerModel = Container.InstantiatePrefabForComponent<WallSpawner>
            (wallSpawner, Vector3.zero, Quaternion.identity, spawnersParentTransform);
        Container.Bind<WallSpawner>().FromInstance(wallSpawnerModel).AsSingle().NonLazy();
    }

    private void BindLevelSpawner()
    {
        LevelSpawner levelSpawnerModel = Container.InstantiatePrefabForComponent<LevelSpawner>
            (levelSpawner, Vector3.zero, Quaternion.identity, spawnersParentTransform);
        Container.Bind<LevelSpawner>().FromInstance(levelSpawnerModel).AsSingle().NonLazy();
    }
}

