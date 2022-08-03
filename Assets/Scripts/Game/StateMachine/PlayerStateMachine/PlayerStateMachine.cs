using System.Collections;
using UnityEngine;
using Zenject;

public class PlayerStateMachine
{
    internal DiContainer diContainer;
    IState currentState;

    [Inject]
    void Construct(DiContainer _diContainer)
    {
        diContainer = _diContainer;
        Debug.Log("INJECTED");
    }

    internal void InitializeState(IState startState)
    {
        currentState = startState;
        currentState.DiContainer = this.diContainer;
        currentState.Enter();
    }

    internal void ChangeState(IState state)
    {
        state.DiContainer = this.diContainer;
        currentState.Exit();
        currentState = state;
        currentState.Enter();
    }

    public class Factory : PlaceholderFactory<PlayerStateMachine> { }
}
