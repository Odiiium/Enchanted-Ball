using UnityEngine;

internal class WallFactory
{
    public Wall Create(Wall wall, Vector3 position)
    {
        var wallModel= GameObject.Instantiate(wall, position, wall.transform.rotation, null);
        return wallModel;
    }
}
