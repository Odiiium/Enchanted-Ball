using System.Collections;
using UnityEngine;
using Zenject;
public abstract class StateMachine : MonoBehaviour
{
    internal IState currentState;

    internal virtual void InitializeState(IState startState)
    {
        currentState = startState;
        currentState.Enter();
    }

    internal virtual void ChangeState(IState state)
    {
        currentState.Exit();
        currentState = state;
        currentState.Enter();
    }

}