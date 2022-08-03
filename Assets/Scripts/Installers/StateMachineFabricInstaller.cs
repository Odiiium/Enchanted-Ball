using Zenject;
using UnityEngine;

public class StateMachineFabricInstaller : MonoInstaller 
{
    [SerializeField] PlayerStateMachine playerStateMachine;

    public override void InstallBindings()
    {
        BindStateMachines();
        BindFabrics();
    }

    private void BindStateMachines()
    {
        Container.Bind<PlayerStateMachine>().FromInstance(playerStateMachine).AsSingle().NonLazy();
        
    }
    private void BindFabrics()
    {
        Container.BindFactory<PlayerStateMachine, PlayerStateMachine.Factory>().AsSingle();
    }
}
