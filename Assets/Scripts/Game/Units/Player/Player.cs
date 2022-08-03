using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class Player : MonoBehaviour
{ 
    PlayerStateMachine playerStateMachine;
    internal Skin Skin { get => skin ??= GetComponentInChildren<Skin>(); set => skin = value;} 
    private Skin skin;
    private Weapon CurrentWeapon { get => currentWeapon ??= GetComponentInChildren<Weapon>(); set => currentWeapon = value; }
    private Weapon currentWeapon;
    DiContainer diContainer;
    PlayerStateMachine.Factory stateFactory;

    [Inject]
    void Construct(PlayerStateMachine _playerStateMachine, PlayerStateMachine.Factory _stateFactory)
    {
        playerStateMachine = _playerStateMachine;
        stateFactory = _stateFactory;
    }

    private void Start()
    {
        stateFactory.Create().InitializeState(new PlayerAimingState());
    }

    internal void DoShot()
    {
        Ball ball = CurrentWeapon.Shot();
        ball.Accept(new BallProvider());
    }

}
