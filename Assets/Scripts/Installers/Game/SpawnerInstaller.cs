﻿using System.Collections.Generic;
using UnityEngine;
using Zenject;
internal class SpawnerInstaller : MonoInstaller
{
    [SerializeField] CoinSpawner coinSpawner;
    [SerializeField] EnemySpawner enemySpawner;
    [SerializeField] ObstacleSpawner obstacleSpawner;
    [SerializeField] WallSpawner wallSpawner;
    [SerializeField] LevelSpawner levelSpawner;

    [SerializeField] Transform spawnersParentTransform;

    [SerializeField] Coin coin;
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
        Container.BindFactory<Coin, Coin.Factory>().FromComponentInNewPrefab(coin);

        foreach (Enemy enemy in enemyToSpawn) Container.
                BindFactory<Enemy, Enemy.Factory>().FromComponentInNewPrefab(enemy);
        foreach (Obstacle obstacle in obstaclesToSpawn) Container.
                BindFactory<Obstacle, Obstacle.Factory>().FromComponentInNewPrefab(obstacle);
        foreach (Wall wall in wallToSpawn) Container.
                BindFactory<Wall, Wall.Factory>().FromComponentInNewPrefab(wall);
    }
    private void BindSpawners()
    {
        BindCoinSpawner();
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

    private void BindCoinSpawner()
    {
        CoinSpawner coinSpawnerModel = Container.InstantiatePrefabForComponent<CoinSpawner>
            (coinSpawner, Vector3.zero, Quaternion.identity, spawnersParentTransform);
        Container.Bind<CoinSpawner>().FromInstance(coinSpawnerModel).AsSingle().NonLazy();
    }
}
