using Zenject;
using UnityEngine;

public class LocationInstaller : MonoInstaller
{
    [SerializeField] GameObject player;
    [SerializeField] Transform spawnPosition;
    [SerializeField] TurnChanger turnChanger;

    Ball BallPrefab { get => ballPrefab ??= Resources.Load<Ball>("Balls/Sphere"); }
    Ball ballPrefab;

    public override void InstallBindings()
    {
        BindFactory();
        BindPlayer();
        BindTurnChanger();
    }

    private void BindPlayer()
    {
        Player playerModel = Container.
            InstantiatePrefabForComponent<Player>(player, spawnPosition.position, Quaternion.identity, null);
        Container.Bind<Player>().FromInstance(playerModel).AsSingle().NonLazy();
    }

    private void BindFactory()
    {
        Container.BindFactory<Ball, BallFactory>().FromComponentInNewPrefab(BallPrefab);
    }

    private void BindTurnChanger()
    {
        TurnChanger turnChangerModel = Container.
            InstantiatePrefabForComponent<TurnChanger>(turnChanger, spawnPosition.position, Quaternion.identity, null);
        Container.Bind<TurnChanger>().FromInstance(turnChangerModel).AsSingle().NonLazy();
    }
}
