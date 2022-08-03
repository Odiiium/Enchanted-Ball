using System.Collections;
using UnityEngine;
using Zenject;
public abstract class StateMachine
{
    internal IState currentState;
    internal DiContainer diContainer;

    internal virtual void InitializeState(IState startState)
    {
        currentState = startState;
        currentState.DiContainer = this.diContainer;
        currentState.Enter();
    }

    internal virtual void ChangeState(IState state)
    {
        currentState.Exit();
        currentState = state;
        currentState.DiContainer = this.diContainer;
        currentState.Enter();
    }

}