using System.Collections;
using UnityEngine;

public abstract class StateMachine : MonoBehaviour
{
    internal IState currentState;

    internal virtual void Initialize(IState startState)
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