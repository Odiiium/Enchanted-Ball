using Zenject;
using UnityEngine;

public class StateMachineInstaller : MonoInstaller 
{
    [SerializeField] PlayerStateMachine playerStateMachine;
    [SerializeField] PlayerAimingState playerAimingState;

    public override void InstallBindings()
    {
        BindStates();
        BindPlayerStateMachine();
    }

    private void BindPlayerStateMachine()
    {
        Container.Bind<PlayerStateMachine>().FromInstance(playerStateMachine).AsSingle().NonLazy();
    }

    private void BindStates()
    {
        Container.Bind<PlayerAimingState>().FromInstance(playerAimingState).AsSingle().NonLazy();
    }
}
