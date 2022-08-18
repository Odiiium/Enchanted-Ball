using System;
using UnityEngine;
using Zenject;

public class BuilderInstaller : MonoInstaller
{
    [SerializeField] LevelBuilder levelBuilder;
    [SerializeField] PlayerBorderCollider playerBorderCollider;
    [SerializeField] WallBorderCollider wallBorderCollider;
    [SerializeField] EnvironmentBorder environmentBorderCollider;

    [SerializeField] Transform levelBuilderParentTransform;

    public override void InstallBindings()
    {
        BindPlayerBorderCollider();
        BindLevelBuilder();
        BindWallBorderCollider();
        BindEnvironmentBorder();
    }

    private void BindEnvironmentBorder()
    {
        EnvironmentBorder environmentBorderModel = Container.InstantiatePrefabForComponent<EnvironmentBorder>
            (environmentBorderCollider, Vector3.forward * -12, Quaternion.identity, null);
        Container.Bind<EnvironmentBorder>().FromInstance(environmentBorderModel).AsSingle().NonLazy();
    }

    private void BindLevelBuilder()
    {
        LevelBuilder levelBuilderModel = Container.InstantiatePrefabForComponent<LevelBuilder>
            (levelBuilder, Vector3.zero, Quaternion.identity, levelBuilderParentTransform);
        Container.Bind<LevelBuilder>().FromInstance(levelBuilderModel).AsSingle().NonLazy();
    }

    private void BindPlayerBorderCollider()
    {
        PlayerBorderCollider playerBorderColliderModel = Container.InstantiatePrefabForComponent<PlayerBorderCollider>
            (playerBorderCollider, Vector3.zero, Quaternion.identity, levelBuilderParentTransform.GetChild(0));
        Container.Bind<PlayerBorderCollider>().FromInstance(playerBorderColliderModel).AsSingle().NonLazy();
    }

    private void BindWallBorderCollider()
    {
        WallBorderCollider wallBorderColliderModel = Container.InstantiatePrefabForComponent<WallBorderCollider>
    (wallBorderCollider, Vector3.zero + Vector3.back * 3, Quaternion.identity, levelBuilderParentTransform.GetChild(0));
        Container.Bind<WallBorderCollider>().FromInstance(wallBorderColliderModel).AsSingle().NonLazy();
    }

}