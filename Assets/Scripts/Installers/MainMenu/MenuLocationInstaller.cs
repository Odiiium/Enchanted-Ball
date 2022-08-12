using System;
using System.Collections;
using UnityEngine;
using Zenject;

public class MenuLocationInstaller : MonoInstaller
{
    [SerializeField] BallToBuy ballToBuy;
    [SerializeField] ShopCamera shopCamera;

    public override void InstallBindings() => BindObjects();

    private void BindObjects()
    {
        BindShopCamera();
        BindBallToBuy();
    }

    private void BindShopCamera()
    {
        var shopCameraModel = Container.
            InstantiatePrefabForComponent<ShopCamera>
                (shopCamera, shopCamera.transform.position, shopCamera.transform.rotation, null);
        Container.Bind<ShopCamera>().FromInstance(shopCameraModel).AsSingle().NonLazy();
    }

    private void BindBallToBuy()
    {
        var ballToBuyModel = Container.
            InstantiatePrefabForComponent<BallToBuy>
                (ballToBuy, ballToBuy.transform.position, Quaternion.identity, null);
        Container.Bind<BallToBuy>().FromInstance(ballToBuyModel).AsSingle().NonLazy();
    }
}