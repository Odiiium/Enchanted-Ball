using UnityEngine;
using Zenject;

public class Player : MonoBehaviour
{
    internal PlayerStateMachine playerStateMachine;
    internal PlayerStateMachine.Factory playerStateFactory;
    PlayerMovementCanvas playerMovementCanvas;
    internal float damage = 100;

    internal Skin Skin { get => skin ??= GetComponentInChildren<Skin>(); set => skin = value;} 
    private Skin skin;
    private Weapon CurrentWeapon { get => currentWeapon ??= GetComponentInChildren<Weapon>(); set => currentWeapon = value; }
    private Weapon currentWeapon;

    [Inject]
    void Construct(PlayerStateMachine.Factory _playerStateFactory, PlayerMovementCanvas _playerMovementCanvas)
    {
        playerStateFactory = _playerStateFactory;
        playerMovementCanvas = _playerMovementCanvas;
    }

    private void Start() => playerMovementCanvas.Controller.SetInitialAimingState(this);
    internal void DoShot() => CurrentWeapon.Shot();

}
