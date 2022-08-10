using UnityEngine;
using Zenject;

public class CanvasInstaller : MonoInstaller
{
    [SerializeField] PlayerMovementCanvas playerMovementCanvas;
    [SerializeField] PlayerHealthBarCanvas playerHealbarCanvas;
    [SerializeField] PlayerMoneyCanvas playerMoneyCanvas;
    [SerializeField] PlayerScoreCanvas playerScoreCanvas;

    public override void InstallBindings()
    {
        BindPlayerMovementCanvas();
        BindPlayerHealthBarCanvas();
        BindPlayerScoreCanvas();
        BindPlayerMoneyCanvas();
    }

    private void BindPlayerMovementCanvas()
    {
        PlayerMovementCanvas playerMovementCanvasModel = Container.
            InstantiatePrefabForComponent<PlayerMovementCanvas>(playerMovementCanvas, Vector3.zero, Quaternion.identity, null);
        Container.Bind<PlayerMovementCanvas>().FromInstance(playerMovementCanvasModel).AsSingle().NonLazy();
    }

    private void BindPlayerHealthBarCanvas()
    {
        PlayerHealthBarCanvas playerHealbarCanvasModel = Container.
            InstantiatePrefabForComponent<PlayerHealthBarCanvas>(playerHealbarCanvas, Vector3.zero, Quaternion.identity, null);
            Container.Bind<PlayerHealthBarCanvas>().FromInstance(playerHealbarCanvasModel).AsSingle().NonLazy();
    }

    private void BindPlayerScoreCanvas()
    {
        PlayerScoreCanvas playerScoreCanvasModel = Container.
            InstantiatePrefabForComponent<PlayerScoreCanvas>(playerScoreCanvas, Vector3.zero, Quaternion.identity, null);
        Container.Bind<PlayerScoreCanvas>().FromInstance(playerScoreCanvasModel).AsSingle().NonLazy();
    }

    private void BindPlayerMoneyCanvas()
    {
        PlayerMoneyCanvas playerMoneyCanvasModel = Container.
            InstantiatePrefabForComponent<PlayerMoneyCanvas>(playerMoneyCanvas, Vector3.zero, Quaternion.identity, null);
        Container.Bind<PlayerMoneyCanvas>().FromInstance(playerMoneyCanvasModel).AsSingle().NonLazy();
    }
}