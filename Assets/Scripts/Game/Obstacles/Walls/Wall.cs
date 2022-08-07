using System.Collections.Generic;
using Zenject;

public class Wall : Structure
{
    public override void Die(Wall structure, List<Wall> structureList)
    {
        structureList.RemoveAt(structureList.IndexOf(structure));
        Destroy(gameObject);
    }

    public class Factory : PlaceholderFactory<Wall> { }
}
