using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class Obstacle : Structure
{
    internal Tile Tile { get => tile; set => tile = value; }
    Tile tile;

    public class Pool : MemoryPool<Obstacle> { }
}
