using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class Weapon : MonoBehaviour
{
    BallFactory ballFactory;
    Ball ball;

    Player player;
    Player Player => player ??= GetComponentInParent<Player>();

    [Inject]
    internal void Construct (BallFactory _ballFactory)
    {        
        ballFactory = _ballFactory;
    }

    internal Ball Shot()
    {
        Ball createdBall = ballFactory.Create();
        MoveBallToShotPoint(createdBall);
        return createdBall;
    }

    private void MoveBallToShotPoint(Ball createdBall)
    {
        createdBall.transform.position = Player.transform.position + new Vector3(0, 0.4f, 0.3f);
        createdBall.MoveToShotPoint();
    }
}
