using UnityEngine;
using Zenject;

public class CanvasInstaller : MonoInstaller
{
    [SerializeField] PlayerMovementCanvas playerMovementCanvas;

    public override void InstallBindings()
    {
        BindPlayerMovementCanvas();
    }

    private void BindPlayerMovementCanvas()
    {
        PlayerMovementCanvas playerMovementCanvasModel = Container.
            InstantiatePrefabForComponent<PlayerMovementCanvas>(playerMovementCanvas, Vector3.zero, Quaternion.identity, null);
        Container.Bind<PlayerMovementCanvas>().FromInstance(playerMovementCanvasModel).AsSingle().NonLazy();
    }
}