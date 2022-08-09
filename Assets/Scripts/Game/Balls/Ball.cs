using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using Zenject;

public abstract class Ball : MonoBehaviour
{
    StructureHitProvider hitProvider = new StructureHitProvider();
    TurnChanger turnChanger;
    Player player;
    DiContainer diContainer;
    ReactiveProperty<int> collisionsCount = new ReactiveProperty<int>();
    internal BallMovable BallMovable { get => ballMovable ??= GetComponent<BallMovable>(); }
    BallMovable ballMovable;

    [Inject]
    void Construct(Player _player, TurnChanger _turnChanger, DiContainer _diContainer)
    {
        turnChanger  = _turnChanger;
        player = _player;
        diContainer = _diContainer;
    }

    private void Start()
    {
        collisionsCount.Value = 0;
        SubscribeToDetectCollisions();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent(out Structure structure)) CreateCollision(structure, diContainer);
    }

    internal void MoveToShotPoint() => BallMovable.Move(player.transform);

    private void SubscribeToDetectCollisions() => collisionsCount.Subscribe(value => { if (value >= 4) EndBallLife(); }).AddTo(this);

    private void EndBallLife()
    {
        turnChanger.ChangeTurnToNew();
        Destroy(gameObject);
    }

    private void CreateCollision(Structure structure, DiContainer diContainer)
    {
        collisionsCount.Value++;
        structure.Accept(hitProvider, diContainer);
    }
}
