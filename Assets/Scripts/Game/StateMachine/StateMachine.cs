using System.Collections;
using UnityEngine;


public abstract class StateMachine : MonoBehaviour
{
    internal State currentState;

    internal virtual void Initialize(State startState)
    {
        currentState = startState;
        startState.Enter();
    }

    internal virtual void ChangeState(State state)
    {
        currentState.Exit();
        currentState = state;
        currentState.Enter();
    }

}