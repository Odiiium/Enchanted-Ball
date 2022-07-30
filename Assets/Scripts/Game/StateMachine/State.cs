using UnityEngine;

public abstract class State
{
    internal abstract void Enter();
    internal abstract void Exit();

    internal abstract void Update();
}
