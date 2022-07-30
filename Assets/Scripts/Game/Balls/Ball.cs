using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public abstract class Ball : MonoBehaviour
{
    Player player;
    internal BallMovable BallMovable { get => ballMovable ??= GetComponent<BallMovable>(); }
    BallMovable ballMovable;

    [Inject]
    void Construct(Player _player)
    {
        player = _player;
    }

    internal void MoveToShotPoint() => BallMovable.Move(player.transform);


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent(out Obstacle obstacle))
        {
            Hit hit = MakeHit(obstacle);
            hit.Accept(new HitProvider());
        }
    }

    private Hit MakeHit(Obstacle obstacle)
    {
        return new WallHit();
    }

    private Hit MakeHit(Enemy enemy)
    {
        return new EnemyHit();
    }

    internal void Accept(IBallVisitor ballVisitor)
    {
        ballVisitor.Visit(this);
    }
}
