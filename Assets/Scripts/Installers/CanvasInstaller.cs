using UnityEngine;
using Zenject;

public class CanvasInstaller : MonoInstaller
{
    [SerializeField] PlayerMovementCanvas playerMovementCanvas;
    [SerializeField] PlayerHealthBarCanvas playerHealbarCanvas;

    public override void InstallBindings()
    {
        BindPlayerMovementCanvas();
        BindPlayerHealthBarCanvas();
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
}