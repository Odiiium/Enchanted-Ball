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

    [SerializeField] List<Enemy> enemyToSpawn;
    [SerializeField] List<Obstacle> obstaclesToSpawn;
    [SerializeField] List<Wall> wallToSpawn;

    public override void InstallBindings()
    {
        BindFactories();
        BindSpawners();
    }

    private void BindFactories()
    {
        foreach (Enemy enemy in enemyToSpawn) Container.
                BindFactory<Enemy, Enemy.Factory>().FromComponentInNewPrefab(enemy);
        foreach (Obstacle obstacle in obstaclesToSpawn) Container.
                BindFactory<Obstacle, Obstacle.Factory>().FromComponentInNewPrefab(obstacle);
        foreach (Wall wall in wallToSpawn) Container.
                BindFactory<Wall, Wall.Factory>().FromComponentInNewPrefab(wall);
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

