using Zenject;
using UnityEngine;

public class LocationInstaller : MonoInstaller
{
    [SerializeField] GameObject player;
    [SerializeField] Transform spawnPosition;
    [SerializeField] PlayerController playerController;
    [SerializeField] Ball Ballprefab;

    public override void InstallBindings()
    {
        BindFactory();
        BindPlayer();
        BindPlayerController();
    }

    private void BindPlayer()
    {
        Player playerModel = Container.
            InstantiatePrefabForComponent<Player>(player, spawnPosition.position, Quaternion.identity, null);
        Container.Bind<Player>().FromInstance(playerModel).AsSingle().NonLazy();

        Container.Bind<PlayerMovable>().FromInstance(new PlayerMovable()).AsSingle().NonLazy();

    }

    private void BindPlayerController()
    {
        PlayerController playerControllerModel = Container.
            InstantiatePrefabForComponent<PlayerController>(playerController, spawnPosition.position, Quaternion.identity, null);
        Container.Bind<PlayerController>().FromInstance(playerControllerModel).AsSingle().NonLazy();
    }

    private void BindFactory()
    {
        Container.BindFactory<Ball, BallFactory>().FromComponentInNewPrefab(Ballprefab);
    }
}
