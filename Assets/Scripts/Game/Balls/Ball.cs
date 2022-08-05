using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using Zenject;

public abstract class Ball : MonoBehaviour
{
    TurnChanger turnChanger;
    Player player;
    ReactiveProperty<int> collisionsCount = new ReactiveProperty<int>();
    internal BallMovable BallMovable { get => ballMovable ??= GetComponent<BallMovable>(); }
    BallMovable ballMovable;

    [Inject]
    void Construct(Player _player, TurnChanger _turnChanger)
    {
        turnChanger  = _turnChanger;
        player = _player;
    }

    private void Start()
    {
        collisionsCount.Value = 0;
        SubscribeToDetectCollisions();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent(out Wall wall) | collision.gameObject.TryGetComponent(out Obstacle obstacle))
        {
            CreateCollision(obstacle);
        }
    }


    internal void MoveToShotPoint() => BallMovable.Move(player.transform);

    private void SubscribeToDetectCollisions() => collisionsCount.Subscribe(_ => { if (collisionsCount.Value >= 4) EndBallLife(); }).AddTo(this);

    private void EndBallLife()
    {
        turnChanger.ChangeTurnToNew();
        Destroy(gameObject);
    }

    private void CreateCollision(Obstacle obstacle)
    {
        collisionsCount.Value++;
        Hit hit = MakeHit(obstacle);
        hit.Accept(new HitProvider());
    }

    private Hit MakeHit(Obstacle obstacle)
    {
        return new WallHit();
    }

    private Hit MakeHit(Enemy enemy)
    {
        return new EnemyHit();
    }
}
