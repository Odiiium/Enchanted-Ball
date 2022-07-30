using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class GridBuilder : MonoBehaviour
{
    GridScale gridScale;
    FirstTile firstTile;
    SecondTile secondTile;

    [Inject]
    void Construct(FirstTile _firstTile, SecondTile _secondTile, GridScale _gridScale)
    {
        firstTile = _firstTile;
        secondTile = _secondTile;
        gridScale = _gridScale;
    }

    private void Awake() => BuildAGrid();

    internal void BuildAGrid()
    {
        for (int i = 0; i < gridScale.yScale + 2; i++)
        {
            for (int j = 0; j < gridScale.xScale; j++)
            {
                SetupATile(i, j);
            }
        }
    }

    private void SetupATile(int lengthIndex, int widthIndex)
    {
        if (gridNumber(lengthIndex, widthIndex) % 2 == 1)
            Instantiate(firstTile, SpawnPosition(lengthIndex, widthIndex), firstTile.transform.rotation, gameObject.transform);
        else
            Instantiate(secondTile, SpawnPosition(lengthIndex, widthIndex), secondTile.transform.rotation, gameObject.transform);
    }

    private Vector3 SpawnPosition(int lengthIndex, int widthIndex)
    {
        return new Vector3((widthIndex - (gridScale.xScale - 1) / 2), 0, lengthIndex - 2);
    }

    private float gridNumber(int lengthIndex, int widthIndex)
    {
        return widthIndex + lengthIndex * gridScale.xScale;
    }
}
