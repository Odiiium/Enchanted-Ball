using System.Collections;
using UnityEngine;
using Zenject;

public class BallFactory : PlaceholderFactory<Ball>
{
    Ball ball;
    Ball Ball { get => ball ??= Resources.Load<Ball>($"Balls/Sphere");}

}