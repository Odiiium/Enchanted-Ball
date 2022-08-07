﻿using System.Collections.Generic;
using UnityEngine;
using UniRx;
using Zenject;

internal class WallSpawner : MonoBehaviour
{
    internal Wall.Factory wallFactory;
    internal List<Wall> wallList = new List<Wall>();
    DiContainer diContainer;
    GridBuilder gridBuilder { get => diContainer.Resolve<GridBuilder>(); }

    [Inject]
    void Construct(Wall.Factory _wallFactory, DiContainer _diContainer)
    {
        wallFactory = _wallFactory;
        diContainer = _diContainer;
    }
    internal void BuildWalls()
    {
        for (int i = xScale(); i < gridBuilder.tileArray.Count; i++)
            SpawnSideWalls(i);
        for (int i = 0; i < xScale(); i++)
            SpawnForwardAndBackWalls(i);
    }

    void SpawnSideWalls(int tileNumber)
    {
        if (tileNumber % xScale() == 0) SetUpInitializeWallSettings(tileNumber, Vector3.left);
        if (tileNumber % xScale() == xScale() - 1) SetUpInitializeWallSettings(tileNumber, Vector3.right);
    }

    void SpawnForwardAndBackWalls(int cellIndex)
    {
        Wall forwardWallToSpawn = wallFactory.Create();
        forwardWallToSpawn.transform.position = new Vector3(cellIndex - (xScale() - 1) / 2, 0, gridBuilder.gridScale.yScale);
        Wall backWallToSpawn = wallFactory.Create();
        backWallToSpawn.transform.position = new Vector3(cellIndex - (xScale() - 1) / 2, 0, -2);
    }

    void AddWallToList(out Wall wall)
    {
        Wall wallToSpawn = wallFactory.Create();
        wallList.Add(wallToSpawn);
        wall = wallToSpawn;
    }

    void SetUpInitializeWallSettings(int tileNumber, Vector3 offset)
    {
        AddWallToList(out Wall wallToSpawn);
        wallToSpawn.transform.position = gridBuilder.tileArray[tileNumber].transform.position + offset;
        wallToSpawn.HealthPoints.Where(_ => wallToSpawn.HealthPoints.Value <= 0).
            Subscribe(_ => wallToSpawn.Die(wallToSpawn, wallList)).AddTo(wallToSpawn);
    }

    private int xScale() => gridBuilder.gridScale.xScale;
}