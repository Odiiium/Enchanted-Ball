using Zenject;
using UnityEngine;

public class PlayerStateMachineInstaller : MonoInstaller 
{
    [SerializeField] PlayerStateMachine playerStateMachine;

    public override void InstallBindings()
    {
        BindStateMachines();
        BindFactories();
    }

    private void BindStateMachines()
    {
        Container.Bind<PlayerStateMachine>().FromInstance(playerStateMachine).AsSingle().NonLazy();
        
    }
    private void BindFactories()
    {
        Container.BindFactory<PlayerStateMachine, PlayerStateMachine.Factory>().AsSingle();
    }
}
