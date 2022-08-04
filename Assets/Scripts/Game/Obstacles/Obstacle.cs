using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class Obstacle : MonoBehaviour
{
    ObstacleMovable obstacleMovable;
    internal Tile Tile { get => tile; set => tile = value; }
    Tile tile;

    public class Pool : MemoryPool<Obstacle> { }
}
