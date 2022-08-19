using System.Collections.Generic;
using Zenject;

public class Wall : Structure
{
    public override void Die(Wall wall, List<Wall> wallList)
    {
        wallList.RemoveAt(wallList.IndexOf(wall));
        Destroy(gameObject);
    }
}
