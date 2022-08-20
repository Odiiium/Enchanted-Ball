using UnityEditor;
using UnityEngine;
using Zenject;
public class MovableInstaller : MonoInstaller
{
    public override void InstallBindings() => BindMovables();

    private void BindMovables()
    {
        Container.Bind<EnemyMovable>().AsSingle().NonLazy();
        Container.Bind<EnvironmentMovable>().AsSingle();
        Container.Bind<StructureMovable>().AsSingle();
        Container.Bind<AimRayMovable>().AsSingle();
    }

}