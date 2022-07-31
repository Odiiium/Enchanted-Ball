using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class Player : MonoBehaviour
{
    StateMachine playerStateMachine;
    internal Skin Skin { get => skin ??= GetComponentInChildren<Skin>(); set => skin = value;} 
    private Skin skin;
    private Weapon CurrentWeapon { get => currentWeapon ??= GetComponentInChildren<Weapon>(); set => currentWeapon = value; }
    private Weapon currentWeapon;


    [Inject]
    void Construct(PlayerStateMachine _playerStateMachine)
    {
        playerStateMachine = _playerStateMachine;
    }

    private void Start()
    {
        playerStateMachine.Initialize(new PlayerAimingState());
    }

    internal void DoShot()
    {
        Ball ball = CurrentWeapon.Shot();
        ball.Accept(new BallProvider());
    }

}
