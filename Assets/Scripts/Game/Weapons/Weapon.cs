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
        createdBall.transform.position = Player.transform.position;
        return createdBall;
    }
}
