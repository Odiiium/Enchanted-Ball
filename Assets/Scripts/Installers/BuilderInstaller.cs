﻿using UnityEngine;
using Zenject;

public class BuilderInstaller : MonoInstaller
{
    [SerializeField] LevelBuilder levelBuilder;
    Enemy EnemyToSpawn { get => enemy ??= Resources.Load<Enemy>("Enemy/NyanSlime"); }
    Enemy enemy;
    Obstacle ObstacleToSpawn { get => obstacle ??= Resources.Load<Obstacle>("Obstacle/Cube"); }
    Obstacle obstacle;
    Wall WallToSpawn { get => wall ??= Resources.Load<Wall>("Walls/Wall"); }
    Wall wall;

    public override void InstallBindings()
    {
        BindPools();
        BindLevelBuilder();
    }

    private void BindPools()
    {
        Container.BindMemoryPool<Enemy, Enemy.Pool>().FromComponentInNewPrefab(EnemyToSpawn);
        Container.BindMemoryPool<Obstacle, Obstacle.Pool>().FromComponentInNewPrefab(ObstacleToSpawn);
        Container.BindMemoryPool<Wall, Wall.Pool>().FromComponentInNewPrefab(WallToSpawn);
    }
    private void BindLevelBuilder()
    {
        LevelBuilder levelBuilderModel = Container.InstantiatePrefabForComponent<LevelBuilder>
            (levelBuilder, Vector3.zero, Quaternion.identity, null);
        Container.Bind<LevelBuilder>().FromInstance(levelBuilderModel).AsSingle().NonLazy();
    }

}