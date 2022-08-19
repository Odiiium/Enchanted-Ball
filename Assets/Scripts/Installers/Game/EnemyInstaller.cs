using System.Collections;
using UnityEngine;
using Zenject;
public class EnemyInstaller : Installer
{
    public override void InstallBindings()
    {
        Container.Bind<EnemyFacade>().AsSingle();
    }
}