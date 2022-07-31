using Zenject;
using UnityEngine;

public class StateMachineInstaller : MonoInstaller 
{
    [SerializeField] PlayerStateMachine playerStateMachine;

    public override void InstallBindings()
    {
        BindPlayerStateMachine();
    }

    private void BindPlayerStateMachine()
    {
        Container.Bind<PlayerStateMachine>().FromInstance(playerStateMachine).AsSingle().NonLazy();
    }

}
