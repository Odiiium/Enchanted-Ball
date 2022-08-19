using System.Collections.Generic;
using UnityEngine;
using UniRx;
using Zenject;

internal class WallSpawner : MonoBehaviour
{
    DiContainer diContainer;
    WallFactory wallFactory;
    [SerializeField] internal List<Wall> walls;
    internal List<Wall> wallList = new List<Wall>();
    GridBuilder gridBuilder { get => diContainer.Resolve<GridBuilder>(); }

    [Inject]
    void Construct(WallFactory _wallFactory, DiContainer _diContainer)
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

    internal void SpawnSideWalls(int tileNumber)
    {
        if (tileNumber % xScale() == 0) SetUpInitializeWallSettings(tileNumber, Vector3.left);
        if (tileNumber % xScale() == xScale() - 1) SetUpInitializeWallSettings(tileNumber, Vector3.right);
    }

    void SpawnForwardAndBackWalls(int cellIndex)
    {
        wallFactory.Create
            (walls[Random.Range(0, walls.Count)], new Vector3(cellIndex - (xScale() - 1) / 2, 0, gridBuilder.gridScale.yScale));
        wallFactory.Create
            (walls[Random.Range(0, walls.Count)], new Vector3(cellIndex - (xScale() - 1) / 2, 0, -2));
    }
    void SetUpInitializeWallSettings(int tileNumber, Vector3 offset)
    {
        Vector3 positionToSpawn = gridBuilder.tileArray[tileNumber].transform.position + offset;

        Wall wallToSpawn = AddWallToList(positionToSpawn);
            wallToSpawn.HealthPoints.Where(value => value <= 0).
                Subscribe(_ => wallToSpawn.Die(wallToSpawn, wallList)).AddTo(wallToSpawn);
    }

    Wall AddWallToList(Vector3 position)
    {
        Wall wallToSpawn = wallFactory.Create(walls[Random.Range(0, walls.Count)], position);
        wallList.Add(wallToSpawn);
        return wallToSpawn;
    }

    private int xScale() => gridBuilder.gridScale.xScale;
}
