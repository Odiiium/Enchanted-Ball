using System.Collections;
using UnityEngine;
using Zenject;

public class BallFactory : PlaceholderFactory<Ball>
{
    Ball ball;
    Ball Ball { get => ball ??= Resources.Load<Ball>($"Balls/Sphere");}

    DiContainer diContainer;

    public BallFactory(DiContainer _diContainer)
    {
        diContainer = _diContainer;
    }
    public Ball Create(Vector3 at)
    {
        Ball createdball =  diContainer.InstantiatePrefabForComponent<Ball>(ball, at, Quaternion.identity, null);
        return createdball;
    }

}