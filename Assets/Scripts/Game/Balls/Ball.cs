using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using Zenject;

public abstract class Ball : MonoBehaviour
{
    TurnChanger turnChanger;
    Player player;
    DiContainer diContainer;

    StructureHitProvider hitProvider = new StructureHitProvider();
    FloatReactiveProperty timeWithoutCollisions = new FloatReactiveProperty(0);
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
        SubscribeToDestroyWhenNotObserveAnyCollisions();
    }

    void Update() => timeWithoutCollisions.Value += Time.deltaTime;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent(out Structure structure))
        {
            CreateCollision(structure, diContainer);
            DoDefaultOnDetectAnyCollision();
        }
        else if (collision.gameObject.TryGetComponent(out Enemy enemy)) DoDefaultOnDetectAnyCollision();
    }

    internal void MoveToShotPoint() => BallMovable.Move(player.transform);

    private void SubscribeToDetectCollisions() => collisionsCount.Subscribe(value => { if (value >= 6) EndBallLife(); }).AddTo(this);
    private void SubscribeToDestroyWhenNotObserveAnyCollisions() => timeWithoutCollisions.Subscribe
        (value => { if (value > 3) EndBallLife(); }).AddTo(this);

    private void DoDefaultOnDetectAnyCollision()
    {
        BallMovable.RigidBody.velocity *= 1.06f;
        timeWithoutCollisions.Value = 0;
    }

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
