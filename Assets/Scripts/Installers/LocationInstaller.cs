using Zenject;
using UnityEngine;

public class LocationInstaller : MonoInstaller 
{
    [SerializeField] GameObject player;
    [SerializeField] Transform spawnPosition;
    [SerializeField] PlayerController playerController;

    public override void InstallBindings()
    {
        BindPlayerSkin();
        BindPlayerWeapon();
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

    private void BindPlayerSkin()
    {
        Container.Bind<Skin>().FromComponentInChildren(player).AsSingle().NonLazy();
    }
    
    private void BindPlayerWeapon()
    {
        Container.Bind<Weapon>().FromComponentInHierarchy(player).AsSingle().NonLazy();
    }

}
