using System.Collections.Generic;
using UnityEngine;
using UniRx;
using Zenject;

internal class WallSpawner : MonoBehaviour
{
    internal List<Wall.Factory> wallFactories;
    internal List<Wall> wallList = new List<Wall>();
    DiContainer diContainer;
    GridBuilder gridBuilder { get => diContainer.Resolve<GridBuilder>(); }

    [Inject]
    void Construct(List<Wall.Factory> _wallFactories, DiContainer _diContainer)
    {
        wallFactories = _wallFactories;
        diContainer = _diContainer;
    }
    internal void BuildWalls()
    {
        for (int i = xScale(); i < gridBuilder.tileArray.Count; i++)
            SpawnSideWalls(i);
        for (int i = 0; i < xScale(); i++)
            SpawnForwardAndBackWalls(i);
    }

    internal void SpawnSideWalls(int tileNumber)
    {
        if (tileNumber % xScale() == 0) SetUpInitializeWallSettings(tileNumber, Vector3.left);
        if (tileNumber % xScale() == xScale() - 1) SetUpInitializeWallSettings(tileNumber, Vector3.right);
    }

    void SpawnForwardAndBackWalls(int cellIndex)
    {
        Wall forwardWallToSpawn = wallFactories[Random.Range(0, wallFactories.Count)].Create();
        forwardWallToSpawn.transform.position = new Vector3(cellIndex - (xScale() - 1) / 2, 0, gridBuilder.gridScale.yScale);
        Wall backWallToSpawn = wallFactories[Random.Range(0, wallFactories.Count)].Create();
        backWallToSpawn.transform.position = new Vector3(cellIndex - (xScale() - 1) / 2, 0, -2);
    }
    void SetUpInitializeWallSettings(int tileNumber, Vector3 offset)
    {
        AddWallToList(out Wall wallToSpawn);
        wallToSpawn.transform.position = gridBuilder.tileArray[tileNumber].transform.position + offset;
        wallToSpawn.HealthPoints.Where(_ => wallToSpawn.HealthPoints.Value <= 0).
            Subscribe(_ => wallToSpawn.Die(wallToSpawn, wallList)).AddTo(wallToSpawn);
    }

    void AddWallToList(out Wall wall)
    {
        Wall wallToSpawn = wallFactories[Random.Range(0, wallFactories.Count)].Create();
        wallList.Add(wallToSpawn);
        wall = wallToSpawn;
    }

    private int xScale() => gridBuilder.gridScale.xScale;
}
