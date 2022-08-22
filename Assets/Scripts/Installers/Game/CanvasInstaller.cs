using UnityEngine;
using Zenject;

public class CanvasInstaller : MonoInstaller
{
    [SerializeField] PlayerMovementCanvas playerMovementCanvas;
    [SerializeField] PlayerHealthBarCanvas playerHealbarCanvas;
    [SerializeField] PlayerMoneyCanvas playerMoneyCanvas;
    [SerializeField] PlayerScoreCanvas playerScoreCanvas;
    [SerializeField] EndGameUICanvas endGameCanvas;
    [SerializeField] PauseMenuCanvas pauseMenuCanvas;

    [SerializeField] Transform parentTransform;

    public override void InstallBindings()
    {
        BindPlayerMovementCanvas();
        BindPlayerHealthBarCanvas();
        BindPlayerScoreCanvas();
        BindPlayerMoneyCanvas();
        BindPauseMenuCanvas();
        BindEndGameCanvas();
    }

    void BindPlayerMovementCanvas()
    {
        PlayerMovementCanvas playerMovementCanvasModel = Container.
            InstantiatePrefabForComponent<PlayerMovementCanvas>(playerMovementCanvas, Vector3.zero, Quaternion.identity, parentTransform);
        Container.Bind<PlayerMovementCanvas>().FromInstance(playerMovementCanvasModel).AsSingle().NonLazy();
    }

    void BindPlayerHealthBarCanvas()
    {
        PlayerHealthBarCanvas playerHealbarCanvasModel = Container.
            InstantiatePrefabForComponent<PlayerHealthBarCanvas>(playerHealbarCanvas, Vector3.zero, Quaternion.identity, parentTransform);
            Container.Bind<PlayerHealthBarCanvas>().FromInstance(playerHealbarCanvasModel).AsSingle().NonLazy();
    }

    void BindPlayerScoreCanvas()
    {
        PlayerScoreCanvas playerScoreCanvasModel = Container.
            InstantiatePrefabForComponent<PlayerScoreCanvas>(playerScoreCanvas, Vector3.zero, Quaternion.identity, parentTransform);
        Container.Bind<PlayerScoreCanvas>().FromInstance(playerScoreCanvasModel).AsSingle().NonLazy();
    }

    void BindPlayerMoneyCanvas()
    {
        PlayerMoneyCanvas playerMoneyCanvasModel = Container.
            InstantiatePrefabForComponent<PlayerMoneyCanvas>(playerMoneyCanvas, Vector3.zero, Quaternion.identity, parentTransform);
        Container.Bind<PlayerMoneyCanvas>().FromInstance(playerMoneyCanvasModel).AsSingle().NonLazy();
    }
    
    void BindEndGameCanvas()
    {
        EndGameUICanvas endGameCanvasModel = Container.
            InstantiatePrefabForComponent<EndGameUICanvas>(endGameCanvas, Vector3.zero, Quaternion.identity, parentTransform);
        Container.Bind<EndGameUICanvas>().FromInstance(endGameCanvasModel).AsSingle().NonLazy();
    }
    
    void BindPauseMenuCanvas()
    {
        PauseMenuCanvas pauseMenuModel = Container.
            InstantiatePrefabForComponent<PauseMenuCanvas>(pauseMenuCanvas, Vector3.zero, Quaternion.identity, parentTransform);
        Container.Bind<PauseMenuCanvas>().FromInstance(pauseMenuModel).AsSingle().NonLazy();
    }
}