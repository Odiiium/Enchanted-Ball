using UnityEngine;
using Zenject;
internal class WallFactory
{
    DiContainer diContainer;
    public WallFactory(DiContainer _diContainer) => diContainer = _diContainer;

    public Wall Create(Wall wall, Vector3 position)
    {
        var wallModel= diContainer.InstantiatePrefabForComponent<Wall>
            (wall, position, wall.transform.rotation, null);
        return wallModel;
    }
}
