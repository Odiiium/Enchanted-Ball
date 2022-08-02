using System.Collections;
using UnityEngine;
using Zenject;

public class PlayerStateMachine : StateMachine
{
    internal PlayerAimingState playerAimingState;

    [Inject]
    void Construct(PlayerAimingState _playerAimingState)
    {
        playerAimingState = _playerAimingState;
    }
}
