using UnityEngine;
using Zenject;

public class BuilderInstaller : MonoInstaller
{
    [SerializeField] LevelBuilder levelBuilder;
    Enemy EnemyToSpawn { get => enemy ??= Resources.Load<Enemy>("Enemy/NyanSlime"); }
    Enemy enemy;
    Obstacle ObstacleToSpawn { get => obstacle ??= Resources.Load<Obstacle>("Obstacle/Cube"); }
    Obstacle obstacle;

    public override void InstallBindings()
    {
        BindEnemy();
        BindObstacle();
        BindPools();
        BindLevelBuilder();
    }

    private void BindPools()
    {
        Container.BindMemoryPool<Enemy, Enemy.Pool>().WithInitialSize(0).FromComponentInNewPrefab(EnemyToSpawn);
        Container.BindMemoryPool<Obstacle, Obstacle.Pool>().WithInitialSize(0).FromComponentInNewPrefab(ObstacleToSpawn);
    }
    private void BindLevelBuilder()
    {
        LevelBuilder levelBuilderModel = Container.InstantiatePrefabForComponent<LevelBuilder>
            (levelBuilder, Vector3.zero, Quaternion.identity, null);
        Container.Bind<LevelBuilder>().FromInstance(levelBuilderModel).AsSingle().NonLazy();
    }

    private void BindEnemy() => Container.Bind<Enemy>().FromComponentInNewPrefab(EnemyToSpawn).AsSingle().NonLazy();
    private void BindObstacle() => Container.Bind<Obstacle>().FromComponentInNewPrefab(ObstacleToSpawn).AsSingle().NonLazy();


}