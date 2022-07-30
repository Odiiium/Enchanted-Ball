using UnityEngine;
using Zenject;

public class GroundInstaller : MonoInstaller
{
    [SerializeField] FirstTile firstTile;
    [SerializeField] SecondTile secondTile;
    [SerializeField] GridBuilder tilesGrid;
    [SerializeField] GridScale gridScale;

    public override void InstallBindings()
    {
        BindTiles();
        BindGridScale();
        BindGrid();
    }

    private void BindTiles()
    {
        Container.Bind<FirstTile>().FromInstance(firstTile).AsSingle().NonLazy();
        Container.Bind<SecondTile>().FromInstance(secondTile).AsSingle().NonLazy();
    }

    private void BindGrid()
    {
        GridBuilder gridLayoutModel = Container.
            InstantiatePrefabForComponent<GridBuilder>(tilesGrid, new Vector3(0, 0, 0), Quaternion.identity, null);
        Container.Bind<GridBuilder>().FromInstance(gridLayoutModel).AsSingle().NonLazy();
    }

    private void BindGridScale()
    {
        Container.Bind<GridScale>().FromInstance(gridScale).AsSingle().NonLazy();
    }
}